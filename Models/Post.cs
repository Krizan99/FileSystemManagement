using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemManagement.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string File { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } 
        
        public User User { get; set; }
    }
}
