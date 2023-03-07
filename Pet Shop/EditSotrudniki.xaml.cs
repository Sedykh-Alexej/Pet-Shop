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
    /// Логика взаимодействия для EditSotrudniki.xaml
    /// </summary>
    public partial class EditSotrudniki : Page
    {
        public EditSotrudniki()
        {
            InitializeComponent();
            должность.ItemsSource = Pet_shopEntities.GetContext().Должности.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Имя.Text))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(Фамилия.Text))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(Отчество.Text))
                errors.AppendLine("Укажите отчество");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var Должность = Pet_shopEntities.GetContext().Должности.Where(d => d.Должность == должность.Text).FirstOrDefault();

            Сотрудники сотрудник = new Сотрудники(0, Фамилия.Text, Имя.Text, Отчество.Text, Должность.id, "Не заполнено", "Не заполнено", "1234");
            Pet_shopEntities.GetContext().Сотрудники.Add(сотрудник);

            try
            {
                Pet_shopEntities.GetContext().SaveChanges();
                Manager.Forma.Navigate(new Sotrudniki());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
