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
    /// Логика взаимодействия для RequestsAdmin.xaml
    /// </summary>
    public partial class RequestsAdmin : Window
    {
        public RequestsAdmin()
        {
            InitializeComponent();
            AppFrame.RequestsAdminFrame = ReqAdminFrame;
            ReqAdminFrame.Navigate(new Views.requsetionadmin());
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminwnd = new AdminWindow();
            adminwnd.Show();
            Window.GetWindow(this).Close();
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
