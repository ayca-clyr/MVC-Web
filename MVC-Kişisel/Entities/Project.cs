using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Project
    {
        public Project()
        {
            Project_Technologies = new HashSet<Project_Technology>();
        }
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public int CategoryId { get; set; }
        public string Link { get; set; }



        public virtual Image Image { get; set; }
        public virtual People People { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Project_Technology> Project_Technologies { get; set; }

    }
}
