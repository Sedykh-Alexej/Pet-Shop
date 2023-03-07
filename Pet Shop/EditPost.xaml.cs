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
    /// Логика взаимодействия для EditPost.xaml
    /// </summary>
    public partial class EditPost : Page
    {
        public Поставки _currentПоставки = new Поставки();
        public EditPost(Поставки selectedПоставки)
        {
            InitializeComponent();
            if (selectedПоставки != null)
                _currentПоставки = selectedПоставки;

            DataContext = _currentПоставки;
            id_сотрудника.Text = Manager.IFO;
            животное.ItemsSource = Pet_shopEntities.GetContext().Животные.ToList();
            поставщик.ItemsSource = Pet_shopEntities.GetContext().Поставщики.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(животное.Text))
                errors.AppendLine("Укажите животное");
            if (string.IsNullOrWhiteSpace(кол_во.Text))
                errors.AppendLine("Укажите количество");
            if (string.IsNullOrWhiteSpace(поставщик.Text))
                errors.AppendLine("Укажите поставщика");
            if (string.IsNullOrWhiteSpace(Date.Text))
                errors.AppendLine("Укажите дату поставки");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            int Кол_во = Convert.ToInt32(кол_во.Text);
            DateTime Datee = Convert.ToDateTime(Date.Text);
            var Животное = Pet_shopEntities.GetContext().Животные.Where(d => d.Название == животное.Text).FirstOrDefault();
            Животное.Кол_во += Кол_во;
            int Кол_воо = Convert.ToInt32(Животное.Кол_во);
            int Цена = Convert.ToInt32(Животное.Цена_закупки);
            Manager.Trat += Кол_воо * Цена;
            var Поставщик = Pet_shopEntities.GetContext().Поставщики.Where(d => d.Наименование == поставщик.Text).FirstOrDefault();

            Поставки поставка = new Поставки(0, Поставщик.id, Животное.id, Кол_во, Manager.IDSotr, Datee);
            Pet_shopEntities.GetContext().Поставки.Add(поставка);

            try
            {
                Pet_shopEntities.GetContext().SaveChanges();
                Manager.Forma.Navigate(new Post());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
