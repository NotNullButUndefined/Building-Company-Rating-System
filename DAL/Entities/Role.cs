using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCRS.Models
{
    public class Role : IIdentifiable
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}