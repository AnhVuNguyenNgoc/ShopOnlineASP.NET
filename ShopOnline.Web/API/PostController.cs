using ShopOnline.Model.Models;
using ShopOnline.Service;
using ShopOnline.Web.Infrastructure.Core;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopOnline.Web.API
{
     [RoutePrefix("API/Post")]
    public class PostController : ApiControllerBase
    {
        IPostService _postService;

       
        public PostController(IErrorService errorService, IPostService postService)
            : base(errorService)
        {
            this._postService = postService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request, Post post)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var _post = _postService.GetAll();

               response = request.CreateResponse(HttpStatusCode.OK, _post);

                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request,Post post)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if(ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
                }else
                {
                    var _post = _postService.Add(post);

                    _postService.SaveChanges();


                    response = request.CreateResponse(HttpStatusCode.Created, _post);
                }    


                return response;
            });
        }


        public HttpResponseMessage Put(HttpRequestMessage request, Post post)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postService.Update(post);

                    _postService.SaveChanges();


                    response = request.CreateResponse(HttpStatusCode.OK);
                }


                return response;
            });
        }


        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postService.Delete(id);

                    _postService.SaveChanges();


                    response = request.CreateResponse(HttpStatusCode.OK);
                }


                return response;
            });
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value,anhvu" };
        }
    }
}
