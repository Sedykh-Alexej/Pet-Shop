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
    /// Логика взаимодействия для Sales.xaml
    /// </summary>
    public partial class Sales : Page
    {
        public Sales()
        {
            InitializeComponent();
            DGridSales.ItemsSource = Pet_shopEntities.GetContext().Продажи.ToList();
        }

        private void BtnAdd_click(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new EditSales(null));
        }

        private void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var SalesForRemoving = DGridSales.SelectedItems.Cast<Продажи>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {SalesForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Pet_shopEntities.GetContext().Продажи.RemoveRange(SalesForRemoving);
                    Pet_shopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridSales.ItemsSource = Pet_shopEntities.GetContext().Продажи.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Cashier());
        }
    }
}
