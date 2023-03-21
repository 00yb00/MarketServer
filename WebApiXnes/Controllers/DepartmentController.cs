using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Model.models;
using Entities;
namespace WebApiXnes.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        public DepartmentController()
        {
        }
        [HttpGet("GetDepartment")]
        public JsonResult getDepartment()
        {
            List<Department> departmentList = new List<Department>();
            DepratmentEntities depratmentEntities = new DepratmentEntities();
            departmentList=depratmentEntities.GetDepartmentsEntities();
            return new JsonResult(departmentList);
        }
        [HttpPost("PostDepartment")]
        public JsonResult postDepartment(Department dep)
        {
            DepratmentEntities depratmentEntities = new DepratmentEntities();
            string message=depratmentEntities.AddDepartmentEntities(dep);
            return new JsonResult(message);
        }
        [HttpPut("PutDepartment")]
        public JsonResult putDepartment(Department dep)
        {

            DepratmentEntities depratmentEntities = new DepratmentEntities();
            string message = depratmentEntities.PutDepartmentEntities(dep);
            return new JsonResult(message);
        }
        [HttpDelete("DeleteDepartment/{id}")]
        public JsonResult deleteDepartment(int id)
        {
            DepratmentEntities depratmentEntities = new DepratmentEntities();
            string message = depratmentEntities.DeleteDepartmentEntities(id);
            return new JsonResult(message);
        }
    }
}
