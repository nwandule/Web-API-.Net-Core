using Demo_App.Model.Domain;

namespace Demo_App.Repositories
{
    public interface IProductRep
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> CreateAsync(Product product);

    }
}
