﻿
namespace ShopOnline.Data.Infrastructure
{

    //internal is for assembly scope (i.e. only accessible from code in the same .exe or .dll)

    //Để có ví dụ, bạn hay tạo 2 project dạng Class Library. Cái thứ nhất khai báo một biến internal, cái thứ nhất khia báo một biến public (kiểu biến và giá trị thì tùy bạn, không quan trọng).
    //Xong buid chúng ra dll.
    //Tạo một project thứ 3, khai báo tham chiếu để dùng cả hai cái dll ở trên. Bạn sẽ thấy truy cập được biến trong project thứ 2, mà không truy cập được biến trong project thứ nhất.
    
    
    //dbContext generated by DbFactory.Init()
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopOnlineDbContext dbContext;

        public ShopOnlineDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopOnlineDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();//Dispose() in dbContext
        }
    }
}