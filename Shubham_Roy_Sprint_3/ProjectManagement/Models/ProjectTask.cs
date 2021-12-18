using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ProjectManagement.Models
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
