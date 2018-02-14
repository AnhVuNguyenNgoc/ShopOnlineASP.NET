using ShopOnline.Service;
using ShopOnline.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopOnline.Web.API
{
     [RoutePrefix("API/Product")]
    public class ProductController : ApiControllerBase
    {
         IProductService _productService;

         public ProductController(IErrorService errorService, IProductService productService)
             : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listProduct = _productService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProduct);

                return response;
            });
        }
    }
}
