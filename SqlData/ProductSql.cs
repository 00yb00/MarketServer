using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dal;
namespace SqlData
{
    public class ProductSql
    {

        public ProductSql()
        {

        }
        public DataTable GetProductsSql()
        {
            DataTable tbl = new DataTable();
            try
            {
                string query = @"exec getAllproduct";
                SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return null;
            }

            return tbl;
        }
        public DataTable GetViewProductsSql()
        {
            DataTable tbl = new DataTable();
            try
            {
                string query = @"exec getAllproductView";
                SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return null;
            }

            return tbl;
        }
        public string AddProductSql(Product prod)
        {
            try
            {
                DataTable tbl = new DataTable();
                string query = $"exec addProduct '{prod.name}','{prod.price}','{prod.amount}','{ prod.departmentId}'";
                SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }

            return "Success from AddProduct";

        }
        public string PutproductSql(Product prod)
        {
            try
            {
                DataTable tbl = new DataTable();
                string query = $"exec updateProduct '{prod.id}','{prod.name}','{prod.price}','{prod.amount}','{ prod.departmentId}'";
                SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }

            return "Success from AddProduct";

        
        }
            public string DeleteproductSql(int id)
            {
            try
            {
                DataTable tbl = new DataTable();
                string query = $"exec deleteProduct '{id}'";
                SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "Success from DeleteProduct";
            }
    }
}
