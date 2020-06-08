using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelLayer.Models
{
    public class Event
    {
        public int? Id { get; set; }
        public int? User_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //[NotMapped]
        //public string StartString { get; set; }
        //[NotMapped]
        //public string EndString { get; set; }

        public string Start { get; set; }
        public string End { get; set; }
    }
}
