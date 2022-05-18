namespace Phone_Book.Application.Services.Users.Query.GetUsers
{
    public class RequestGetUserDto
    {
        public int Page { get; set; }

        public string SearchKey { get; set; }
        public int Rows { get; set; }
    }
}
