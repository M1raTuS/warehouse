using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Warehouse.Models;

namespace Warehouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WarehouseContext db;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Task.Factory.StartNew(() =>
                {
                    db = new WarehouseContext();
                    db.Products.Load();

                 Dispatcher.Invoke( new Action(() =>  ProductsGrid.ItemsSource = db.Products.Local.ToBindingList())); 
                });
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window1 wd = new Window1(new Product());
                if (wd.ShowDialog() == true)
                {
                    Product prod = wd.Products;
                    db.Products.Add(prod);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля", "Exception Sample", MessageBoxButton.OK);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ProductsGrid.SelectedItems.Count; i++)
                {
                    Product prod = ProductsGrid.SelectedItems[i] as Product;
                    if (prod != null)
                    {
                        db.Products.Remove(prod);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
