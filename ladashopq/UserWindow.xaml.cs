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
using System.Windows.Navigation;
using ladashopq;

namespace ladashopq
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            AppFrame.frameMain = MainFrame;
            MainFrame.Navigate(new Tovar());
            TBLogin.Text = AppData.CurrentUser.Login.ToString();
        }

       

        private void Search(object sender, TextChangedEventArgs e)
        {
            
        }

       
        private void Фильтрация_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
