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
    
    public partial class Randevu
    {
        public int Id { get; set; }
        public string LoginTC { get; set; }
        public Nullable<int> Hastane_Klinik_Id { get; set; }
        public Nullable<int> DoktorId { get; set; }
        public Nullable<int> RandevuSaatiId { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public bool Durum { get; set; }
    
        public virtual Doktor Doktor { get; set; }
        public virtual Login Login { get; set; }
        public virtual RandevuSaati RandevuSaati { get; set; }
    }
}