using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kisisel.Models
{
    public class PageModel
    {
        public PageModel()
        {
            categoryList = new List<Category>();
        }
        public People people { get; set; }
        public Image profilImage { get; set; }
        public List<Category> categoryList { get; set; }

    }
}