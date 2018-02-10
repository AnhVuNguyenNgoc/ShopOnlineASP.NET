
using ShopOnline.Data.Infrastructure;
using ShopOnline.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnline.Data.Repository
{
    //nghiep vu moi thi them vao interface nay 
   public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetAlias(string alias);
    }

   public class ProductCategoryRepository : RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
