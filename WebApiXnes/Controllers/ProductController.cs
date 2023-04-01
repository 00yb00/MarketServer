using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Model.models;
using Entities;
namespace WebApiXnes.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
           
        }
        [HttpGet("GetProduct")]
        public JsonResult getProduct()
        {
            List<Product> productList = new List<Product>();
            ProductEntities productEntities = new ProductEntities();
            productList = productEntities.GetProductsEntities();
            return new JsonResult(productList);
        }
        [HttpGet("GetProductVeiw")]

        public JsonResult getViewProduct()
        {
            List<ViewProduct> productList = new List<ViewProduct>();
            ProductEntities productEntities = new ProductEntities();
            productList = productEntities.GetViewProductsEntities();
            return new JsonResult(productList);
        }
        [HttpPost("PostProduct")]
        public JsonResult postProduct(Product prod)
        {
            ProductEntities productEntities = new ProductEntities();
             string message=productEntities.AddProductEntities(prod);
            return new JsonResult(message);
        }
        [HttpPut("PutProduct")]
        public JsonResult putProduct(Product prod)
        {
            ProductEntities productEntities = new ProductEntities();
            string message = productEntities.PutProductEntities(prod);
            return new JsonResult(message);
        }
        [HttpDelete("DeleteProduct/{id}")]
        public JsonResult deleteProduct(int id)
        {
            ProductEntities productEntities = new ProductEntities();
            string message = productEntities.DeleteProductEntities(id);
            return new JsonResult(message);
        }
    }
}
