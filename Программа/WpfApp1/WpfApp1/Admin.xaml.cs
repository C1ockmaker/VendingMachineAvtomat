using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;

namespace WpfApp1
{
    
    public partial class Admin : Window
    {
        AvtomatEntities1 x = new AvtomatEntities1();

        public int g = 0;
        public int g1 = 0;
        public int g2 = 0;
        public int g3 = 0;
        

        public Admin()
        {
            InitializeComponent();
            lv1.ItemsSource = x.Drinks.ToList();

            var r = x.VendingMachineCoins.Single(w => w.id == 1);
            tb1.Text = Convert.ToString(r.Count);

            var r2 = x.VendingMachineCoins.Single(w => w.id == 2);
            tb2.Text = Convert.ToString(r2.Count);

            var r3 = x.VendingMachineCoins.Single(w => w.id == 3);
            tb3.Text = Convert.ToString(r3.Count);

            var r4 = x.VendingMachineCoins.Single(w => w.id == 4);
            tb4.Text = Convert.ToString(r4.Count);
            
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var r = x.VendingMachineCoins.Single(w => w.id == 1);           
            r.Count = Convert.ToInt32(tb1.Text);

            var r2 = x.VendingMachineCoins.Single(w => w.id == 2);
            r2.Count = Convert.ToInt32(tb2.Text);

            var r3 = x.VendingMachineCoins.Single(w => w.id == 3);
            r3.Count = Convert.ToInt32(tb3.Text);

            var r4 = x.VendingMachineCoins.Single(w => w.id == 4);         
            r4.Count = Convert.ToInt32(tb4.Text);
            x.SaveChanges();
            //#1------------------------------------------
            if (cb1.IsChecked == true)
            {              
                r.isActive = 0;
                x.SaveChanges();
            }
            else
            {
                r.isActive = 1;
                x.SaveChanges();
            }
            //#2------------------------------------------
            if (cb2.IsChecked == true)
            {
                r2.isActive = 0;
                x.SaveChanges();
            }
            else
            {
                r2.isActive = 1;
                x.SaveChanges();
            }
            //#3------------------------------------------
            if (cb3.IsChecked == true)
            {
                r3.isActive = 0;
                x.SaveChanges();
            }
            else
            {
                r3.isActive = 1;
                x.SaveChanges();
            }
            //#4------------------------------------------
            if (cb4.IsChecked == true)
            {
                r4.isActive = 0;
                x.SaveChanges();
            }
            else
            {             
                r4.isActive = 1;
                x.SaveChanges();
            }

            MessageBox.Show("Изменение внесены", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
          
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            MainWindow window = new MainWindow();
            window.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var max = x.Drinks.Max(d => d.id);
                string name = texta1.Text;
                string image1 = "Resources/" + texta4.Text + "";
                int cost = Convert.ToInt32(texta2.Text);
                int col = Convert.ToInt32(texta3.Text);

                Drinks drinks = new Drinks { id = max + 1, Name = name, image = image1, Cost = cost };
                VendingMachineDrinks vending = new VendingMachineDrinks { id = max + 1, VendingMachineDrinks1 = 2002, Drinksld = max + 1, Count_after_last_update = col, Count = col,ProfitSum = 0, Sold = 0};
                x.Drinks.Add(drinks);
                x.VendingMachineDrinks.Add(vending);
                x.SaveChanges();
                lv1.ItemsSource = x.Drinks.ToList();
                MessageBox.Show("Новый напиток внесен.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Проверьте правильность заполнения.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Lv1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (dynamic)lv1.SelectedItems[0];             
            texta1.Text = item.Name;
            texta2.Text = Convert.ToString(item.Cost);
            texta4.Text = Regex.Replace(item.image, "Resources/", "");
            int g = item.id;          
            var mar = x.VendingMachineDrinks.Single(m => m.id == g);
            texta3.Text = Convert.ToString(mar.Count);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (dynamic)lv1.SelectedItems[0];
                item.Name = texta1.Text;
                item.Cost = Convert.ToInt32(texta2.Text);
                item.image = "Resources/" + texta4.Text + "";
                int g = item.id;              
                var mar = x.VendingMachineDrinks.Single(m => m.id == g);
                mar.Count = Convert.ToInt32(texta3.Text);
                mar.Count_after_last_update = Convert.ToInt32(texta3.Text);
                mar.Sold = Convert.ToInt32(0);
                mar.ProfitSum = Convert.ToInt32(0);
                x.SaveChanges();
                lv1.ItemsSource = x.Drinks.ToList();
                MessageBox.Show("Изменение прошли успешно.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Проверьте правильность заполнения.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            img1.Source = new BitmapImage(new Uri("Resources/"+texta4.Text+"", UriKind.Relative));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (dynamic)lv1.SelectedItems[0];               
                int g = item.id;               
                var del = x.VendingMachineDrinks.Single(m => m.id == g);
                var del1 = x.Drinks.Single(m => m.id == g);
                x.VendingMachineDrinks.Remove(del);
                x.Drinks.Remove(del1);
                x.SaveChanges();
                lv1.ItemsSource = x.Drinks.ToList();
                MessageBox.Show("Напиток удалён.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Данные не найдены.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            lb1.Visibility = Visibility.Visible;
            lb2.Visibility = Visibility.Visible;
            lb3.Visibility = Visibility.Visible;
            lb4.Visibility = Visibility.Visible;
            texta1.Visibility = Visibility.Visible;
            texta2.Visibility = Visibility.Visible;
            texta3.Visibility = Visibility.Visible;
            texta4.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Visible;
            otmen1.Visibility = Visibility.Visible;
            btdobav.Visibility = Visibility.Hidden;
            img1.Visibility = Visibility.Visible;
            prosm.Visibility = Visibility.Visible;
            ismen.Visibility = Visibility.Visible;
            delet.Visibility = Visibility.Visible;
        }

        private void Otmen1_Click(object sender, RoutedEventArgs e)
        {
            lb1.Visibility = Visibility.Hidden;
            lb2.Visibility = Visibility.Hidden;
            lb3.Visibility = Visibility.Hidden;
            lb4.Visibility = Visibility.Hidden;
            texta1.Visibility = Visibility.Hidden;
            texta2.Visibility = Visibility.Hidden;
            texta3.Visibility = Visibility.Hidden;
            texta4.Visibility = Visibility.Hidden;
            save.Visibility = Visibility.Hidden;
            otmen1.Visibility = Visibility.Hidden;
            btdobav.Visibility = Visibility.Visible;
            img1.Visibility = Visibility.Hidden;
            prosm.Visibility = Visibility.Hidden;
            ismen.Visibility = Visibility.Hidden;
            delet.Visibility = Visibility.Hidden;
            texta1.Text = "";
            texta2.Text = "";
            texta3.Text = "";
            texta4.Text = "";
            img1.Source = new BitmapImage(new Uri("Resources/Napitok.png", UriKind.Relative));

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dg1.ItemsSource = x.VendingMachineDrinks.ToList();
            btya1.Visibility =Visibility.Visible;
            dg1.Visibility = Visibility.Visible;

            lb1.Visibility = Visibility.Hidden;
            lb2.Visibility = Visibility.Hidden;
            lb3.Visibility = Visibility.Hidden;
            lb4.Visibility = Visibility.Hidden;
            texta1.Visibility = Visibility.Hidden;
            texta2.Visibility = Visibility.Hidden;
            texta3.Visibility = Visibility.Hidden;
            texta4.Visibility = Visibility.Hidden;
            save.Visibility = Visibility.Hidden;
            otmen1.Visibility = Visibility.Hidden;
            btdobav.Visibility = Visibility.Hidden;
            img1.Visibility = Visibility.Hidden;
            prosm.Visibility = Visibility.Hidden;
            ismen.Visibility = Visibility.Hidden;
            delet.Visibility = Visibility.Hidden;
            texta1.Text = "";
            texta2.Text = "";
            texta3.Text = "";
            texta4.Text = "";
            img1.Source = new BitmapImage(new Uri("Resources/Napitok.png", UriKind.Relative));

          
            img5.Visibility = Visibility.Hidden;
            lv1.Visibility = Visibility.Hidden;

            im1.Visibility = Visibility.Hidden;
            im2.Visibility = Visibility.Hidden;
            im3.Visibility = Visibility.Hidden;
            im4.Visibility = Visibility.Hidden;
            tb1.Visibility = Visibility.Hidden;
            tb2.Visibility = Visibility.Hidden;
            tb3.Visibility = Visibility.Hidden;
            tb4.Visibility = Visibility.Hidden;
            cb1.Visibility = Visibility.Hidden;
            cb2.Visibility = Visibility.Hidden;
            cb3.Visibility = Visibility.Hidden;
            cb4.Visibility = Visibility.Hidden;
            btya.Visibility = Visibility.Hidden;


        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
               
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            lb11.Visibility = Visibility.Visible;
            lb22.Visibility = Visibility.Visible;
            lb33.Visibility = Visibility.Visible;
            lb10.Visibility = Visibility.Visible;
            bt5.Visibility = Visibility.Visible;
            bt4.Visibility = Visibility.Hidden;
            lb5.Visibility = Visibility.Hidden;
        }

        private void Bt5_Click(object sender, RoutedEventArgs e)
        {
            lb11.Visibility = Visibility.Hidden;
            lb22.Visibility = Visibility.Hidden;
            lb33.Visibility = Visibility.Hidden;
            lb10.Visibility = Visibility.Hidden;
            bt5.Visibility = Visibility.Hidden;
            bt4.Visibility = Visibility.Visible;
            lb5.Visibility = Visibility.Visible;


            

        }

        private void Lb22_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            lv1.Visibility = Visibility.Visible;
            btdobav.Visibility = Visibility.Visible;
            img5.Visibility = Visibility.Visible;

            btya1.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            lb1.Visibility = Visibility.Hidden;
            lb2.Visibility = Visibility.Hidden;
            lb3.Visibility = Visibility.Hidden;
            lb4.Visibility = Visibility.Hidden;
            texta1.Visibility = Visibility.Hidden;
            texta2.Visibility = Visibility.Hidden;
            texta3.Visibility = Visibility.Hidden;
            texta4.Visibility = Visibility.Hidden;
            save.Visibility = Visibility.Hidden;
            otmen1.Visibility = Visibility.Hidden;          
            img1.Visibility = Visibility.Hidden;
            prosm.Visibility = Visibility.Hidden;
            ismen.Visibility = Visibility.Hidden;
            delet.Visibility = Visibility.Hidden;
            texta1.Text = "";
            texta2.Text = "";
            texta3.Text = "";
            texta4.Text = "";
            img1.Source = new BitmapImage(new Uri("Resources/Napitok.png", UriKind.Relative));

          
            im1.Visibility = Visibility.Hidden;
            im2.Visibility = Visibility.Hidden;
            im3.Visibility = Visibility.Hidden;
            im4.Visibility = Visibility.Hidden;
            tb1.Visibility = Visibility.Hidden;
            tb2.Visibility = Visibility.Hidden;
            tb3.Visibility = Visibility.Hidden;
            tb4.Visibility = Visibility.Hidden;
            cb1.Visibility = Visibility.Hidden;
            cb2.Visibility = Visibility.Hidden;
            cb3.Visibility = Visibility.Hidden;
            cb4.Visibility = Visibility.Hidden;
            btya.Visibility = Visibility.Hidden;


        }

        private void Lb11_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            im1.Visibility = Visibility.Visible;
            im2.Visibility = Visibility.Visible;
            im3.Visibility = Visibility.Visible;
            im4.Visibility = Visibility.Visible;
            tb1.Visibility = Visibility.Visible;
            tb2.Visibility = Visibility.Visible;
            tb3.Visibility = Visibility.Visible;
            tb4.Visibility = Visibility.Visible;
            cb1.Visibility = Visibility.Visible;
            cb2.Visibility = Visibility.Visible;
            cb3.Visibility = Visibility.Visible;
            cb4.Visibility = Visibility.Visible;
            btya.Visibility = Visibility.Visible;


            img5.Visibility = Visibility.Hidden;
            lv1.Visibility = Visibility.Hidden;

            btya1.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            lb1.Visibility = Visibility.Hidden;
            lb2.Visibility = Visibility.Hidden;
            lb3.Visibility = Visibility.Hidden;
            lb4.Visibility = Visibility.Hidden;
            texta1.Visibility = Visibility.Hidden;
            texta2.Visibility = Visibility.Hidden;
            texta3.Visibility = Visibility.Hidden;
            texta4.Visibility = Visibility.Hidden;
            save.Visibility = Visibility.Hidden;
            otmen1.Visibility = Visibility.Hidden;
            btdobav.Visibility = Visibility.Hidden;
            img1.Visibility = Visibility.Hidden;
            prosm.Visibility = Visibility.Hidden;
            ismen.Visibility = Visibility.Hidden;
            delet.Visibility = Visibility.Hidden;
            texta1.Text = "";
            texta2.Text = "";
            texta3.Text = "";
            texta4.Text = "";
            img1.Source = new BitmapImage(new Uri("Resources/Napitok.png", UriKind.Relative));
        }

        private void Btya1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная функция находиться в разработке, присосим свои извинения.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    
}
