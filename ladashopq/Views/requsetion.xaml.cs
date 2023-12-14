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
using System.Security.Cryptography;
using System.Xml.Linq;


namespace ladashopq.Views
{
    /// <summary>
    /// Логика взаимодействия для requsetion.xaml
    /// </summary>
    public partial class requsetion : Page
    {

        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Resources\");
        public string selectefFileName;
        public string extension = "";
        public Tovars currentTovar;
        public Applications currentApplication;

        public requsetion()
        {
            InitializeComponent();
            var status = AppData.db.Status.Select(p => p.StatusName).ToList();
            TBvibor.ItemsSource = status;
        }

        private void TBvibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public requsetion(Tovars tovars)
        {
            currentTovar = tovars;
            InitializeComponent();
            this.WindowTitle = "Редактирование товара";
            TBArticle.Text = currentTovar.Article.ToString();
            TBProductName.Text = currentTovar.ProductName;
            TBPrice.Text = currentTovar.Price.ToString();
            TBDescription.Text = currentTovar.Description;
            TBCategory.Text = currentTovar.Categories.CategoryName;
            TBModel.Text = currentTovar.Models.ModelName;
            TBCount.Text = currentTovar.Count.ToString();
            TBProvider.Text = currentTovar.Providers.Provider;
            if (currentTovar.Img != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentTovar.Img);
                tovarimg.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }
            this.WindowTitle = "Добавление товара";
            var status = AppData.db.Status.Select(p => p.StatusName).ToList();
            TBvibor.ItemsSource = status;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userwnd = new UserWindow();
            userwnd.Show();
            Window.GetWindow(this).Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var status = AppData.db.Status.Where(a => a.StatusName == TBvibor.SelectedItem.ToString()).FirstOrDefault();

            if (currentApplication == null)
            {
                Applications application = new Applications()
                {

                    ArticleID = Int32.Parse(TBArticle.Text),
                    StatusID = status.ID,
                    UsersID = AppData.CurrentUser.ID

                };
                AppData.db.Applications.Add(application);
                AppData.db.SaveChanges();
                MessageBox.Show("Заявка создана!");
            }
            else
            {
                currentApplication.ArticleID = Int32.Parse(TBArticle.Text);
                currentApplication.StatusID = status.ID;
                AppData.db.SaveChanges();
                MessageBox.Show("Заявка обновлена!");
                currentApplication = null;
            }
            UserWindow userwnd = new UserWindow();
            userwnd.Show();
            Window.GetWindow(this).Close();
        }
    }
}
