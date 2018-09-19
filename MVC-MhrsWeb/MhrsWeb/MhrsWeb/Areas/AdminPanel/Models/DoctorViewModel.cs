using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Areas.AdminPanel.Models
{
    public class DoctorViewModel
    {
        public Doktor doktor = new Doktor();
        public List<Cinsiyet> cinsiyetList;
        public List<Klinik> klinikList;
        public List<Hastane> hastaneList;
    }
}