﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Areas.AdminPanel.Models
{
    public class KullaniciBilgileriModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}