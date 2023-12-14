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
            //var currentApplications = (sender as Button).DataContext as Applications;
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

            var tovars = AppData.db.Tovars.ToList();
            switch (Sort.SelectedIndex)
            {
                case 0:
                    tovars = tovars.OrderBy(t => t.ProductName).ToList();
                    break;
                case 1:
                    tovars = tovars.OrderByDescending(t => t.ProductName).ToList();
                    break;
                case 2:
                    tovars = tovars.OrderBy(t => t.Price).ToList();
                    break;
                case 3:
                    tovars = tovars.OrderByDescending(t => t.Price).ToList();
                    break;
                default:
                    break;
            }
            
            tovars = tovars.Where(t => t.ProductName.ToLower().Contains(txtSearch.Text.ToLower()) || t.Description.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            var amount = AppData.db.Tovars.ToList().Count;
            if (tovars.Count == 0)
            {
                resultbox.Text = "По вашему запросу ничего не найдено";
            }
            else
            {
                resultbox.Text = $"Найдено {tovars.Count} товара из {amount}";
            }
            LVTovarsAdmin.ItemsSource = null;
            LVTovarsAdmin.ItemsSource = tovars;
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void LVTovarsAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }

 }

