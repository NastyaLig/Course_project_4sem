using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{

    class UserStat:User
    {
        public int msg { get; set; }
        public int contacts { get; set; }
        public UserStat(User u)
        {
            idUser = u.idUser;
            name = u.name;
            userName = u.userName;
            surname = u.surname;
            phone = u.phone;
            email = u.email;
            comment = u.comment;
            isAdmin = u.isAdmin;
            DateTime dt = DateTime.Now.AddDays(-1);
            CPEntities DB = new CPEntities();
            msg = DB.Messages.Where(x => x.time > dt).Count(x => x.idSender == idUser);
            contacts = DB.Contact.Where(x => x.date > dt).Count(x => x.idUser == idUser);
            needHelp = u.needHelp;
        }
    }
    
}
