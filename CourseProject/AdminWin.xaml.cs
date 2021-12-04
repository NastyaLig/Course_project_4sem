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
    /// Логика взаимодействия для AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        
        List<UserStat> userStats;
        public AdminWin()
        {
            InitializeComponent();
            refresh();

        }
        void refresh()
        {
            CPEntities DB = new CPEntities();
            List<User> users = new List<User>(DB.User);
            userStats = new List<UserStat>();
            for (int i = 0; i < users.Count; i++)
            {
                UserStat us = new UserStat(users[i]);
                userStats.Add(us);
            }
            dg.ItemsSource = userStats;
            dg.Items.Refresh();
          
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CPEntities DB = new CPEntities();
            if (dg.SelectedItems.Count == 1)
            {
                AdminEdit adminEdit = new AdminEdit(DB.User.Find(((UserStat)dg.SelectedItem).idUser));
                adminEdit.ShowDialog();
                refresh();
            }
            else
            {
                MessageBox.Show("Выберите одного пользователя для редактирования");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CPEntities DB = new CPEntities();
            if (dg.SelectedItems.Count == 1)
            {
                User u = DB.User.Find(((UserStat)dg.SelectedItem).idUser);
                List<Contact> contacts = new List<Contact>(DB.Contact.Where(x => x.idUser == u.idUser || x.idUserContact == u.idUser));
                    for(int i =0; i < contacts.Count; i++)
                {
                    DB.Contact.Remove(DB.Contact.Find(contacts[i].id));
                }
                List<Messages> messages = new List<Messages>(DB.Messages.Where(x => x.idSender == u.idUser || x.idResiver == u.idUser));
                for(int i = 0; i < messages.Count; i++)
                {
                    int id = messages[i].id;
                    List<Attachment> attachments = new List<Attachment>(DB.Attachment.Where(x => x.idMessage == id));
                    for(int g = 0; g < attachments.Count; g++)
                    {
                        DB.Attachment.Remove(DB.Attachment.Find(attachments[g].id));

                    }
                    DB.Messages.Remove(DB.Messages.Find(messages[i].id));
                }

                List<Session> sessions = new List<Session>(DB.Session.Where(x => x.idUser == u.idUser));
                for(int i = 0; i < sessions.Count; i++)
                {
                    DB.Session.Remove(DB.Session.Find(sessions[i].id));
                }
               
                DB.User.Remove (DB.User.Find(((UserStat)dg.SelectedItem).idUser));
                DB.SaveChanges();
                refresh();
            }
            else
            {
                MessageBox.Show("Выберите одного пользователя для удаления");
            }
        }
    }
}
