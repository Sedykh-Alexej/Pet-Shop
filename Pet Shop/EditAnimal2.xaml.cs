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
    /// Логика взаимодействия для EditAnimal2.xaml
    /// </summary>
    public partial class EditAnimal2 : Page
    {
        
       
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Название.Text))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(Характеристика.Text))
                errors.AppendLine("Укажите характеристику");
            if (string.IsNullOrWhiteSpace(Цена_закупки.Text))
                errors.AppendLine("Укажите цену закупки");
            if (string.IsNullOrWhiteSpace(Цена_продажи.Text))
                errors.AppendLine("Укажите цену продажи");
            if (string.IsNullOrWhiteSpace(Количество.Text))
                errors.AppendLine("Укажите количество");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            int Кол_воо = Convert.ToInt32(Количество.Text);

           
        }
    }
}
