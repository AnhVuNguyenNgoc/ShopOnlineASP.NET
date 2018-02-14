using ShopOnline.Data.Infrastructure;
using ShopOnline.Data.Repository;
using ShopOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ShopOnline.Service
{
    public interface IErrorService
    {
        void Create(Error error);
        void Save();
    }

    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Error error)
        {
            _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
