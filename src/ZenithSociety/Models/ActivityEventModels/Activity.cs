using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithSociety.Models.ActivityEventModels
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Event> Event { get; set; }
    }
}
