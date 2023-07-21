using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class Vendor
    {
        public string? Name{ get; set; }

        public string? Website { get; set; }

        public string? Poc { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }

        public string? CageCode { get; set; }

        public IList<Part>? Parts { get; set; }
    }
}
