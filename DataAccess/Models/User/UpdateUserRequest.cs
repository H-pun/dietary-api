﻿using Dietary.Base;
using Dietary.DataAccess.Entities;

namespace Dietary.DataAccess.Models
{
    public class UpdateUserRequest : BaseModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
