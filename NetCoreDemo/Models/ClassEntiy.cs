using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Models
{
    public class ClassEntiy
    {

        public int ID { get; set; }

        public string ClassName { get; set; }


        public virtual ICollection<Student> Students { get; set; }

    }
}
