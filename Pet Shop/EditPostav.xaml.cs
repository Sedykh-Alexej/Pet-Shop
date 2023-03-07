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
    /// Логика взаимодействия для EditPostav.xaml
    /// </summary>
    public partial class EditPostav : Page
    {
        public Поставщики _currentПоставщики = new Поставщики();
        public EditPostav(Поставщики selectedПоставщики)
        {
            InitializeComponent();
            if (selectedПоставщики != null)
                _currentПоставщики = selectedПоставщики;

            DataContext = _currentПоставщики;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
           
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Наименование.Text))
                errors.AppendLine("Укажите наименование");
            if (string.IsNullOrWhiteSpace(Адрес.Text))
                errors.AppendLine("Укажите адрес");
            if (string.IsNullOrWhiteSpace(Телефон.Text))
                errors.AppendLine("Укажите телефон");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            Поставщики поставщики = new Поставщики(0, Наименование.Text, Адрес.Text, Телефон.Text);
            Pet_shopEntities.GetContext().Поставщики.Add(поставщики);

            try
            {
                Pet_shopEntities.GetContext().SaveChanges();
                Manager.Forma.Navigate(new Postav());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
