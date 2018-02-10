
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopOnline.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order=1)]
        public string OrderID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { set; get; }

        public int Quantity { set; get; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

    }
}
