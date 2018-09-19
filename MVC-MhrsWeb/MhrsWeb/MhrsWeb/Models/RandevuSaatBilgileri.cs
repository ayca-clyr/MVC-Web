using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Models
{
    public class RandevuSaatBilgileri
    {
        public int RandevuSaatId { get; set; }
        public string saat { get; set; }
        public Nullable<bool> Durum { get; set; }
    }
}