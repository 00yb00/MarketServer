using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public string departmentName { get; set; }
        public Product()
        {

        }
        public Product(int id, string name, double price, int amount, string departmentName)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.amount = amount;
            this.departmentName = departmentName;
        }
    }
}
