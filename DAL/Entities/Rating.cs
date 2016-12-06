using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCRS.Models
{
    public class Rating : IIdentifiable
    { 
        [Required]
        public int Id { get; set; }

        [Required]
        public int Mark { get; set; }
        public int UserId { get; set; }

        [Required]
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}