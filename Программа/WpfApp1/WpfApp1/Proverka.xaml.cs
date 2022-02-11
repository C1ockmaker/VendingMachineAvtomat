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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Proverka.xaml
    /// </summary>
    public partial class Proverka : Window
    {
        public Proverka()
        {
            InitializeComponent();
        }
        AvtomatEntities1 x = new AvtomatEntities1();
        Admin admin = new Admin();
        MainWindow mainWindow = new MainWindow();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lv1.ItemsSource = x.VendingMachines.ToList();
            var g = x.VendingMachines.Single(m => m.id == 1001);
            var g2 = x.VendingMachines.Single(m => m.id == 2002);
            if (tb1.Text == "" + g.SecretCode + "" + g2.SecretCode + "")
            {
                admin.Show();
                mainWindow.Hide();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Неправильный ввод ключа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow.Show();
        }
    }
}
