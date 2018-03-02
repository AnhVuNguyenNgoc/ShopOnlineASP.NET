using AutoMapper;
using ShopOnline.Model.Models;
using ShopOnline.Web.Models;

namespace ShopOnline.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();

            //không createMap sao nó mapper dc 
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();

            //Mapper.CreateMap<ProductTag, ProductTagViewModel>();
        }
    }
}