

namespace ShopOnline.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;

        private ShopOnlineDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        //getter
        public ShopOnlineDbContext DbContext
        {
            //this is the most important code line

            get { return dbContext ?? (dbContext = dbFactory.Init()); }

        }


        //from interface IunitofWork
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
