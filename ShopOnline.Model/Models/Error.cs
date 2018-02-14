
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShopOnline.Model.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ID { set; get; }

        public string Message { get; set; }

        public string StackTrace { get; set; } //??????????????

        public DateTime CreatedDate { get; set; }
    }
}
