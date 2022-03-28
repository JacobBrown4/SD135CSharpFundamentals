using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_APIs.Models
{
    public class SearchResult<T> // Also wants a type when constructed
    {
        public int Count { get; set; }

        // Using that passed through type for this property.
        public List<T> Results { get; set; } = new List<T>();

    }
}
