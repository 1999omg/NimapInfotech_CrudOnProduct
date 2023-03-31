using CRUDUsingEF.Data;
using CRUDUsingEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingEF.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly ApplicationDbContext db;
        ProductDAL productDAL;
        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
            productDAL = new ProductDAL(db);
        }

        public ActionResult Index()
        {
            var list = productDAL.GetAllProduct();

            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var prod = productDAL.GetProductById(id);
            return View(prod);
        }

        // GET: ProductController/Create
        public ActionResult Create(int id )
        {
            var prod = productDAL.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                int result = productDAL.AddProduct(prod);
                if (result == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = productDAL.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod )
        {
            try
            {
                int result = productDAL.UpdateProduct(prod);
                if (result == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = productDAL.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id )
        {
            try
            {
                int result = productDAL.DeleteProduct(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
