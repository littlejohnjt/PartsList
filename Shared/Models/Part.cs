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

        public string? Units { get; set; }

        public string? OrganizationId { get; set; }

        public string? Nomenclature { get; set; }
        
        public string? Description { get; set; }

        public string? Specification { get; set; }

        /// <summary>
        /// IsDiscontinued - has this part been discontinued.
        /// </summary>
        public bool? IsDiscontinued { get; set; }

        public string? PartUri { get; set; }

        public string? Notes { get; set; }

        /// <summary>
        /// IsReplacementFor - if a part has been discontinued the
        /// current part will link to the part this is a replacement for.
        /// </summary>
        public virtual Part? IsReplacementFor { get; set; }

        public int? ISReplacementForPartId { get; set; }

        /// <summary>
        /// Vendors - a list of vendors that can supply this part.
        /// </summary>
        public virtual IList<Vendor>? Vendors { get; set; }
    }
}
