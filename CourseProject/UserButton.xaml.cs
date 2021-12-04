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

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для UserButton.xaml
    /// </summary>
    public partial class UserButton : UserControl
    {
        CPEntities DB = new CPEntities();
       public User u;
        public UserButton(User u1)
        {
            InitializeComponent();
            u = u1;
            username.Content = u.surname + " " + u.name;
            if (u.isGroup == 1)
            {
                status.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            }
          else if(  DB.Session.Where(x => x.idUser == u.idUser).Count()>0)
            {
                status.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            }
            else
            {
                status.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }
        
    }
}
