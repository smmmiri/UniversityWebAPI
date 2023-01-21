using System.ComponentModel.DataAnnotations;

namespace Message.Commands
{
    public class LoginCommand
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
