using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Work
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string DateOfStart { get; set; }
        public string DateOfEnd { get; set; }

        public virtual People People { get; set; }
    }
}
