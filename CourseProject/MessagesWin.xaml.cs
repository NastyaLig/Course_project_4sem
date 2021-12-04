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
using Microsoft.Win32;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Threading;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Messages.xaml
    /// </summary>
    public partial class MessagesWin : Window
    {
        CPEntities DB = new CPEntities();

        
        User u1;
        User u2;
        DispatcherTimer t1;
        DispatcherTimer t2;
        CreatorCont c1 = new CreatorCont();
        CreatorMsg c2 = new CreatorMsg();

        public void refreshmsg(object o, EventArgs e)
        {
            if (u2 != null)
            {
                Message.Children.Clear();
                List<Messages> messages = new List<Messages>(DB.Messages.Where(
                    x => x.idSender == u1.idUser && x.idResiver == u2.idUser ||
                    x.idSender == u2.idUser && x.idResiver == u1.idUser||
                    x.idResiver==u2.idUser&&u2.isGroup==1).OrderBy(x=>x.time));
                for (int g = 0; g < messages.Count; g++)
                {

                    msgbox b2 = c2.FactoryMethod(messages[g]) as msgbox;
                    if (messages[g].idSender == u1.idUser)
                    {
                        b2.Margin = new Thickness(150, 10, 10, 10);
                        b2.Background = new SolidColorBrush(Color.FromRgb(77, 123, 148));
                    }
                    else
                    {
                        b2.edit.Visibility = Visibility.Collapsed;
                        b2.del.Visibility = Visibility.Collapsed;
                        b2.Margin = new Thickness(10, 10, 150, 10);
                        messages[g].status = "Прочитанно";
                        b2.Background = new SolidColorBrush(Color.FromRgb(171, 190, 200));
                    }
                    Message.Children.Add(b2);
                }
            }
        }   

        //public void refreshmsg2(object o)
        //{
        //    MessagesWin w = o as MessagesWin;
        //   w.Message.Children.Clear();
        //    List<Messages> messages = new List<Messages>(DB.Messages.Where(x => x.idSender == u1.idUser && x.idResiver == u2.idUser || x.idSender == u2.idUser && x.idResiver == u1.idUser));
        //    for (int g = 0; g < messages.Count; g++)
        //    {

        //        msgbox b2 = new msgbox(messages[g]);
        //        if (messages[g].idSender == u1.idUser)
        //        {
        //            b2.Margin = new Thickness(150, 10, 10, 10);
        //            b2.Background = new SolidColorBrush(Color.FromRgb(140, 130, 252));
        //        }
        //        else
        //        {
        //            b2.Margin = new Thickness(10, 10, 150, 10);
        //            messages[g].status = "Прочитанно";
        //            b2.Background = new SolidColorBrush(Color.FromRgb(182, 147, 254));
        //        }
        //       w.Message.Children.Add(b2);
        //    }
        //}
        void refreshcontact(object o, EventArgs e)
        {
            ContactW.Children.Clear();
            List<Contact> contacts = new List<Contact>(DB.Contact.Where(x => x.idUser == u1.idUser).OrderByDescending(x => x.date));
            for (int i = 0; i < contacts.Count; i++)
            {
                UserButton b = c1.FactoryMethod(contacts[i].User1) as UserButton;
                b.username. Click += (sender1, e1) => {
                    u2 = b.u;
                    contactname.Content = b.u.surname + " " + b.u.name;
                    
                    refreshmsg(this, new EventArgs());
                    t1 = new DispatcherTimer();
                    t1.Tick += new EventHandler(refreshmsg);
                    t1.Interval = new TimeSpan(0, 0, 5);
                    t1.Start();
                };
                ContactW.Children.Add(b);
            }
          
        }
        Session s1;
        public MessagesWin(Session s)

        { 
            InitializeComponent();
            User u = s.User;
            u1 = u;
            refreshcontact(this,new EventArgs());
            t2 = new DispatcherTimer();
            t2.Tick += new EventHandler(refreshcontact);
            t2.Interval = new TimeSpan(0, 0, 5);
            t2.Start();
            s1 = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = Search.Text;
            List<User> users = new List<User>(DB.User.Where(x => x.isAdmin!=1 &&(x.email.StartsWith(s) || x.phone.StartsWith(s) || x.name.StartsWith(s) || x.surname.StartsWith(s) || x.userName.StartsWith(s))));
            Result.Children.Clear();
            for(int i=0; i<users.Count; i++)
            {
                UserButton b = new UserButton(users[i]);
                b.username.Click += (sender1, e1) => {
                    u2 = b.u;
                    contactname.Content =b.u.surname + " " + b.u.name;
                    refreshmsg(this, new EventArgs());
                    t1 = new DispatcherTimer();
                    t1.Tick += new EventHandler(refreshmsg);
                    t1.Interval = new TimeSpan(0, 0, 5);
                    t1.Start();

                };
                Result.Children.Add(b);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CPEntities DB2 = new CPEntities();

            Messages nm = new Messages();
            nm.idSender = u1.idUser;
            nm.idResiver = u2.idUser;
            nm.message = NewMessage.Text;
            nm.status = "Отправлено";
            nm.time = DateTime.Now;
            DB2.Messages.Add(nm);
            DB2.SaveChanges();
            //msgbox b2 = new msgbox(nm);
            //b2.Margin = new Thickness(150, 10, 10, 10);
            //b2.Background = new SolidColorBrush(Color.FromRgb(205, 205, 219));
            //Message.Children.Add(b2);
            List<Contact> contacts = new List<Contact>(DB2.Contact.Where(x => x.idUser == u1.idUser && x.idUserContact == u2.idUser));
            if (contacts.Count > 0)
            {
                DB2.Contact.Find(contacts[0].id).date = DateTime.Now;
                Contact c = DB2.Contact.Where(x => x.idUserContact == u1.idUser && x.idUser == u2.idUser).First();
                c.date = DateTime.Now;
                DB2.SaveChanges();

            }
            else
            {
                Contact c1 = new Contact();
                c1.date = DateTime.Now;
                c1.idUser = u1.idUser;
                c1.idUserContact = u2.idUser;
                DB2.Contact.Add(c1);

                Contact c2 = new Contact();
                c2.date = DateTime.Now;
                c2.idUser = u2.idUser;
                c2.idUserContact = u1.idUser;
                DB2.Contact.Add(c2);
                DB2.SaveChanges();

                //UserButton b = new UserButton(u2);
               
                //b.username.Click += (sender1, e1) => {
                //    u2 = b.u;
                //    Message.Children.Clear();
                //    List<Messages> messages = new List<Messages>(DB.Messages.Where(x => x.idSender == u1.idUser && x.idResiver == u2.idUser || x.idSender == u2.idUser && x.idResiver == u1.idUser));
                //    for (int g = 0; g < messages.Count; g++)
                //    {
                //        Button b3 = new Button();
                //        b3.Content = messages[g].message;
                //        Message.Children.Add(b3);
                //        messages[g].status = "Прочитанно";
                //    }
                //};
                //ContactW.Children.Add(b);
            }
            if (filename != "")
            {
                Attachment a = new Attachment();
                a.filename = textattach.Text;
                a.idMessage = nm.id;
                a.attachment1 = File.ReadAllBytes(filename);
                DB2.Attachment.Add(a);
                DB2.SaveChanges();
                filename = "";
                textattach.Text = "";
            }
        }
        string filename = "";
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
           if( d.ShowDialog() == true)
            {
                textattach.Text = d.FileName.Substring(d.FileName.LastIndexOf('\\') + 1);
                filename = d.FileName;
                
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (u2 != null)
            {
                Profile p = new Profile(u2);
                p.ShowDialog();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Myprofile myprofile = new Myprofile(u1);
            myprofile.ShowDialog();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DB.Session.Remove(DB.Session.Find(s1.id));
            DB.SaveChanges();
        }

        private void Search_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void NewMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Group group = new Group(u1);
            group.ShowDialog();

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SearchWIN s = new SearchWIN(u1);
            s.ShowDialog();
        }
    }
}
