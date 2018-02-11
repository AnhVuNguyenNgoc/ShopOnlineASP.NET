

using ShopOnline.Data.Infrastructure;
using ShopOnline.Model.Models;
using System.Collections.Generic;
using System.Linq;


namespace ShopOnline.Data.Repository
{
    //quên public chỗ này cái không truy xuất từ ShopOnline.Service luôn


   public interface IPostRepository : IRepository<Post>
    {
       IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }


    //instead of implemanting alot of times from Irepository
    //we iherited from RepositoryBase
    public class PostRepository : RepositoryBase<Post>,IPostRepository
    {
        public PostRepository(IDbFactory DbFactory):base(DbFactory)
        {

        }

       public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize,out int totalRow)
        {
           var query= from p in DbContext.Posts
                     join pt in DbContext.PostTags
                     on p.ID equals pt.PostID  //equals nha . linq ko co == =
                     where pt.TagID == tag && p.Status
                     orderby p.CreatedDate descending
                      select p;

           totalRow = query.Count();

           query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

           return query;


        }
    }
}
