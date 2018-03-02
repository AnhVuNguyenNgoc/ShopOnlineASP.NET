using ShopOnline.Data.Infrastructure;
using ShopOnline.Data.Repository;
using ShopOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        void Delete(int id);
        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAllPaging(int page, int pagesize, out int totalRow);
        ProductCategory GetById(int id);
        IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pagesize, out int totalRow);
        void SaveChanges();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWork _unitOfWork;

       //Dependency Injecttion by AutoFac
        //
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        //Muốn làm gì thì làm dưới này,
        //Qua Interface đề inject by IproductCateforyService not productCategoryService implement

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryRepository.Add(productCategory);
        }

        public void Update(ProductCategory product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pagesize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pagesize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
