using exercise.wwwapi.Model;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public  class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options)
        {
            
        }
        public DbSet <Product> prods { get; set; }
    }
}
        //private static List<Product> _prods = new List<Product>();
        //public static List<Product> getProds() { 
        //    return _prods;
        
        //}
        //public static Product getProd(int id) {
            
        //    return _prods.FirstOrDefault(p => p.Id == id);
        //}
        //public static List<Product> DeleteProd(int id) {
        //    _prods.RemoveAll(p => p.Id == id);
        //    return _prods;
        //}
        //public static List<Product> AddProd(Product prod) { 
        //    if (!_prods.Contains(prod)) 
        //    _prods.Add(prod);
        //    return _prods;
        //}
        //public static Product UpdateProd(Product prod, int id) {
            
        //    if (_prods.Contains(prod))
        //        prod.Id = id;

        //    return prod;

        //}