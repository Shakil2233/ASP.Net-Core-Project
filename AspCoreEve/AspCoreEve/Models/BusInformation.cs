using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEve.Models
{
    public class BusInformation
    {
        [Key]
        public int Id { get; set; }
        public string Bus_Name { get; set; }
        public bool SitAvailable { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime BookingDate { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
       
        public int Cid { get; set; }
        [ForeignKey("Cid")]
        public Catagory Catagory { get; set; }
    }
}
