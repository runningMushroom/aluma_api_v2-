using System;
using System.ComponentModel.DataAnnotations;

namespace vueBuilderApi.Models
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

        [Required, StringLength(60), MinLength(10), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(11), MinLength(11)]
        public string MobileNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public bool EmailVerified { get; set; }

        public bool MobileVerified { get; set; }

        public BaseUserModel()
        {
            EmailVerified = false;
            MobileVerified = false;
        }
    }
}