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
    /// Логика взаимодействия для Postav.xaml
    /// </summary>
    public partial class Postav : Page
    {
        public Postav()
        {
            InitializeComponent();
            DGridPostav.ItemsSource = Pet_shopEntities.GetContext().Поставщики.ToList();
        }

        private void BtnEdit_click(object sender, RoutedEventArgs e)
        {
            var PostavForRemoving = DGridPostav.SelectedItems.Cast<Поставщики>().ToList();
            Pet_shopEntities.GetContext().Поставщики.RemoveRange(PostavForRemoving);
            Pet_shopEntities.GetContext().SaveChanges();
            Manager.Forma.Navigate(new EditPostav((sender as Button).DataContext as Поставщики));
        }

        private void BtnAdd_click(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new EditPostav(null));
        }

        private void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var PostavForRemoving = DGridPostav.SelectedItems.Cast<Поставщики>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {PostavForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Pet_shopEntities.GetContext().Поставщики.RemoveRange(PostavForRemoving);
                    Pet_shopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridPostav.ItemsSource = Pet_shopEntities.GetContext().Поставщики.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Accountant());
        }
    }
}
