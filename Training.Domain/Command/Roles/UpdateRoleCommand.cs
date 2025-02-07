﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Roles
{
    public class UpdateRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        public string? RoleName {  get; set; }
    }
}
