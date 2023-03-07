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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public List<string> namelist;
        public Book_houseEntities db;
        public Authorization()
        {
            InitializeComponent();
            try
            {
                db = new Book_houseEntities();
                namelist = new List<string>();
                foreach (var item in db.Сотрудники)
                {
                    namelist.Add(item.Имя + " " + item.Отчество + " " + item.Фамилия);
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.ToString());
            }

        }

        private void Stylee(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new Stylee());
        }

        private void Populating(object sender, PopulatingEventArgs e)
        {
            try
            {
                string txt = outText.Text;
                List<string> outoList = new List<string>();
                outoList.Clear();
                if (namelist != null)
                {
                    foreach (string item in namelist)
                    {
                        if (!string.IsNullOrEmpty(outText.Text))
                        {
                            if (item.ToLower().StartsWith(txt.ToLower()))
                            {
                                outoList.Add(item);
                                Manager.IFO = item;
                            }
                        }
                    }
                    outText.ItemsSource = outoList;
                    outText.PopulateComplete();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void Войти(object sender, RoutedEventArgs e)
        {
            try
            {
                    var Сотрудник = db.Сотрудники.Where(d => (d.Имя.ToLower()).Equals(outText.Text.ToLower())
                    && d.Пароль == PasswordBoxx.Password).FirstOrDefault();
                if (Сотрудник != null)
                {
                    Manager.IDSotr = Сотрудник.id;
                    if (Сотрудник.Должность == 1)
                    {
                        Manager.Forma.Navigate(new Chief());

                    }
                    else if (Сотрудник.Должность == 2)
                    {
                        Manager.Forma.Navigate(new Accountant());
                    }
                    else
                    {
                        Manager.Forma.Navigate(new Cashier());
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте правильность ввода имени пользователя и пароля!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
