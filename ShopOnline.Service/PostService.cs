
using ShopOnline.Data.Infrastructure;
using ShopOnline.Data.Repository;
using ShopOnline.Model.Models;
using System.Collections.Generic;
using System.Linq;


namespace ShopOnline.Service
{
    public interface IPostService
    {
        Post Add(Post product);


        void Update(Post product);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pagesize,out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pagesize,out int totalRow);
        void SaveChanges();
    }

    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository,IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }


        public Post Add(Post product)
        {
            return _postRepository.Add(product);
        }

        public void Update(Post product)
        {
            _postRepository.Update(product);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

    
        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        //out because we dont know exacly the totalRow
        //we can define it inside function after query linq
        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: Select all post by tag
            // dont have parameter tag
            return _postRepository.GetAllByTag(tag,page,pageSize,out totalRow);

        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

      
    }
}
