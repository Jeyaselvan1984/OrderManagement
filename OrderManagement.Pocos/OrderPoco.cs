using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace OrderManagement.Pocos
{
    [Table("Orders")]
    public class OrderPoco : IPoco

    {
        [Key]
        public Guid Id { get; set; }

        [Column("Order_Date")]
        public DateTime OrderDate { get; set; }

        [Column("Product_Quantity")]
        public int ProductQuantity { get; set; }

        [ForeignKey("User_ID")]
        public ProductPoco Product { get; set; }
    }
}
