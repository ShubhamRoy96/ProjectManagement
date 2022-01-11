using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProjectTask : IEquatable<ProjectTask>
    {
        [Required]
        public int ID { get; set; }

        public int ProjectID { get; set; }
        public int Status { get; set; }
        public int AssignedToUserID { get; set; }

        [Required]
        public string Detail { get; set; }

        public DateTime CreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ProjectTask);
        }

        public bool Equals(ProjectTask other)
        {
            if (other == null)
                return false;

            return this.ID.Equals(other.ID)
                &&
                this.ProjectID.Equals(other.ProjectID)
                &&
                this.Status.Equals(other.Status)
                &&
                this.AssignedToUserID.Equals(other.AssignedToUserID)
                &&
                (
                    object.ReferenceEquals(this.Detail, other.Detail) ||
                    this.Detail != null &&
                    this.Detail.Equals(other.Detail)
                );
        }
    }
}