using ShopOnline.Data.Infrastructure;
using ShopOnline.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnline.Data.Repository
{
    //nghiep vu moi thi them vao interface nay 
    public interface IProductRepository
    {
        IEnumerable<Product> GetAlias(string alias);
    }

    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<Product> GetAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias);
        }
    }
}
