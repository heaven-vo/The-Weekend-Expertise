﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPItwe.Models;

namespace WebAPItwe.InRepositories
{
    public interface InUserRepository
    {
        Task RegisterMemberAccount(MemberRegisterModel member);
        Task<string> Login(string userId, string token);
        Task Logout(string userId, string token);
    }
}
