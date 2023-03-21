using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public string descrption { get; set; }
        public Department()
        {
                
        }
        public Department(int id, string name, string descrption)
        {
            this.id = id;
            this.name = name;
            this.descrption = descrption;
        }
    }
}
