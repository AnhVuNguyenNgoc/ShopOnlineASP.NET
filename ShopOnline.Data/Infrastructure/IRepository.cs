using System;
using System.Linq;
using System.Linq.Expressions;

namespace ShopOnline.Data.Infrastructure
{
    /*
     Một nơi duy nhất để thay đổi quyền truy cập dữ liệu cũng như xử lý dữ liệu.
    Một nơi duy nhất chịu trách nhiệm cho việc mapping các bảng vào object.
    Tăng tính bảo mật và rõ ràng cho code.
    Rất dễ dàng để thay thế một Repository với một implementation giả cho việc testing, vì vậy bạn không cần chuẩn bị một cơ sở dữ liệu có sẵn.
     */
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        T Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        T Delete(T entity);

        // Marks an entity to be removed
        T Delete(int id);

      
        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);// Func<> DELEGATE

        // Get an entity by int id
        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IQueryable<T> GetAll(string[] includes = null);

        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
