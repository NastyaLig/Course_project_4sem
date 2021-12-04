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
    /// Логика взаимодействия для Group.xaml
    /// </summary>
    public partial class Group : Window
    {
        CPEntities DB = new CPEntities();
        User u1;
        public Group(User u)
        {
            InitializeComponent();
            u1 = u;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string s = Search.Text;
            List<User> users = new List<User>(DB.User.Where(x => (x.email.StartsWith(s) || x.phone.StartsWith(s) || x.name.StartsWith(s) || x.surname.StartsWith(s) || x.userName.StartsWith(s))));
            Result.Children.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                UserButton b = new UserButton(users[i]);
                b.username.Click += (sender1, e1) => {
                    UserButton b2 = new UserButton(b.u);
                    Members.Children.Add(b2);
                    b2.username.Click += (sender2, e2) => { Members.Children.Remove(b2); };
                };
                Result.Children.Add(b);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            User nu = new User();
            nu.name = Namegr.Text;
            nu.isGroup = 1;
            nu.surname = " ";
            DB.User.Add(nu);
            for(int i =0; i<Members.Children.Count; i++)
            {
                Contact c1 = new Contact();
                c1.date = DateTime.Now;
                c1.idUser = ((UserButton)Members.Children[i]).u.idUser;
                c1.idUserContact = nu.idUser;
                DB.Contact.Add(c1);
                Contact c2 = new Contact();
                c2.date = DateTime.Now;
                c2.idUser = nu.idUser;
                c2.idUserContact = ((UserButton)Members.Children[i]).u.idUser;
                DB.Contact.Add(c2);
            }
            Contact c3 = new Contact();
            c3.date = DateTime.Now;
            c3.idUser = u1.idUser;
            c3.idUserContact = nu.idUser;
            DB.Contact.Add(c3);
            Contact c4 = new Contact();
            c4.date = DateTime.Now;
            c4.idUser = nu.idUser;
            c4.idUserContact = u1.idUser;
            DB.Contact.Add(c4);
            DB.SaveChanges();
            Close();
        }

        private void Search_TextChanged()
        {

        }
    }
}
