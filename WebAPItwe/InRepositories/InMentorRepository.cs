﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPItwe.Models;

namespace WebAPItwe.InRepositories
{
    public interface InMentorRepository 
    {
        Task<IEnumerable<MentorModel>> GetAll(int pageIndex, int pageSize);
        Task<MentorModel> GetById(string Id);
        Task<IEnumerable<MentorModel>> SortByName(string order_by_name,int pageIndex, int pageSize);
        Task<IEnumerable<MentorModel>> FindByName(string name, int pageIndex, int pageSize);
        Task<IEnumerable<MentorModel>> Filter(string major, int pageIndex, int pageSize);
        Task<IEnumerable<Object>> LoadMentorFeedback(string id, int pageIndex, int pageSize);
        Task<Object> LoadTopMentorHome(int pageIndex, int pageSize);
        Task<Object> LoadSchedule(string mentorId, string date);
    }
}
