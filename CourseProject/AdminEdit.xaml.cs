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
    /// Логика взаимодействия для AdminEdit.xaml
    /// </summary>
    public partial class AdminEdit : Window
    {
        CPEntities DB = new CPEntities();
        User u;
        public AdminEdit(User u1)
        {
            InitializeComponent();
            u = u1;
            admin.Text = u.isAdmin.ToString();
            login.Text = u.userName;
            name.Text = u.name;
            surname.Text = u.surname;
            tel.Text = u.phone;
            email.Text = u.email;
            comment.Text = u.comment;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User nu = DB.User.Find(u.idUser);
            if (admin.Text!="") {
                nu.isAdmin = byte.Parse(admin.Text);
            }
            nu.userName = login.Text;
            nu.name = name.Text;
            nu.surname = surname.Text;
            nu.phone = tel.Text;
            nu.email = email.Text;
            nu.comment = comment.Text;
            if (password.Text != "")
            {
                nu.userPassword = Login.CreateMD5(password.Text);

            }
            nu.needHelp = 0;
            DB.SaveChanges();
            Close();
        }
    }
}
