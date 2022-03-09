using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEve.Models
{
    public class CatagoryViewModel
    {
        public IEnumerable<Catagory> CatagoriVM { get; set; }
        public Catagory CatagoriEm { get; set; }
    }
}
