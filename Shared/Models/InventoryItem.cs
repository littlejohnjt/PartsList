using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        public Part? Part { get; set; }

        public int? Quantity { get; set; }

        public string? SerialNumber { get; set; }

        public ComponentAssembly? ComponentAssembly { get; set; }

        public int ComponentAssemblyId { get; set; }
    }
}
