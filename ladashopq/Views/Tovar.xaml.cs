﻿using System;
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


namespace ladashopq
{
    /// <summary>
    /// Логика взаимодействия для Tovar.xaml
    /// </summary>
    public partial class Tovar : Page
    {
        public TableName currentTable;

        public Tovar()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            var content = AppData.db.Tovars.ToList();
            LVMain.ItemsSource = content;
        }

        private void ButtonChangeRequest_Click(object sender, RoutedEventArgs e)
        {
        
        }

        

        private void ButtonUserRequest_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentTovar = button.DataContext as Tovars;
            NavigationService.Navigate(new Views.requsetion(currentTovar));

            
        }
    }
}
