using System.Collections.Generic;


namespace Phone_Book.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RolesRegisterUserDto> roles { get; set; }

    }
}
