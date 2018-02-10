using ShopOnline.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory : Auditable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int? ParentID { get; set; }
        public int? DisplayOrder { set; get; }//nullable

        [MaxLength(256)]
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
