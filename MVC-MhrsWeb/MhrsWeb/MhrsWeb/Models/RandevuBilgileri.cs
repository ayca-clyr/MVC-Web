using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Models
{
    public class RandevuBilgileri
    {
        public DoktorModel Doktor { get; set; }
        public string RandevuTarihi { get; set; }
        public string Hastane { get; set; }
        public string Klinik { get; set; }
    }
}