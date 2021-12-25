using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : IEquatable<User>
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as User);
        }

        public bool Equals(User other)
        {
            if (other == null)
                return false;

            return this.ID.Equals(other.ID)
                &&
                (
                    object.ReferenceEquals(this.FirstName, other.FirstName) ||
                    this.FirstName != null &&
                    this.FirstName.Equals(other.FirstName)
                )
                &&
                (
                    object.ReferenceEquals(this.LastName, other.LastName) ||
                    this.LastName != null &&
                    this.LastName.Equals(other.LastName)
                )
                &&
                (
                    object.ReferenceEquals(this.Email, other.Email) ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                )
                &&
                (
                    object.ReferenceEquals(this.Password, other.Password) ||
                    this.Password != null &&
                    this.Password.Equals(other.Password)
                );
        }
    }
}