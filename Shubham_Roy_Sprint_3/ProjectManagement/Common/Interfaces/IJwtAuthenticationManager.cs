using Domain.Entities;

namespace ProjectManagement.Common.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        public string Authenticate(User user);
    }
}