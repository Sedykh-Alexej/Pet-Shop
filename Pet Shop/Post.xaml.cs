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
    /// Логика взаимодействия для Post.xaml
    /// </summary>
    public partial class Post : Page
    {
        public Post()
        {
            InitializeComponent();
            DGridPost.ItemsSource = Pet_shopEntities.GetContext().Поставки.ToList();
        }

        private void BtnAdd_click(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new EditPost(null));
        }

        private void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var PostForRemoving = DGridPost.SelectedItems.Cast<Поставки>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {PostForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Pet_shopEntities.GetContext().Поставки.RemoveRange(PostForRemoving);
                    Pet_shopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridPost.ItemsSource = Pet_shopEntities.GetContext().Поставки.ToList();
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
