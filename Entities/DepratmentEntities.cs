using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlData;
using Model.models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

namespace Entities
{
    public class DepratmentEntities
    {
        public DepartmentSql departmentSql { get; set; }

        public DepratmentEntities()
        {
            departmentSql = new DepartmentSql();
        }

        public List<Department> GetDepartmentsEntities()
        {
            return convertToDepartment(departmentSql.GetDepartmentsSql());
        }
        public string AddDepartmentEntities(Department dep)
        {
           return departmentSql.AddDepartmentSql(dep);
        }
        public string PutDepartmentEntities(Department dep)
        {

            return departmentSql.PutDepartmentSql(dep);
        }
        public string DeleteDepartmentEntities(int id)
        {

            return departmentSql.DeleteDepartmentSql(id);
        }
        public List<Department> convertToDepartment(DataTable dtbl)
        {
            List < Department >deps=new List<Department>(); 
            if (dtbl.Rows.Count > 0)
            {
                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                    Department dep = new Department();
                    dep.name = dtbl.Rows[i]["departmentName"].ToString();
                    dep.descrption = dtbl.Rows[i]["descrption"].ToString();
                    dep.id = Convert.ToInt32(dtbl.Rows[i]["id"]);
                    deps.Add(dep);
                }
            }
            return deps;

        }
    }
}
