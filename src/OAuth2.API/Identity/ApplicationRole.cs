﻿using Microsoft.AspNetCore.Identity;

namespace OAuth2.API.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name) : base(name)
        { }
        public ApplicationRole() : base()
        { }

        public bool? IsActive { get; set; }
    }
}