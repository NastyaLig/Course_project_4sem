using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
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
    /// Логика взаимодействия для edit.xaml
    /// </summary>
    public partial class edit : Window
    {
      
        Messages m;
        public edit(Messages m1)
        {
            InitializeComponent();
            m = m1;
            tb.Text = m.message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Messages um = new Messages();
            um.time = m.time;
            um.idSender = m.idSender;
            um.idResiver = m.idResiver;
            um.status = m.status;
            um.message = tb.Text;
            Login.DB.Messages.Add(um);
            Login.DB.Messages.Remove(Login.DB.Messages.Find(m.id));
            Login.DB.SaveChanges();
            Close();
            

        }
    }
}
