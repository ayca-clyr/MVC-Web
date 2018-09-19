using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Technology
    {
        public Technology()
        {
            Projects_Technologies = new HashSet<Project_Technology>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project_Technology> Projects_Technologies { get; set; }

    }
}
