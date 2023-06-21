using Demo_App.Data;
using Demo_App.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Repositories
{
    public class SqlProductRep : IProductRep
    {
        private readonly DemoDbContext dbContext;
        public SqlProductRep(DemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
           await dbContext.AddAsync(product);
           await dbContext.SaveChangesAsync();
           return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var Products=await dbContext.Products.ToListAsync();
            return Products;
        }
    }
}
