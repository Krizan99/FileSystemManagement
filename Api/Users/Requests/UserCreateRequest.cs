using Domain.Entities.Users;

namespace Api.Users.Requests
{
    public class UserRequest
    {
        // Properties
        public string Email { get; }
        public string Username { get; }
        public string Password { get; }
        public UserType Type { get; }

        // Constructors
        public UserRequest(string email, string username, string password, UserType type)
        {
            Email = email;
            Username = username;
            Password = password;
            Type = type;
        }
    }
}
