using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProjectTask
    {
        [Required]
        public int ID { get; set; }

        public int ProjectID { get; set; }
        public int Status { get; set; }
        public int AssignedToUserID { get; set; }

        [Required]
        public string Detail { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}