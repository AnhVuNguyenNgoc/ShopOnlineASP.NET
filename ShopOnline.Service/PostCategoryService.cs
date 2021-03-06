﻿
using ShopOnline.Data.Infrastructure;
using ShopOnline.Data.Repository;
using ShopOnline.Model.Models;
using System.Collections.Generic;

namespace ShopOnline.Service
{
   public interface IPostCategoryService
    {
    
        PostCategory Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);
       
        void SaveChanges();
    }    

   public class PostCategoryService :IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;

        IUnitOfWork _unitOfWork;


        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }


        public PostCategory Add(PostCategory postCategory)
        {
           return _postCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }


        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
