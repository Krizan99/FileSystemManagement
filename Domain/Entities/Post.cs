using Domain.Entities.Users;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; private set; }
        public string File { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }

        public int UserId { get; private set; }
        public User? User { get; private set; }
    }
}
