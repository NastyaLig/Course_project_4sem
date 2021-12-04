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
using System.Text.RegularExpressions;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Window.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        CPEntities DB = new CPEntities();
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            List<User> users = new List<User>(DB.User.Where(x => x.userName == Login1.Text));
            if (users.Count != 0)
            {
                str += "Имя пользователя уже занято\n";
            }
            if (Password.Password != Password2.Password)
            {
                str += "Ваши пароли не совпадают\n";
            }
            Regex re = new Regex("[+]{1}\\d{12}");
            if (!re.IsMatch(Telephone.Text))
            {
                str += "Неправильный формат телефона\n";
            }
            Regex re2 = new Regex("^([a-z0-9_-]+\\.)*[a-z0-9_-]+@[a-z0-9_-]+(\\.[a-z0-9_-]+)*\\.[a-z]{2,6}$");
            if (!re2.IsMatch(Email.Text))
            {
                str += "Неправильно введён email\n";
            }
            Regex re3 = new Regex("\\D{2,50}");
            if (!re3.IsMatch(Name.Text))
            {
                str += "В имени не должно быть цифр\n";
            }
            if (!re3.IsMatch(Surname.Text))
            {
                str += "В фамилии не должно быть цифр\n";
            }
            if (str == "")
            {
                User u = new User();
                u.email = Email.Text;
                u.name = Name.Text;
                u.phone = Telephone.Text;
                u.surname = Surname.Text;
                u.userName = Login1.Text;
                u.userPassword = Login.CreateMD5(Password.Password);
                DB.User.Add(u);
                DB.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show(str);
            }
        }

        private void Telephone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login1_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void Telephone_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void Surname_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            passw.Visibility = Visibility.Hidden;
        }

        private void passw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Password.Focus();
        }
        private void Password2_GotFocus(object sender, RoutedEventArgs e)
        {
            passw2.Visibility = Visibility.Hidden;
        }

        private void passw2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Password2.Focus();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
