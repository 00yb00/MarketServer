using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.models;
using System.Data;
using SqlData;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class ProductEntities
    {
        public ProductSql productSql { get; set; }


        public ProductEntities()
        {
            productSql=new ProductSql();
        }

        public List<Product> GetProductsEntities()
        {
         return convertToProduct(productSql.GetProductsSql());
        }
        public string AddProductEntities(Product prod)
        {

            return productSql.AddProductSql(prod);
        }
        public string PutProductEntities(Product prod)
        {

            return productSql.PutproductSql(prod);
        }
        public string DeleteProductEntities(int id)
        {

            return productSql.DeleteproductSql(id);
        }
        public List<Product> convertToProduct(DataTable dtbl)
        {
            List<Product> prods = new List<Product>();
            if (dtbl.Rows.Count > 0)
            {
                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                    Product prod = new Product();
                    prod.name = dtbl.Rows[i]["productName"].ToString();
                    prod.price = Convert.ToDouble(dtbl.Rows[i]["price"]);
                    prod.amount = Convert.ToInt32(dtbl.Rows[i]["amount"]);
                    prod.departmentName = dtbl.Rows[i]["departmentName"].ToString();
                    prod.id = Convert.ToInt32(dtbl.Rows[i]["id"]);
                    prods.Add(prod);
                }
            }
            return prods;

        }
    }
}
