//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebForms_Uygulama.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public Patient()
        {
            this.Appointments = new HashSet<Appointment>();
        }
    
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentitiyNumber { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long CellPhone { get; set; }
        public long HomePhone { get; set; }
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public bool Deleted { get; set; }
        public string Picture { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual PatientLogin PatientLogin { get; set; }
    }
}
