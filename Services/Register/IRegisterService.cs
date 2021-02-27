using Core.Domain.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Register
{
    public interface IRegisterService
    {
        Task<RegisterResultModel> RegisterUser(RegisterViewModel registerViewModel);
    }
}
