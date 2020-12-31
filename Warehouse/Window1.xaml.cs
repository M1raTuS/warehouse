using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Warehouse.Models;

namespace Warehouse
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            CreateGrid();
        }

        public Product Products { get; private set; }

        public Window1(Product prod)
        {
            InitializeComponent();

            CreateGrid();

            Products = prod;
            this.DataContext = Products;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Type type = Type.GetType("Warehouse.Window1", false, true);
            //object obj = Activator.CreateInstance(type);
            //var o = type.GetField("tb1");

            //MessageBox.Show(o.ToString());
            //if (String.IsNullOrEmpty(tb1.Text) ||
            //    String.IsNullOrEmpty(tb2.Text) ||
            //    String.IsNullOrEmpty(tb3.Text) ||
            //    String.IsNullOrEmpty(tb4.Text) ||
            //    String.IsNullOrEmpty(tb5.Text) ||
            //    String.IsNullOrEmpty(tb6.Text) ||
            //    String.IsNullOrEmpty(tb7.Text))
            //{
            //    MessageBox.Show("Заполните все поля", "");
            //}
            //else
            //{
               this.DialogResult = true;
            //}

        }

        private void CreateGrid()
        {
            List<string> prop = new List<string>();
            Type type = Type.GetType("Warehouse.Models.Product",false,true);
            foreach (var item in type.GetProperties())
            {
                prop.Add(item.Name.ToString());
            }

           

            for (int i = 1; i <= 6; i++)
            {
                TextBox tb = new TextBox();
                tb.HorizontalAlignment = HorizontalAlignment.Left;
                tb.Height = 23;
                tb.Width = 120;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.VerticalAlignment = VerticalAlignment.Top;
                tb.Margin = new Thickness(20, i * 30, 0, 0);
                tb.TabIndex = i;
                tb.Name = "tb" + i;
                tb.Text = "{Binding " + prop[i].ToString() + "}";
                
                Binding binding = new Binding(prop[i]);
                tb.SetBinding(TextBox.TextProperty,binding);

                MyGrid.Children.Add(tb);

                Label lb = new Label();
                lb.HorizontalAlignment = HorizontalAlignment.Left;
                lb.VerticalAlignment = VerticalAlignment.Top;
                lb.Margin = new Thickness(150, i * 30, 0, 0);
                lb.TabIndex = i*10;
                lb.Name = "lb" + i;
                lb.Content = prop[i].ToString();
                MyGrid.Children.Add(lb);
            }

            Button bt = new Button();
            bt.HorizontalAlignment = HorizontalAlignment.Left;
            bt.Height = 23;
            bt.Width = 120;
            bt.VerticalAlignment = VerticalAlignment.Top;
            bt.Margin = new Thickness(70, 260, 0, 0);
            bt.TabIndex = 50;
            bt.Name = "bt1";
            bt.Content = "Add";
            bt.Click += Accept_Click;
            MyGrid.Children.Add(bt);
        }
    }
}
