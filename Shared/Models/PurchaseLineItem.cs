using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class PurchaseLineItem
    {
        [Key]
        public int Id { get; set; }

        public Part? Part { get; set; }

        public int PartId { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? Quantity { get; set; }

        [NotMapped]
        public decimal? TotalQuantityPrice { get { return Quantity * UnitPrice; } }

        public decimal? Tax { get; set; }

        [NotMapped]
        public decimal? TotalQuantityPriceWithTax { get { return Tax  + TotalQuantityPrice; } }

        public PurchaseOrder? AssociatedPurchaseOrder { get; set; }

        public int AssociatedPurchaseOrderId { get; set; }
    }
}
