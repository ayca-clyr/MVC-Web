using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Social
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string GitHub { get; set; }

        public virtual People People { get; set; }
    }
}
