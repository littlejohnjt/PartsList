using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class ComponentAssembly
    {
        [Key]
        public int Id { get; set; }

        public IList<InventoryItem>? Items { get; set; }

        public string? Number { get; set; }

        public string? Name { get; set; }

        public string? CageCode { get; set; }
        
        public string? Version { get; set; }
    }
}
