using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Models
{
    public class RandevuAraModel
    {
        public Nullable<DateTime> Tarih { get; set; }
        public Nullable<int> SehirId { get; set; }
        public Nullable<int> IlceId { get; set; }
        public Nullable<int> HastaneId { get; set; }
        public Nullable<int> KlinikId { get; set; }
        public Nullable<int> DoktorId { get; set; }
    }
}