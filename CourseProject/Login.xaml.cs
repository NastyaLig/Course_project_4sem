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
using System.Security.Cryptography;
namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
       public static CPEntities DB = new CPEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string md5 = CreateMD5(Password.Password);
            List<User> userlist = new List<User>(DB.User.Where(x => x.userName == Login1.Text && x.userPassword == md5&& x.isGroup!=1));
           if (userlist.Count>0)
            {
                Session s = new Session();
                s.idUser = userlist[0].idUser;
                s.sessionHash = CreateMD5(DateTime.Now.ToString());
                DB.Session.Add(s);
                DB.SaveChanges();
                if (userlist[0].isAdmin != 1)
                {
                    MessagesWin m = new MessagesWin(s);
                    m.ShowDialog();
                }
                else
                {
                    AdminWin admin = new AdminWin();
                    admin.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.ShowDialog();
        }

        private void Login1_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }
    
    private void Password_GotFocus(object sender, RoutedEventArgs e)
    {
        passw.Visibility = Visibility.Hidden;
    }

    private void passw_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Password.Focus();
    }
    }
}
