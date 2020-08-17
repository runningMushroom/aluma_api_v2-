using System;

namespace Entities.Dto
{
    public class UserBaseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string MobileNumber { get; set; }
    }
}