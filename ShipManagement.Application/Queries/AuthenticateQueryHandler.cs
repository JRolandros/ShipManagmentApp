using MediatR;
using ShipManagement.Application.Dtos;
using ShipManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Queries
{
    public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, ManagerDto>
    {
        private readonly IAuthService _authService;

        public AuthenticateQueryHandler(IAuthService authService)
        {
            _authService=authService;
        }
        public Task<ManagerDto> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
           var managerDto=_authService.Authenticate(request.Username, request.Password);

           return Task.FromResult(managerDto);
        }
    }
}
