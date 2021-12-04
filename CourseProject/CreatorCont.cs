using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseProject
{
    class CreatorCont : Creator
    {
        public override Control FactoryMethod(object info)
        {
            return new UserButton((User)info);
        }
    }
}
