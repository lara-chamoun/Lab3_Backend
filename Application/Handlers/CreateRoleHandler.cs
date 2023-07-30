using Application.Commands;
using Application.IServices;
using Domain.Entities;
using MediatR;

namespace Application.Handlers;


    public class CreateRoleHandler: IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly IRolesService _roleService;
        public CreateRoleHandler(IRolesService service)
        {
            _roleService = service;
        }
        public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.AddRole(request.name);
        }
    }
