using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        public string? Name{ get; set; }

        public string? Website { get; set; }

        public string? PocName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }

        /// <summary>
        /// CageCode - the vendor's CAGE code
        /// </summary>
        public string? CageCode { get; set; }

        /// <summary>
        /// Parts - a list of parts supplied by this vendor
        /// </summary>
        public virtual IList<Part>? Parts { get; set; }
    }
}
