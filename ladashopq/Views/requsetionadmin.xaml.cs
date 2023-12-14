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

namespace ladashopq.Views
{
    /// <summary>
    /// Логика взаимодействия для requsetionadmin.xaml
    /// </summary>
    public partial class requsetionadmin : Page
    {
        public requsetionadmin()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            var content = AppData.db.Applications.ToList();
            RequestsAdmin.ItemsSource = content;
        }


        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentTovar = button.DataContext as Tovars;
            NavigationService.Navigate(new Views.requsetion(currentTovar));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentApplication = (sender as Button).DataContext as Applications;
            //var currentApplications = (sender as Button).DataContext as Applications;
            if (MessageBox.Show("Вы уверены что хотите удалить эту заявку?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AppData.db.Applications.Remove(currentApplication);
                AppData.db.SaveChanges();
                Update();
            }
        }

        private void Tovarsq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
