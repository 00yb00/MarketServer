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
    public class DepartmentSql
    {


        public DepartmentSql()
        {

        }
        public DataTable GetDepartmentsSql()
        {
            DataTable tbl = new DataTable();
            try
            {
            string query = @"exec getAllDepartment";
            SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
               return null; 
            }
            
            return tbl; 
        }
        public string AddDepartmentSql(Department dep)
        {   
            try
            { 
            DataTable tbl = new DataTable();
            string query = $"exec addDepartment '{dep.name}','{dep.descrption}'";
            SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            
            return "Success from AddDepartment";
        }
        public string PutDepartmentSql(Department dep)
        {
            try
            {
            DataTable tbl = new DataTable();
            string query = $"exec updateDepartment '{dep.id}','{dep.name}','{dep.descrption}'";
            SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "Success from PostDepartment";
        }
        public string DeleteDepartmentSql(int id)
        {
            try
            {
            DataTable tbl = new DataTable();
            string query = $"exec deleteDepartment '{id}'";
            SqlQuery.RunCommand(query, tbl.Load);
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "Success from DeleteDepartment";
        }
    }
}
