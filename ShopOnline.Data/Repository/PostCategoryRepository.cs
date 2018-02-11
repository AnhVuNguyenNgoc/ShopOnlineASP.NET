﻿
using ShopOnline.Data.Infrastructure;
using ShopOnline.Model.Models;
namespace ShopOnline.Data.Repository
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {

    }

    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }

    }
}
