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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Policy;


namespace ladashopq.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditTovarsPage.xaml
    /// </summary>
    public partial class AddEditTovarsPage : Page
    {
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Resources\");
        public string selectefFileName;
        public string extension = "";
        public Tovars currentTovar;

        public AddEditTovarsPage()
        {
            InitializeComponent();
            this.WindowTitle = "Добавление товара";
            var category = AppData.db.Categories.Select(r => r.CategoryName).ToList();
            TBCategory.ItemsSource = category;
            var model = AppData.db.Models.Select(r => r.ModelName).ToList();
            TBModel.ItemsSource = model;
            var provider = AppData.db.Providers.Select(r => r.Provider).ToList();
            TBProvider.ItemsSource = provider;
        }

        public AddEditTovarsPage(Tovars ct)
        {
            InitializeComponent();

            currentTovar = ct;

            TBProductName.Text = currentTovar.ProductName;
            TBArticle.Text = Convert.ToString(currentTovar.Article);
            TBDescription.Text = currentTovar.Description;
            TBCategory.SelectedItem = currentTovar.Categories.CategoryName;
            TBModel.SelectedItem = currentTovar.Models.ModelName;
            TBProvider.SelectedItem = currentTovar.Providers.Provider;
            TBCount.Text = Convert.ToString(currentTovar.Count);
            TBPrice.Text = Convert.ToString(currentTovar.Price);

            this.WindowTitle = "Добавление товара";
            var category = AppData.db.Categories.Select(r => r.CategoryName).ToList();
            TBCategory.ItemsSource = category;
            var model = AppData.db.Models.Select(r => r.ModelName).ToList();
            TBModel.ItemsSource = model;
            var provider = AppData.db.Providers.Select(r => r.Provider).ToList();
            TBProvider.ItemsSource = provider;
        }


        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Фото | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                img = Path.GetFileName(ofd.FileName);
                extension = Path.GetExtension(img);
                selectefFileName = ofd.FileName;
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImagePFP.Source = new ImageSourceConverter()
                    .ConvertFrom(_mainImageData) as ImageSource;
            }
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var category = AppData.db.Categories.Where(a => a.CategoryName == TBCategory.SelectedItem.ToString()).FirstOrDefault();
            var model = AppData.db.Models.Where(a => a.ModelName == TBModel.SelectedItem.ToString()).FirstOrDefault();
            var provider = AppData.db.Providers.Where(a => a.Provider == TBProvider.SelectedItem.ToString()).FirstOrDefault();

            if (img != null)
            {
                img = TBArticle.Text + extension;
                var files = Directory.GetFiles(path);
                int a = 0;
                while (File.Exists(path + img))
                {
                    a++;
                    img = TBArticle.Text + $" ({a})" + extension;
                }
                path = path + img;
                File.Copy(selectefFileName, path);
            }
            else if (currentTovar.Img != null)
            {
                img = currentTovar.Img;
            }


            if (currentTovar == null)
            {


                Tovars tovar = new Tovars()
                {
                    Article = Int32.Parse(TBArticle.Text),
                    ProductName = TBProductName.Text,
                    Description = TBDescription.Text,
                    CategoryID = category.ID,
                    ModeID = model.ID,
                    ProviderID = provider.ID,
                    Count = Int32.Parse(TBCount.Text),
                    Price = Int32.Parse(TBPrice.Text),
                    Img = img
                };
                AppData.db.Tovars.Add(tovar);
                AppData.db.SaveChanges();
                MessageBox.Show("Товар успешно добавлен!");
                NavigationService.GoBack();
            }
            else
            {
                currentTovar.Img = img;
                currentTovar.Article = Int32.Parse(TBArticle.Text);
                currentTovar.ProductName = TBProductName.Text;
                currentTovar.Description = TBDescription.Text;
                currentTovar.CategoryID = category.ID;
                currentTovar.ModeID = model.ID;
                currentTovar.ProviderID = provider.ID;
                AppData.db.SaveChanges();
                MessageBox.Show("Товар успешно обновлен!");
                currentTovar = null;
            }
            NavigationService.Navigate(new TovarsAdmin());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуться назад?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }
    }
}

