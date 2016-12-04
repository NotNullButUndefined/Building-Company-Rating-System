using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCRS.Models
{
    public class Building
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public double TotalRating { get; set; }

        [Required]
        public DateTime FoundationDate { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    
    }
}