using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace AspCoreEve.Models
{
    public class Catagory
    {[Key]
        public int Cid { get; set; }

        [Required]
        public string CatagoryName { get; set; }
        public virtual IList<BusInformation> BusInformation { get; set; }

    }
}
