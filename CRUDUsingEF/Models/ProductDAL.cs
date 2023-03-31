using CRUDUsingEF.Data;

namespace CRUDUsingEF.Models
{
    public class ProductDAL
    {

        private readonly ApplicationDbContext db;
        public ProductDAL (ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return db.products.ToList();
        }
        public Product GetProductById(int id)
        {
            var prod = db.products.Find(id);
            return prod;
        }

        public int AddProduct(Product prod)
        {
            db.products.Add(prod);
            int result = db.SaveChanges();
            return result;
        }

        public int UpdateProduct(Product prod)
        {
            int result = 0;
            var p = db.products.Where(x => x.Id == prod.Id).FirstOrDefault();

            if (p != null)
            {
                p.Name= prod.Name;
                p.Price= prod.Price;
                result= db.SaveChanges();
            }

            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var p = db.products.Where(x=>x.Id== id).FirstOrDefault();

            if (p != null)
            {
                db.products.Remove(p);
                result=db.SaveChanges();

            }
            return result;
        }

        internal object GetAllProduct(object id)
        {
            throw new NotImplementedException();
        }
    }
}
