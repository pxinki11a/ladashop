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
    /// Логика взаимодействия для TovarsAdmin.xaml
    /// </summary>
    public partial class TovarsAdmin : Page
    {
        
        public TovarsAdmin()
        {
            InitializeComponent();
            Update();
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentTovar = button.DataContext as Tovars;
            NavigationService.Navigate(new Views.AddEditTovarsPage(currentTovar));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentTovar = (sender as Button).DataContext as Tovars;
            if (MessageBox.Show("Вы уверены что хотите удалить этот товар?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AppData.db.Tovars.Remove(currentTovar);
                AppData.db.SaveChanges();
                Update();
            }
        }

        public void Update()
        {
            var content = AppData.db.Tovars.ToList();
            LVTovarsAdmin.ItemsSource = content;
        }

        private void LVTovarsAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
