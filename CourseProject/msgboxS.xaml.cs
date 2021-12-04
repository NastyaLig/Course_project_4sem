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
using System.IO;
using System.Diagnostics;


namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для msgbox.xaml
    /// </summary>
    public partial class msgboxS : UserControl
    {
        CPEntities DB = new CPEntities();
        Messages m;
        public msgboxS(Messages m1)
        {
            InitializeComponent();
            m = m1;
            tb.Text = m.message;
            if (m.Attachment.Count > 0)
            {
                b.Content = m.Attachment.First().filename;
            }
            else
            {
                b.Visibility = Visibility.Collapsed;
            }
            time.Content = m.time.Value.ToShortDateString()+" "+m.time.Value.ToShortTimeString();
            namemes.Content = m.User.name + " " + m.User.surname+"->" + m.User1.name + " "+ m.User1.surname;
           
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllBytes(m.Attachment.First().filename, m.Attachment.First().attachment1);
            Process p = new Process();
            p.StartInfo.FileName = m.Attachment.First().filename;
            p.Start();
        }
        
    }
}
