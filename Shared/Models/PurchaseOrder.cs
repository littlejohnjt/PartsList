using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }

        public IList<PurchaseLineItem>? LineItems { get; set; }

        public Vendor? Vendor { get; set; }

        public int? VendorId { get; set; }

        public decimal? ShippingCost { get; set; }

        [NotMapped]
        public decimal? TotalPurchaseOrderCost
        { 
            get
            {
                if (LineItems == null) return 0.0m;

                return LineItems.Sum(li => li.TotalQuantityPriceWithTax) + ShippingCost;
            }
        }
    }
}
