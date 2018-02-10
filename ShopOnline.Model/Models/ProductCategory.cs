using ShopOnline.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }

        public string Description { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { set; get; }//nullable
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
