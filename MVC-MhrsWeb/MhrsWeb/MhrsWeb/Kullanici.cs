//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MhrsWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanici
    {
        public string TC { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CinsiyetId { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> CommandId { get; set; }
        public string Email { get; set; }
    
        public virtual Cinsiyet Cinsiyet { get; set; }
        public virtual Command Command { get; set; }
        public virtual Login Login { get; set; }
    }
}
