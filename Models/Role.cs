using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemManagement.Models
{
    public enum RoleType
    {
        user,
        admin
    }
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public RoleType Type  { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
