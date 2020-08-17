using alumaApi.Static;
using System;
using System.ComponentModel.DataAnnotations;

namespace alumaApi.Models
{
    public class BaseUserModel : BaseModel
    {
        public Guid Id { get; set; }

        [Required, StringLength(60), MinLength(4)]
        public string FirstName { get; set; }

        [Required, StringLength(60), MinLength(4)]
        public string LastName { get; set; }

        [Required, StringLength(13), MinLength(8)]
        public string IdNumber { get; set; }

        [Required, StringLength(60), MinLength(6), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string MobileNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public RoleEnum Role { get; set; }

        public bool MobileVerified { get; set; }

        public BaseUserModel()
        {
            MobileVerified = false;
        }
    }
}