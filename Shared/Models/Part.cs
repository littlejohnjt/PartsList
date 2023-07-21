using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        public string? Location { get; set; }

        public string? RefDes { get; set; }

        public int Quantity { get; set; }

        public string? Units { get; set; }

        public string? OrganizationId { get; set; }

        public string? Nomenclature { get; set; }
        
        public string? Description { get; set; }

        public string? Specification { get; set; }

        public bool? IsDiscontinued { get; set; }

        public string? PartUri { get; set; }

        public string? Notes { get; set; }

        public Part? IsReplacementFor { get; set; }

        public IList<Vendor>? Vendors { get; set; }

        public IList<Part>? Parts { get; set; }

        public Part? ParentPart { get; set; }

        public decimal? UnitPrice { get; set; }

        [NotMapped]
        public decimal? TotalQuantityPrice { get => Quantity * UnitPrice; }
    }
}
