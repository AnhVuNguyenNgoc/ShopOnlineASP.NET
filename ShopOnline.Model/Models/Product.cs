using ShopOnline.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ShopOnline.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName="xml")]
        public string MoreImages { get; set; } //XML KHONG CHIU xELEMENT

        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public string Content { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public bool? ViewCount { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategories { get; set; }

        //public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
