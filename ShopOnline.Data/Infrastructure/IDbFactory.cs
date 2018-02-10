using System;

namespace ShopOnline.Data.Infrastructure
{
    //to generate entity in database 

    //why we could : IDisposable
    public interface IDbFactory : IDisposable
    {
        //WHERE INIT() FUNTION COME FROM???????????

        //my bads : i'm forget this is interface
        ShopOnlineDbContext Init();
    }
}
