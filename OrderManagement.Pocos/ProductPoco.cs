using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderManagement.Pocos
{
    [Table("Product")]
    public class ProductPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Product_Name")]
        public string ProductName { get; set; }

        [Column("Product_Quantity")]
        public int ProductQuantity { get; set; }

        [ForeignKey("OrderID")]
        public virtual ICollection<OrderPoco> Orders { get; set; }
    }
}
