using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Models
{
    public class RandevuGecmisiModel
    {
        public int RandevuId { get; set; }
        public string DoktorFullName { get; set; }
        public string TarihVeSaat { get; set; }
        public string HastaneAdı { get; set; }
        public string KlinikAdı { get; set; }
        public Nullable<bool> RandevuDurumu { get; set; } 
    }
}