using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _161116_EmployeeManagement.EF.Entities
{
    // İsimlendirilmiş int değerler
    public enum Gender  // : int kalıtım alıyor.
    {
        [Display(Name = "Kadın")]   // Enum'ları Türkçe yapıyor. Display Ekle.
        Female,
        [Display(Name = "Erkek")]
        Male
    }
}
