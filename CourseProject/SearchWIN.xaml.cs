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
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class SearchWIN : Window
    {
        CPEntities DB = new CPEntities();
        User u1;
        CreatorS c3 = new CreatorS();
        public SearchWIN(User u)
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
            List<Messages> messages = new List<Messages>();
            List<Contact> users = new List<Contact>(DB.Contact.Where(x => x.idUser == u1.idUser));
        for(int i = 0; i< users.Count; i++)
            {
                int idusercontact = users[i].idUserContact;
                List<Messages> messages1;
                if (users[i].User1.isGroup == 1)
                {
                     messages1 = new List<Messages>(DB.Messages.Where(x=>x.idResiver ==idusercontact));
                }
                else
                {
                     messages1 = new List<Messages>(DB.Messages.Where(x=>x.idSender==u1.idUser && x.idResiver ==idusercontact ||
                    x.idSender==idusercontact && x.idResiver==u1.idUser));
                }
                for (int g = 0; g < messages1.Count; g++)
                {
                    if (messages1[g].message.ToLower().Contains(text.Text.ToLower()))
                    {
                        messages.Add(messages1[g]);
                    }
                }
            }

            Stack.Children.Clear();
            messages = new List<Messages>(messages.OrderByDescending(x => x.time));
            for(int i=0; i < messages.Count; i++)
            {
                Stack.Children.Add( c3.FactoryMethod(messages[i]));
            }
        }
    }
}
