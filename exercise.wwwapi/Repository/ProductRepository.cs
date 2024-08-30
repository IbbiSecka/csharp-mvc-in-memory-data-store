using exercise.wwwapi.Data;
using exercise.wwwapi.Model;

namespace exercise.wwwapi.Repository
{
    public class ProductRepository : IRepository
    {
        private DataContext _db;
        public ProductRepository(DataContext db)
        {
            _db = db;
        }
        public Product AddProd(Product entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public List<Product> DeleteProd(int id)
        {
            _db.Remove(id);
            _db.SaveChanges();
            return _db.prods.ToList();
        }

        public Product GetProdById(int id)
        {
            
            return _db.prods.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts(string category)
        {
            return _db.prods.Where(p => p.Category == category).ToList();
        }

        public Product UpdateProd(Product newProd, int id)
        {
            var existingProd = _db.prods.FirstOrDefault(p => p.Id == id);
                existingProd.Name = newProd.Name;
                existingProd.Category = newProd.Category;
                existingProd.Price = newProd.Price;
            _db.SaveChanges();
            return existingProd;
        }
       
        
    }
}
