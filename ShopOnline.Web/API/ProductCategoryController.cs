using AutoMapper;
using ShopOnline.Model.Models;
using ShopOnline.Service;
using ShopOnline.Web.Infrastructure.Core;
using ShopOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopOnline.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase //Để lấy hàm CreateResponse có bắt lỗi logerror á mà 
    {
        IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService,IErrorService errorService)
            : base(errorService)
        {
            _productCategoryService = productCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
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
    }
}
