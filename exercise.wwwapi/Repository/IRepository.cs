using exercise.wwwapi.Model;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        List<Product> GetProducts(string category);
        Product AddProd(Product entity);
        Product UpdateProd(Product prod,int id);
        List<Product> DeleteProd(int id);
        Product GetProdById(int id);
        List<Product> GetAllProds();
    }
}
