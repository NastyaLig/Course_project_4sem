//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public int idUserContact { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
