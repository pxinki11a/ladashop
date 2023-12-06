
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
    /// Логика взаимодействия для ShortPage.xaml
    /// </summary>
    public partial class ShortPage : Page
    {
        public TableName currentTable;
        public ShortPage()
        {
            InitializeComponent();
        }

        public ShortPage(TableName tn)
        {
            currentTable = tn;
            this.WindowTitle = currentTable.ToString();

            InitializeComponent();
            Update();
        }
        public void Update()
        {
            switch (currentTable)
            {
                case TableName.Categories:
                    List<Categories> categories = AppData.db.Categories.ToList();
                    LVShort.ItemsSource = categories;
                    break;
                case TableName.Role:
                    var roles = AppData.db.Role.ToList();
                    LVShort.ItemsSource = roles;
                    break;
                case TableName.Models:
                    var models = AppData.db.Models.ToList();
                    LVShort.ItemsSource = models;
                    break;
                case TableName.Providers:
                    var providers = AppData.db.Providers.ToList();
                    LVShort.ItemsSource = providers;
                    break;
                default:
                    MessageBox.Show("Ошибка");
                    break;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (currentTable)
            {
                case TableName.Categories:
                    var currentCategories = button.DataContext as Categories;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, currentCategories));
                    break;
                case TableName.Role:
                    var currentRole = button.DataContext as Role;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, null, currentRole));
                    break;
                case TableName.Models:
                    var currentModels = button.DataContext as Models;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, null, null, currentModels));
                    break;
                case TableName.Providers:
                    var currentProviders = button.DataContext as Providers;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, null, null, null, currentProviders));
                    break;
                default:
                    break;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                switch (currentTable)
                {
                    case TableName.Categories:
                        var currentCategories = (sender as Button).DataContext as Categories;
                        AppData.db.Categories.Remove(currentCategories);
                        break;
                    case TableName.Role:
                        var currentRole = (sender as Button).DataContext as Role;
                        AppData.db.Role.Remove(currentRole);
                        break;
                    case TableName.Models:
                        var currentModels = (sender as Button).DataContext as Models;
                        AppData.db.Models.Remove(currentModels);
                        break;
                    case TableName.Providers:
                        var currentProviders = (sender as Button).DataContext as Providers;
                        AppData.db.Providers.Remove(currentProviders);
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                Update();
            }
        }
    }
}
