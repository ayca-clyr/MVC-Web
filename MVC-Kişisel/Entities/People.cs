using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class People
    {
        public People()
        {
            Socials = new HashSet<Social>();
            Skills = new HashSet<Skill>();
            Educations = new HashSet<Education>();
            Works = new HashSet<Work>();
            Projects = new HashSet<Project>();


        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public DateTime Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ImageId { get; set; }
        
        public virtual ICollection<Social> Socials { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Work> Works { get; set; }
        public virtual ICollection<Project> Projects { get; set; }


    }
}
