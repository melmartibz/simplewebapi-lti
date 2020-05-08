
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMVC.Models.Entities
{
    public class Product
    {
        public Guid ID { get; set; }
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
