﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }
        [Required]
        [MaxLength(256)]
        public string CustomerAddress { set; get; }
        [Required]
        [MaxLength(256)]
        public string CustomerEmail { set; get; }
        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }
        [Required]
        [MaxLength(256)]
        public string CustomerMessage { set; get; }
        public DateTime? CreatedDate { set; get; }
        [MaxLength(50)]
        public string CreatedBy { set; get; }
         [MaxLength(256)]
        public string PaymentMethod { set; get; }
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
