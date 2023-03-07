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
    /// Логика взаимодействия для Contact_Information.xaml
    /// </summary>
    public partial class Contact_Information : Page
    {
        public Book_houseEntities db;
        public Contact_Information()
        {
            InitializeComponent();
            db = new Book_houseEntities();
            var Сотрудник = db.Сотрудники.Where(d => (d.id==Manager.IDSotr));

         
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var Сотрудник = Book_houseEntities.GetContext().Сотрудники.Where(d => (d.id == Manager.IDSotr)).FirstOrDefault();

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(адрес.Text))
                errors.AppendLine("Укажите Адрес пожалуйста");
            if (string.IsNullOrWhiteSpace(телефон.Text))
                errors.AppendLine("Укажите телефон пожалуйста");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            Сотрудники par = new Сотрудники(0, Сотрудник.Фамилия, Сотрудник.Имя, Сотрудник.Отчество, Сотрудник.Должность, адрес.Text, телефон.Text, Сотрудник.Пароль);
            Book_houseEntities.GetContext().Сотрудники.Add(par);

            try
            {
                Book_houseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.Forma.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Manager.Forma.GoBack();
        }
    }
}
