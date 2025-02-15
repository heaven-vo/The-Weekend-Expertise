﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPItwe.Entities;
using WebAPItwe.InRepositories;

namespace WebAPItwe.Repositories
{
    public class NotificationRepository : InNotificationRepository
    {
        private readonly dbEWTContext context;

        public NotificationRepository(dbEWTContext context)
        {
            this.context = context;
        }

        public async Task<List<string>> getUserToken(List<string> listUserId)
        {
            var listToken = new List<string>();
            foreach (var userId in listUserId)
            {
                var token = await context.FcmTokens.Where(x => x.UserId == userId).Select(x => x.Token).ToListAsync();
                foreach (var t in token) listToken.Add(t);
            }
            return listToken;
        }

        public async Task<object> LoadNotification(string userId, int pageIndex, int pageSize)
        {
            var listNoti = await context.Notifications.OrderByDescending(x => x.Date).ThenByDescending(x => x.Time)
                                .Where(x => x.UserId == userId).Select(x => new 
                                {
                                    x.Image,
                                    x.Title,
                                    x.ContentNoti,
                                    x.Date,
                                    x.Time,
                                    x.SessionId
                                }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return listNoti;
        }

        public async Task<object> SaveNotification(List<string> listUserId,string image ,string title, string content, string sessionId)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string time = DateTime.Now.ToString("HH:mm:ss");

                foreach (var userId in listUserId)
                {

                    Notification noti = new Notification { Id = Guid.NewGuid().ToString(), Date = date, Time = time, Image = image,
                                                            ContentNoti = content, Title = title, UserId = userId, SessionId = sessionId};
                    context.Add(noti);
                }
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return null;
        }
    }
}
