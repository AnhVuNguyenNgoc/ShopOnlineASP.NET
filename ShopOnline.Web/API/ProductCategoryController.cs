using AutoMapper;
using ShopOnline.Model.Models;
using ShopOnline.Service;
using ShopOnline.Web.Infrastructure.Core;
using ShopOnline.Web.Infrastructure.Extensions;
using ShopOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace ShopOnline.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase //Để lấy hàm CreateResponse có bắt lỗi logerror á mà 
    {
        IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService, IErrorService errorService)
            : base(errorService)
        {
            _productCategoryService = productCategoryService;
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAllParents(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listProductCategory = _productCategoryService.GetAll();

                var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(listProductCategory);

                HttpResponseMessage repsonse = request.CreateResponse(HttpStatusCode.OK, listProductCategoryViewModel); ;

                return repsonse;
            }
        );
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyWord, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var listProductCategory = _productCategoryService.GetAll(keyWord);

                totalRow = listProductCategory.Count();

                var query = listProductCategory.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);


                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    TotalRows = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = listProductCategoryViewModel,
                    Page = page

                };

                HttpResponseMessage repsonse = request.CreateResponse(HttpStatusCode.OK, paginationSet); ;
                return repsonse;
            }
             );
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var listProductCategory = _productCategoryService.GetById(id);

                var listProductCategoryViewModel = Mapper.Map<ProductCategory, ProductCategoryViewModel>(listProductCategory);

                HttpResponseMessage repsonse = request.CreateResponse(HttpStatusCode.OK, listProductCategoryViewModel);

                return repsonse;
            }
             );
        }


        //[AcceptVerbs("GET","POST")]
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        //khỏi phải có authen mới vào 
        public HttpResponseMessage post(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCategory = new ProductCategory();

                    newProductCategory.UpdateProductCategory(productCategoryViewModel);

                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.SaveChanges();

                    var DataResponse = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, DataResponse);
                }
                return response;
            }
            );
        }


        [AcceptVerbs("GET", "POST", "PUT")]
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        //khỏi phải có authen mới vào 
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategoryService.GetById(productCategoryViewModel.ID);

                    dbProductCategory.UpdateProductCategory(productCategoryViewModel);
                    dbProductCategory.UpdatedDate = DateTime.Now;


                    _productCategoryService.Update(dbProductCategory);
                    _productCategoryService.SaveChanges();

                    var DataResponse = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, DataResponse);
                }
                return response;
            }
            );
        }

         [AcceptVerbs("GET", "POST", "PUT")]
        [Route("delete")]
        [HttpDelete]
        //[AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductCategory = _productCategoryService.Delete(id);

                    _productCategoryService.SaveChanges();

                    var DataResponse = Mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProductCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, DataResponse);
                }
                return response;
            }
            );
        }

         [AcceptVerbs("GET", "POST", "PUT")]

         [Route("deletemulti")]
         [HttpDelete]
         //[AllowAnonymous]
         public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)//json
         {
             return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (!ModelState.IsValid)
                 {
                     response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     var listProductCategories = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);

                     foreach (var id in listProductCategories)
                     {
                         var oldProductCategory = _productCategoryService.Delete(id);
                     }
                 
                     _productCategoryService.SaveChanges();

                     response = request.CreateResponse(HttpStatusCode.Created, listProductCategories.Count);
                 }
                 return response;
             }
             );
         }

    }
}
