using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BCRS.Models
{
    public class Company : IIdentifiable
    {
        [Required]
        public int Id { get; set; }
        
        //[DataType(DataType.ImageUrl)]
        public String logo { get; set; }

        [Required]
        public string Name { get; set; }
        public int Owner { get; set; }

        [ForeignKey("Owner")]
        public User User { get; set; }
    }
}