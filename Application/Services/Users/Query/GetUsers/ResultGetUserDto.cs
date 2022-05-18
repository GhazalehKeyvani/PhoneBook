using System.Collections.Generic;

namespace Phone_Book.Application.Services.Users.Query.GetUsers
{
    public class ResultGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int Rows { get; set; }

    }
}
