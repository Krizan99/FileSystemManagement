using Domain.Entities.Users;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public bool IsDeleted { get; private set; }

        public int SenderId { get; private set; }
        public User? Sender { get; private set; }

        public int ReceiverId { get; private set; }
        public User? Receiver { get; private set; }

        public Message(string text, int senderId, int receiverId)
        {
            Text = text;
            SenderId = senderId;
            ReceiverId = receiverId;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>Constructor for Entity Framework.</summary>
        private Message() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
