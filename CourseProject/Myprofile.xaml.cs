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

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Myprofile.xaml
    /// </summary>
    public partial class Myprofile : Window
    {
        CPEntities DB = new CPEntities();
        User u;
        public Myprofile(User u1)
        {
            InitializeComponent();
            name.Text = u1.name;
            surname.Text = u1.surname;
            tel.Text = u1.phone;
            email.Text = u1.email;
            u = u1;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string md5 = Login.CreateMD5(oldpassw.Password);
            List < User > users = new List<User>(DB.User.Where(x => x.userPassword == md5 && x.userName == u.userName));
            if (users.Count > 0)
            {
               User uu= DB.User.Find(u.idUser);
                uu.name = name.Text;
                uu.surname = surname.Text;
                uu.phone = tel.Text;
                uu.email = email.Text;
                if (newpassw.Password != "")
                {
                    if (newpassw.Password != newpassw2.Password)
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                    else
                    {
                        uu.userPassword = Login.CreateMD5(newpassw.Password);
                    }
                }
                DB.SaveChanges();
                Close();
                
            }
            else
            {
                MessageBox.Show("Введите старый пароль");
            }
        }
    }
}
