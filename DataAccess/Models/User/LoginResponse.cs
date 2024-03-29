﻿using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class LoginResponse : BaseModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string AppToken { get; set; }
    }
}
