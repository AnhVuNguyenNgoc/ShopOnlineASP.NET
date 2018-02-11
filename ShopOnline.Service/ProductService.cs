
using ShopOnline.Data.Infrastructure;
using ShopOnline.Data.Repository;
using ShopOnline.Model.Models;
using System.Collections.Generic;
using System.Linq;


namespace ShopOnline.Service
{
    interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllPaging(int page,int pagesize,int totalRow);
        Product GetById(int id);
        IEnumerable<Product> GetAllByTagPaging(int tag, int page, int pagesize, int totalRow);
        void SaveChanges();

    }
    public class ProductService :IProductService
    {
         IProductRepository _productRepository;
         IUnitOfWork _unitOfWork;

         public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
         {
             this._productRepository = productRepository;
             this._unitOfWork = unitOfWork;
         }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll(new string[] { "ProductCategories" });
        }

        public IEnumerable<Product> GetAllPaging(int page, int pagesize, int totalRow)
        {
            throw new System.NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        //public IEnumerable<Product> GetAllByTagPaging(int tag, int page, int pagesize, int totalRow)
        //{
        //    return _productRepository.GetMultiPaging(x => x.Status && x.Post );
        //}

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
