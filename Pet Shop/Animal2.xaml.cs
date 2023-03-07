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
    /// Логика взаимодействия для Animal2.xaml
    /// </summary>
    public partial class Animal2 : Page
    {
        public Animal2()
        {
            InitializeComponent();
            DGridAnimal2.ItemsSource = Pet_shopEntities.GetContext().Животные.ToList();
        }

        private void BtnEdit_click(object sender, RoutedEventArgs e)
        {
            var AnimalForRemoving = DGridAnimal2.SelectedItems.Cast<Животные>().ToList();
            Pet_shopEntities.GetContext().Животные.RemoveRange(AnimalForRemoving);
            Pet_shopEntities.GetContext().SaveChanges();
            Manager.Forma.Navigate(new EditAnimal2((sender as Button).DataContext as Животные));
        }

        private void BtnAdd_click(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new EditAnimal2(null));
        }

        private void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var PostavForRemoving = DGridAnimal2.SelectedItems.Cast<Животные>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {PostavForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Pet_shopEntities.GetContext().Животные.RemoveRange(PostavForRemoving);
                    Pet_shopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridAnimal2.ItemsSource = Pet_shopEntities.GetContext().Животные.ToList();
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
