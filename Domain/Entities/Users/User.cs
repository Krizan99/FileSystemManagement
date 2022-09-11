using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Users
{
    public class User
    {
        // Properties
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public UserType Type { get; private set; }
        public bool IsBanned { get; private set; }
        public int NumberOfReports { get; private set; }

        public IReadOnlyList<Message>? SentMessages => _sentMessages?.AsReadOnly();
        private List<Message>? _sentMessages = null;

        public IReadOnlyList<Message>? ReceivedMessages => _receivedMessages?.AsReadOnly();
        private readonly List<Message>? _receivedMessages = null;

        public IReadOnlyList<Post>? Posts => _posts?.AsReadOnly();
        private readonly List<Post>? _posts = null;

        // Constructors
        public User(string email, string username, string password, UserType type)
        {
            Update(email: email, username: username, password: password, type);
        }

        // Methods
        [MemberNotNull(nameof(Email), nameof(Username), nameof(Password), nameof(Type))]
        public void Update(string email, string username, string password, UserType type)
        {
            Email = email;

            if (string.IsNullOrWhiteSpace(username) || username.Length > UsernameMaxLength)
            {
                throw new ArgumentException($"The username must be a nonempty string with max length of {UsernameMaxLength}.");
            }
            Username = username;

            Password = password;

            if (!Enum.IsDefined(type))
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }
            Type = type;
        }

        public void SendMessage(Message message)
        {
            if (_sentMessages == null)
            {
                _sentMessages = new List<Message>() { message };
            }
            else
            {
                _sentMessages!.Add(message);
            }
        }

        // Constants
        public const int UsernameMaxLength = 20;

    }
}
