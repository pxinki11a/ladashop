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

namespace ladashopq
{
    /// <summary>
    /// Логика взаимодействия для WindowAuth.xaml
    /// </summary>
    public partial class WindowAuth : Window
    {
        public WindowAuth()
        {
            InitializeComponent();

            AppFrame.frameAuth = AuthFrame;

        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = AppData.db.Users.FirstOrDefault((User) => User.Login == TBLogin.Text && User.Password == TBPassword.Password);

                if (currentUser == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");
                }
                else
                {
                    if (currentUser.Login.Equals(TBLogin.Text) && currentUser.Password.Equals(TBPassword.Password))
                    {
                        if (currentUser.RoleID == 1)
                        {
                            AdminWindow admin = new AdminWindow(); //currentUser.userID
                            admin.Show();
                        }
                        else
                        {
                            UserWindow userWindow = new UserWindow();
                            userWindow.Show();
                        }
                        Window.GetWindow(this).Close();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные логин и пароль", "Ошибка авторизации");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString());
            }

        }

        

        private void TBLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AuthFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void BtnSignInGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guest = new GuestWindow();
            guest.Show();
            Window.GetWindow(this).Close();
        }
    }
}

