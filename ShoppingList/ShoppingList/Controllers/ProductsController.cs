using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Data.Entities;
using ShoppingList.Models.Products;

namespace ShoppingList.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext data;

        public ProductsController(ApplicationDbContext data)
        {
            this.data = data;
        }


        //GET: ProductsController/Create
        public IActionResult Create()
        {
            return View();
        }
        //POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateVM model)
        {
            var product = new Product()
            {
                ProductName = model.ProductName,

            };
            this.data.Products.Add(product);
            data.SaveChanges();
            return RedirectToAction("Index");

        }
        //GET: ProductsController
        public IActionResult Index()
        {
            var products = data.Products
                .Select(x => new ProductListVM()
                {
                    Id = x.Id,
                    ProductName = x.ProductName
                })
                .ToList();
            return View(products);
        }

    }
}
