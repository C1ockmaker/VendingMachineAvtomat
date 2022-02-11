using System;
using System.Collections.Generic;
using System.IO;
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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AvtomatEntities1 x = new AvtomatEntities1();
        Admin ad = new Admin();
        public MainWindow()
        {
            InitializeComponent();
            lv1.ItemsSource = x.Drinks.ToList();

            var r = x.VendingMachineCoins.Single(w => w.id == 1);
            var r2 = x.VendingMachineCoins.Single(w => w.id == 2);
            var r3 = x.VendingMachineCoins.Single(w => w.id == 3);
            var r4 = x.VendingMachineCoins.Single(w => w.id == 4);

            //#1------------------------------------------
            if (r.isActive != 1)
            {
                bt1.Background = (SolidColorBrush) new BrushConverter().ConvertFromString("#FF000000");
            }
            else
            {
                bt1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF515151");
            }
            //#2------------------------------------------
            if (r2.isActive != 1)
            {
                bt2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF000000");
            }
            else
            {
                bt2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF515151");
            }
            //#3------------------------------------------
            if (r3.isActive != 1)
            {
                bt3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF000000");
            }
            else
            {
                bt3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF515151");
            }
            //#4------------------------------------------
            if (r4.isActive != 1)
            {
                bt4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF000000");
            }
            else
            {
                bt4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF515151");
            }

        }
        int costAtomat = 0;
        string cena;
        string nema;

        int coins1 = 0;
        int coins2 = 0;
        int coins3 = 0;
        int coins4 = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var r = x.VendingMachineCoins.Single(w => w.id == 1);          
            if (r.isActive == 1)
            {
                costAtomat = costAtomat + 1;
                tb3.Text = Convert.ToString(costAtomat);
                coins1 = coins1 + 1;
            }
            var coin1 = x.VendingMachineCoins.Single(m => m.id == 1);
            coin1.Count = coin1.Count + coins1;
            x.SaveChanges();
            coins1 = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var r2 = x.VendingMachineCoins.Single(w => w.id == 2);
            if (r2.isActive == 1)
            {
                costAtomat = costAtomat + 2;
                tb3.Text = Convert.ToString(costAtomat);
                coins2 = coins2 + 1;


            }
            var coin2 = x.VendingMachineCoins.Single(m => m.id == 2);
            coin2.Count = coin2.Count + coins2;
            x.SaveChanges();
            coins2 = 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var r3 = x.VendingMachineCoins.Single(w => w.id == 3);
            if (r3.isActive == 1)
            {
                    costAtomat = costAtomat + 5;
                    tb3.Text = Convert.ToString(costAtomat);
                    coins3 = coins3 + 1;
            }
           
            var coin3 = x.VendingMachineCoins.Single(m => m.id == 3);                     
            coin3.Count = coin3.Count + coins3;          
            x.SaveChanges();
            coins3 = 0;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var r4 = x.VendingMachineCoins.Single(w => w.id == 4);
            if (r4.isActive == 1)
            {
                        costAtomat = costAtomat + 10;
                        tb3.Text = Convert.ToString(costAtomat);
                        coins4 = coins4 + 1;
            }
            var coin4 = x.VendingMachineCoins.Single(m => m.id == 4);
            coin4.Count = coin4.Count + coins4;
            x.SaveChanges();
            coins4 = 0;
        }
                          
        private void Lv1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (dynamic)lv1.SelectedItems[0];
            int g = item.id;
            var l2 = x.VendingMachineDrinks.Single(k => k.Drinksld == g);
            int g2 = l2.Count;
            cena = Convert.ToString(item.Cost);
            nema = Convert.ToString(item.Name);
            var coin1 = x.VendingMachineCoins.Single(m => m.id == 1);
            var coin2 = x.VendingMachineCoins.Single(m => m.id == 2);
            var coin3 = x.VendingMachineCoins.Single(m => m.id == 3);
            var coin4 = x.VendingMachineCoins.Single(m => m.id == 4);
            int itog = Convert.ToInt32(tb3.Text) - Convert.ToInt32(cena);          
            if (Convert.ToInt32(cena) > Convert.ToInt32(tb3.Text))
            {
                MessageBox.Show("Недостаточно средств", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {      
                if (g2 != 0)
                {
                    if ((coin1.Count * 1) + (coin2.Count * 2) + (coin3.Count * 5) + (coin4.Count * 10) >= itog)
                    {                         
                        tb3.Text = Convert.ToString(itog);                    
                        costAtomat = Convert.ToInt32(tb3.Text);
                        MessageBox.Show("Вы приобрели:" + nema, "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                        var l1 = x.VendingMachineDrinks.Single(k => k.Drinksld == g);
                        int h2 = l1.Count - 1;
                        int h3 = Convert.ToInt32(l1.Sold + 1);
                        int h4 = Convert.ToInt32(item.Cost * h3);
                        l1.Count = h2;
                        l1.Sold = h3;
                        l1.ProfitSum = h4;           
                    }
                    else
                    {
                        MessageBox.Show("В автомате недостаточно средств, для сдачи", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Напиток закончился", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }

        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Ваша сдача: " + tb3.Text + "р", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);

            int gafa = 0;
            gafa = Convert.ToInt32(tb3.Text);
            tb3.Text = "0";
            cena = "0";
            costAtomat = 0;      
            var coin1 = x.VendingMachineCoins.Single(m => m.id == 1);
            var coin2 = x.VendingMachineCoins.Single(m => m.id == 2);
            var coin3 = x.VendingMachineCoins.Single(m => m.id == 3);
            var coin4 = x.VendingMachineCoins.Single(m => m.id == 4);
            int countcoin1 = 0;
            int countcoin2 = 0;
            int countcoin3 = 0;
            int countcoin4 = 0;
            int gara = (coin1.Count * 1) + (coin2.Count * 2) + (coin3.Count * 5) + (coin4.Count * 10);

            //#1---------------------------------------------------------------
            while (gafa >= 10)
            {
                gafa = gafa - 10;
                countcoin4 = countcoin4 + 1;

            }     
            //#2--------------------------------------------------------------

            while (gafa >= 5)
            {
                gafa = gafa - 5;
                countcoin3 = countcoin3 + 1;
            }

            //#3-----------------------------------------------------------------
            while (gafa >= 2)
            {
             gafa = gafa - 2;
             countcoin2 = countcoin2 + 1;
            }

            //#4----------------------------------------------------------------
            while (gafa >= 1)
            {
                gafa = gafa - 1;
                countcoin1 = countcoin1 + 1;
            }
            
            if(coin4.Count - countcoin4 <= 0)
            {
                MessageBox.Show("В автомате нет подходящих монет, для сдачи, а именно:10р. " +
              "Обратитесь в администрацию", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                coin4.Count = coin4.Count - countcoin4;
            }

            if (coin3.Count - countcoin3 <= 0)
            {
                MessageBox.Show("В автомате нет подходящих монет, для сдачи, а именно:5р. " +
                "Обратитесь в администрацию", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                coin3.Count = coin3.Count - countcoin3;
            }

            if (coin2.Count - countcoin2 <= 0)
            {
                MessageBox.Show("В автомате нет подходящих монет, для сдачи, а именно:2р. " +
             "Обратитесь в администрацию", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                coin2.Count = coin2.Count - countcoin2;
            }


            if (coin1.Count - countcoin1 <= 0)
            {
                MessageBox.Show("В автомате нет подходящих монет, для сдачи, а именно:1р. " +
           "Обратитесь в администрацию", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                coin1.Count = coin1.Count - countcoin1;
            }
                x.SaveChanges();                                
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Proverka proverka = new Proverka();
            proverka.Show();
            this.Hide();

        }
    }
}
