using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Project
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}