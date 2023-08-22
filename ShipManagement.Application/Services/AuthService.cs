using AutoMapper;
using Microsoft.Extensions.Logging;
using ShipManagement.Application.Common;
using ShipManagement.Application.Dtos;
using ShipManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISecurityService _securityService;
        private readonly IManagerRepository _managerRepo;
        private readonly IMapper _mapper;

        public AuthService(ISecurityService securityService,IManagerRepository managerRepository, IMapper mapper)
        {
            _securityService = securityService;
            _managerRepo=managerRepository;
            _mapper = mapper;
        }
        public ManagerDto Authenticate(string username, string password)
        {
            var user=_managerRepo.GetUserByEmail(username);

            string token = string.Empty;
            if(user!=null && user.Password==password)
            {
                token = _securityService.CreateToken(user);

                var dto = _mapper.Map<ManagerDto>(user);

                dto.Token = token;

                return dto;
            }

            throw new ShipManagementException(401,"Fail to authenticate");
        }
    }
}
