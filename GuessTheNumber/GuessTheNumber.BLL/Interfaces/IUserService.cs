using GuessTheNumber.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber.BLL.Interfaces
{
    public interface IUserService
    {
        bool Login(LoginUserContract creds);

        LoginUserContract Register(NewUserContract newUser);
    }
}