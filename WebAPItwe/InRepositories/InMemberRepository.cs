﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPItwe.Models;

namespace WebAPItwe.InRepositories
{
    public interface InMemberRepository
    {
        Task<MemberRegisterModel> CreateNewMember(MemberRegisterModel member);
        Task<Object> GetMemberProfile(string username);
        Task<Object> UpdateMemberProfile(string username, MemberProfileModel member);
        Task<Object> CreateFeedback(string userId, FeedbackModel feedback);
    }
}
