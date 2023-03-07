using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pet_Shop
{
    /// <summary>
    /// Логика взаимодействия для EditPassword.xaml
    /// </summary>
    public partial class EditPassword : Page
    {
        public Сотрудники _currentСотрудники = new Сотрудники();
        public EditPassword()
        {
            InitializeComponent();
          
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Manager.Forma.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(PasswordBoxx.Password))
                errors.AppendLine("Укажите пароль пожалуйста");
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
                errors.AppendLine("Повторите пароль пожалуйста");
            if (PasswordBoxx.Password != PasswordBox.Password)
                errors.AppendLine("Пароли не совпадают");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var Сотрудник = Pet_shopEntities.GetContext().Сотрудники.Where(d => (d.id == Manager.IDSotr)).FirstOrDefault();

            Сотрудники par = new Сотрудники(0, Сотрудник.Фамилия, Сотрудник.Имя, Сотрудник.Отчество, Сотрудник.Должность, Сотрудник.Адрес, Сотрудник.Телефон, PasswordBox.Password);
            Pet_shopEntities.GetContext().Сотрудники.Add(par);

            try
            { 
                Pet_shopEntities.GetContext().SaveChanges();
                MessageBox.Show("Пароль обновлён!");
                Manager.Forma.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
