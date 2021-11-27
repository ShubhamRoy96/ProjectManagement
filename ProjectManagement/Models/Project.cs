using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class Project
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Detail { get; set; }        
        internal DateTime CreatedOn { get; set; }
    }
}
