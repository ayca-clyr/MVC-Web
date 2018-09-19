using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MhrsWeb.Areas.AdminPanel.Models
{
    public class RandevuSaatiViewModel
    {
        public Doktor doktor;
        public List<RandvuSaati_Doktor> doktorSaatTarihList;
        public List<RandevuSaati> randevuSaatleri;
        public string secilenRandevuTarihi;
        public List<DateTime> tarihListesi15;
    }
}