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
    /// Логика взаимодействия для EditSales.xaml
    /// </summary>
    public partial class EditSales : Page
    {
        public Продажи _currentПродажи = new Продажи();
        public EditSales(Продажи selectedПродажи)
        {
            InitializeComponent();
            if (selectedПродажи != null)
                _currentПродажи = selectedПродажи;

            DataContext = _currentПродажи;
            id_сотрудника.Text = Manager.IFO;
            животное.ItemsSource = Pet_shopEntities.GetContext().Животные.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           

            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(животное.Text))
                errors.AppendLine("Укажите животное");
            if (string.IsNullOrWhiteSpace(кол_во.Text))
                errors.AppendLine("Укажите количество");
            if (string.IsNullOrWhiteSpace(Date.Text))
                errors.AppendLine("Укажите дату продажи");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            int Кол_во = Convert.ToInt32(кол_во.Text);
            DateTime Datee = Convert.ToDateTime(Date.Text);
            var Животное = Pet_shopEntities.GetContext().Животные.Where(d => d.Название == животное.Text).FirstOrDefault();
            Животное.Кол_во -= Кол_во;
            int Кол_воо = Convert.ToInt32(Животное.Кол_во);
            int Цена = Convert.ToInt32(Животное.Цена_продажи);
            Manager.Prib += Кол_воо * Цена;

            Продажи продажи = new Продажи(0, Животное.id, Кол_во, Manager.IDSotr, Datee);
            Pet_shopEntities.GetContext().Продажи.Add(продажи);

            try
            {
                Pet_shopEntities.GetContext().SaveChanges();
                Manager.Forma.Navigate(new Sales());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
