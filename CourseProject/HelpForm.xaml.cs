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
    /// Логика взаимодействия для HelpForm.xaml
    /// </summary>
    public partial class HelpForm : Window
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CPEntities DB = new CPEntities();
            List<User> users = new List<User>(DB.User.Where(x=> x.userName == Login.Text&& x.phone ==phone.Text&&x.email==email.Text));
            if (users.Count == 1)
            {
                DB.User.Find(users[0].idUser).needHelp=1;
                DB.SaveChanges();
                MessageBox.Show("Ожидайте звонка администратора");
                Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
