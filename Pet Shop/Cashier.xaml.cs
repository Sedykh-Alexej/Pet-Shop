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
    /// Логика взаимодействия для Cashier.xaml
    /// </summary>
    public partial class Cashier : Page
    {
        public Cashier()
        {
            InitializeComponent();
            txtRab.Content = "Приветствуем вас на рабочем месте " + Manager.IFO +"!";
        }

        private void ИзмКонтИнФор(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Contact_Information());
        }

        private void EditParol(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new EditPassword());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Authorization());
        }

        private void Calculator(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Calculator());
        }

        private void Animals(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Animal());
        }

        private void Sales(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Sales());
        }
    }
}
