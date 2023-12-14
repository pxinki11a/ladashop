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

namespace ladashopq
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        public TableName currentTable;
        public AdminWindow()
        {
            InitializeComponent();
            AppFrame.frameMain = AdminFrame;
            AdminFrame.Navigate(new Views.TovarsAdmin());
        }





        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            AdminFrame.Navigate(new Views.AddEditTovarsPage());

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                WindowAuth user = new WindowAuth();
                user.Show();
                Window.GetWindow(this).Close();
            }
        }

        private void AdminFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Фильтрация_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Сортировка_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonRequest_Click(object sender, RoutedEventArgs e)
        {
            RequestsAdmin reqadmin = new RequestsAdmin();
            reqadmin.Show();
            Window.GetWindow(this).Close();
        }
    }
}








