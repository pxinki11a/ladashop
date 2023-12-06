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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public TableName currentTable;
        public AdminWindow()
        {
            InitializeComponent();
            SelectTable.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTable = (TableName)SelectTable.SelectedIndex;
            switch (currentTable)
            {
                case TableName.Categories:
                    MainFrame.Navigate(new Views.ShortPage(TableName.Categories));
                    break;
                case TableName.Role:
                    MainFrame.Navigate(new Views.ShortPage(TableName.Role));
                    break;
                case TableName.Models:
                    _ = MainFrame.Navigate(new Views.ShortPage(TableName.Models));
                    break;
                case TableName.Providers:
                    MainFrame.Navigate(new Views.ShortPage(TableName.Providers));
                    break;
                case TableName.Users:
                    MainFrame.Navigate(new Views.UsersPage());
                    break;
                case TableName.Tovar:
                    MainFrame.Navigate(new Views.TovarsPage());
                    break;
                default:
                    break;
            }
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
