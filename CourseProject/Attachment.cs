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
    
    public partial class Attachment
    {
        public int id { get; set; }
        public int idMessage { get; set; }
        public byte[] attachment1 { get; set; }
        public string filename { get; set; }
    
        public virtual Messages Messages { get; set; }
    }
}