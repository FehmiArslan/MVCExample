using _01_ViewModel.Data;
using _01_ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_ViewModel.Controllers
{
    public class ProductController : Controller
    {
       

        [HttpGet]
        public ActionResult Index()
        {
           
            ProductListViewModel model = new ProductListViewModel();
            model.Products = FakeDatabaseOparation.products;


           

            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            EditProductViewModel model = new EditProductViewModel
            {
                Product = null,
                AllCategories = FakeDatabaseOparation.categories

            };

          
            ViewData["Patlangacs"] = FakeDatabaseOparation.patlangacs;
            ViewBag.title = "Yeni Ürün";


            return View("/Views/Product/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult New(Product product, List<int> PatlangacValue)
        {
            

            FakeDatabaseOparation.addProduct(product, PatlangacValue);
            return Redirect("/Product/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
          
            EditProductViewModel model = new EditProductViewModel
            {
                Product = FakeDatabaseOparation.getProductByID(id),
                AllCategories = FakeDatabaseOparation.categories
            };

            ViewData["Patlangacs"] = FakeDatabaseOparation.patlangacs;
            ViewBag.title = "Ürün Güncelle";
            
            return View(model);
        }

        
      
       

        
        public ActionResult Edit(Product product, List<int> PatlangacValue)
        {
            FakeDatabaseOparation.updateProduct(product, PatlangacValue);

           
            return RedirectToAction("Index", "Product");

        }
       
        public ActionResult Delete_Yontem1()
        {
            int id = Convert.ToInt32(Request.QueryString["productid"]);
            string name = Request.QueryString["name"].ToString();

            FakeDatabaseOparation.deleteProduct(id);

            return Redirect("/Product/Index");

        }

        
        public ActionResult Delete(int productid, string name)
        {
            
            FakeDatabaseOparation.deleteProduct(productid);

            return Redirect("/Product/Index");

        }

    }
}