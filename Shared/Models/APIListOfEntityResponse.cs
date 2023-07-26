using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsList.Shared.Models
{
    public class APIListOfEntityResponse<TEntity> where TEntity : class
    {
        public bool Success { get; set; }

        public List<string> ErrorMEssage { get; set; } = new List<string>();

        public IEnumerable<TEntity> Data { get; set;}
    }
}
