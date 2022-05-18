using Phone_Book.Application.Interface;
using Phone_Book.Common.Dto;
using Phone_Book.Common;
using Phone_Book.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;


namespace Phone_Book.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);

    }
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام خود را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.LastName))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام خانوادگی خود را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Address))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "آدرس را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Phone_Number))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره تلفن را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (request.RePassword!=request.Password)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }


                User users = new User()
                {
                    Email = request.Email,
                    Name = request.Name,
                    Address = request.Address,
                    Phone_Number = request.Phone_Number,
                    LastName = request.LastName,
                    //Password = request.Password,
                    //RePassword = request.RePassword,
                };
                List<UserInRoles> userInRoles = new List<UserInRoles>();
                foreach (var item in request.roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRoles
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = users,
                        UserId = users.Id
                    });
                }
                users.UserInRoles = userInRoles;
                _context.Users.Add(users);
                _context.SaveChanges();
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId=users.Id,
                    },
                    IsSuccess =true,
                    Message = " تبریک، ثبت نام با موفقیت انجام شد! ",
                };
            }
        
            catch
            {

            }
        }
    }
}
