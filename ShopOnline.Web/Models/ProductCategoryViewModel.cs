using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Web.Models
{
    public class ProductCategoryViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { set; get; }//nullable
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }


        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }
}