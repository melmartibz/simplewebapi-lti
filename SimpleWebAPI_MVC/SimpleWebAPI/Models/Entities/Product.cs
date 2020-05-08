using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models.Entities
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
