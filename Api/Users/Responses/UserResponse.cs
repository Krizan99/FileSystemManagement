using Domain.Entities.Users;

namespace Api.Users.Responses
{
    public class UserResponse
    {
        // Properties
        public int Id { get; }
        public string Email { get; }
        public string Username { get; }
        public UserType Type { get; }
        public bool IsBanned { get; }
        public int NumberOfReports { get; }

        // Constructors
        public UserResponse(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Username = user.Username;
            Type = user.Type;
            IsBanned = user.IsBanned;
            NumberOfReports = user.NumberOfReports;
        }
    }
}
