using Phone_Book.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Book.Common.Dto;
using Phone_Book.Common;

namespace Phone_Book.Application.Services.Users.Query.GetUsers
{

    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.Name.Contains(request.SearchKey) &&
                p.LastName.Contains(request.SearchKey) &&
                p.Email.Contains(request.SearchKey) &&
                p.Address.Contains(request.SearchKey) &&
                //p.Date.Contains(request.SearchKey) &&
                p.Phone_Number.Contains(request.SearchKey)
                );
            }
            int rowsCount = 0;

            var usersList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Name = p.Name,
                LastName = p.LastName,
                Email = p.Email,
                Address = p.Address,
                Phone_Number = p.Phone_Number
            }).ToList();
            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = usersList,
            };

        }

        //public ResultGetUserDto Execute(string SearchKey, int Page = 1)
        //{

        //}
    }
}
