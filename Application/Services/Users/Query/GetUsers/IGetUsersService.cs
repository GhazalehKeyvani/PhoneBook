namespace Phone_Book.Application.Services.Users.Query.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);

    }
}
