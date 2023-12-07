﻿using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class LoginRequest : BaseModel
    {
        private string _username;
        public string Username { get => _username; set => _username = value?.ToLower(); }
        public string Password { get; set; }
    }
}
