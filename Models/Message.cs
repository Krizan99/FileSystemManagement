using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemManagement.Models
{
    public class Message
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public bool IsDeleted { get; private set; }
        public int SenderId { get; private set; }
        public int ReceiverId { get; private set; }

        public User Sender { get; private set; }

        public User Receiver { get; private set; }
    
    }
}
