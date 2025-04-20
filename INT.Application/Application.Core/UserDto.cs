using INT.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Application.Application.Core
{
    public class UserCreateDto
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string NameHi { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required List<int> UserRoles { get; set; }
       
    }

    public class UpdateUserDto : UserCreateDto
    {
        public int Id { get; set; }
    }

    public class ViewUserDto : UpdateUserDto
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
