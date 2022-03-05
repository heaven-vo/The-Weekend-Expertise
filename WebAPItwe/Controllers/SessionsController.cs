﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPItwe.Entities;
using WebAPItwe.InRepositories;
using WebAPItwe.Models;

namespace WebAPItwe.Controllers
{
    [Route("api/v1/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly InSessionRepository sessionRepository;

        public SessionController(InSessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }
        /// <summary>
        /// Create new Session 
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateNewSession(NewSessionModel newSession)
        {
            try
            {
                await sessionRepository.CreateNewSession(newSession);
                return Ok();
            }
            catch
            {
                return Conflict();
            }

        }
        /// <summary>
        /// Load 4 recommend session for home page  
        /// </summary>
        [HttpGet("home")]
        public async Task<ActionResult> LoadRecommendSession (string memberId)
        {
            var listSession = await sessionRepository.LoadRecommendSession(memberId);
            return Ok(listSession);
        }

    }
}
