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
    /// Логика взаимодействия для Animal.xaml
    /// </summary>
    public partial class Animal : Page
    {
        public Animal()
        {
            InitializeComponent();
            DGridAnimals.ItemsSource = Pet_shopEntities.GetContext().Животные.ToList();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Manager.Forma.GoBack();
        }
    }
}
