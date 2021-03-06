﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kisisel.Areas.AdminPanel.Models
{
    public class ProjectUpdateModel
    {
        public ProjectUpdateModel()
        {
            categoryList = new List<Category>();
            technologyList = new List<Technology>();
        }
        public Project project { get; set; }
        public List<Category> categoryList { get; set; }
        public List<Technology> technologyList { get; set; }

    }
}