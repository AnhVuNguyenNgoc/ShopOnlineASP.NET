﻿

using ShopOnline.Data.Infrastructure;
using ShopOnline.Model.Models;
namespace ShopOnline.Data.Repository
{
    public interface IErrorRepository : IRepository<Error>
    {
       
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
      
    }
}
