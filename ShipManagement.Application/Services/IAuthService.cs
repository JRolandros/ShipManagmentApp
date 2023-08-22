using ShipManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Services
{
    public interface IAuthService
    {
        ManagerDto Authenticate(string username, string password);
    }
}
