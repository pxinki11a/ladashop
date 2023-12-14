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

namespace ladashopq
{
    /// <summary>
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        public GuestWindow()
        {
            InitializeComponent();
            AppFrame.frameGuest = GuestFrame;
            GuestFrame.Navigate(new Views.GuestPage());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

        private void Фильтрация_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Сортировка_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void GuestFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
