using Microsoft.Win32;
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
using System.IO;

namespace ladashopq.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditTovarsPage.xaml
    /// </summary>
    public partial class AddEditTovarsPage : Page
    {
        Tovars tovars = new Tovars();
        private byte[] image = null;

        public AddEditTovarsPage(Tovars _tovars)
        {
            InitializeComponent();

            if (_tovars != null)
            {
                tovars = _tovars;
            }
            DataContext = tovars;

            ComboTech.ItemsSource = App.autoshop.Tovars.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуться назад?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.png; *.avif; *.jpeg; *.jpg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                image = File.ReadAllBytes(openFileDialog.FileName);
                TechImage.Source = new ImageSourceConverter().ConvertFrom(image) as ImageSource;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
