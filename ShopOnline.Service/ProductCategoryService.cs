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
        //Tìm kiếm vs getall thông thường luôn . khỏi cần tách ra func search riêng chi 
        IEnumerable<ProductCategory> GetAll(string keyWord);

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

        public void Update(ProductCategory productCategory)
        {
             _productCategoryRepository.Update(productCategory);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();

        }
        public IEnumerable<ProductCategory> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            }
            else
            {
                return _productCategoryRepository.GetAll();
            }

        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pagesize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pagesize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }


    }
}
