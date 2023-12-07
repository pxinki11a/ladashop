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
    /// Логика взаимодействия для AddEditShortPages.xaml
    /// </summary>
    public partial class AddEditShortPages : Page
    {
        public TableName currentTable;
        public string itemName;
        public Role role;
        public Categories category;
        public Models models;
        public Providers providers;
        public bool addOrEditFlag = false;
        public AddEditShortPages(TableName tn)
        {
            InitializeComponent();
            this.WindowTitle = "Добавление";
            currentTable = tn;
            addOrEditFlag = true;

            switch (currentTable)
            {
                case TableName.Categories:
                    this.WindowTitle = "Добавление категорий";
                    TBName.Text = "Категория:";
                    break;
                case TableName.Role:
                    this.WindowTitle = "Добавление ролей";
                    TBName.Text = "Роль:";
                    break;
                case TableName.Models:
                    this.WindowTitle = "Добавление моделей";
                    TBName.Text = "Модель:";
                    break;
                case TableName.Providers:
                    this.WindowTitle = "Добавление поставщиков";
                    TBName.Text = "Поставщик:";
                    break;
                default:
                    break;
            }
        }

        public AddEditShortPages(TableName tn, Categories ctg = null, Role rl = null, Models mdl = null, Providers prvd = null)
        {
            this.currentTable = tn;
            addOrEditFlag = false;

            this.category = ctg;
            this.role = rl;
            this.models = mdl;
            this.providers = prvd;
            InitializeComponent();

            switch (currentTable)
            {
                case TableName.Categories:
                    this.WindowTitle = "Редактирование категорий";
                    TBName.Text = "Категории:";
                    TBShortName.Text = category.CategoryName;
                    break;
                case TableName.Role:
                    this.WindowTitle = "Редактирование ролей";
                    TBName.Text = "Роль:";
                    TBShortName.Text = role.RoleName;
                    break;
                case TableName.Models:
                    this.WindowTitle = "Редактирование моделей";
                    TBName.Text = "Модель:";
                    TBShortName.Text = models.ModelName;
                    break;
                case TableName.Providers:
                    this.WindowTitle = "Редактирование поставщиков";
                    TBName.Text = "Поставщик:";
                    TBShortName.Text = providers.Provider;
                    break;
                default:
                    break;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (addOrEditFlag)
            {
                switch (currentTable)
                {
                    case TableName.Categories:
                        Categories categories = new Categories()
                        {
                            CategoryName = TBShortName.Text,
                        };
                        AppData.db.Categories.Add(categories);
                        break;
                    case TableName.Role:
                        Role role = new Role()
                        {
                            RoleName = TBShortName.Text,
                        };
                        AppData.db.Role.Add(role);
                        break;
                    case TableName.Models:
                        Models models = new Models()
                        {
                            ModelName = TBShortName.Text,
                        };
                        AppData.db.Models.Add(models);
                        break;
                    case TableName.Providers:
                        Providers providers = new Providers()
                        {
                            Provider = TBShortName.Text,
                        };
                        AppData.db.Providers.Add(providers);
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена в таблицу!");
            }
            else
            {
                switch (currentTable)
                {
                    case TableName.Categories:
                        category.CategoryName = TBShortName.Text;
                        break;
                    case TableName.Role:
                        role.RoleName = TBShortName.Text;
                        break;
                    case TableName.Models:
                        models.ModelName = TBShortName.Text;
                        break;
                    case TableName.Providers:
                        providers.Provider = TBShortName.Text;
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно изменена");
            }
            NavigationService.Navigate(new ShortPage(currentTable));
        }
    }
}
