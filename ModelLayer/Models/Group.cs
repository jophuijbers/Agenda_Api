using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelLayer.Models
{
    public class Group
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<User> Users { get; set; }
    }
}
