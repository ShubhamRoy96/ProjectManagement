namespace ProjectManagement.Common.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        public string Authenticate(string username, string password);
    }
}