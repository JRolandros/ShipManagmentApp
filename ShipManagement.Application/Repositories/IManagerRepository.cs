using Microsoft.EntityFrameworkCore;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Repositories
{
    public interface IManagerRepository
    {
        Manager? GetUserByEmail(string email);
        Manager? GetManagerById(int managerId);
    }
}
