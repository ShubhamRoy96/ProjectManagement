using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Project : IEquatable<Project>
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Project);
        }

        public bool Equals(Project other)
        {
            if (other == null)
                return false;

            return this.ID.Equals(other.ID)
                &&
                (
                    object.ReferenceEquals(this.Name, other.Name) ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                )
                &&
                (
                    object.ReferenceEquals(this.Detail, other.Detail) ||
                    this.Detail != null &&
                    this.Detail.Equals(other.Detail)
                );
        }
    }
}