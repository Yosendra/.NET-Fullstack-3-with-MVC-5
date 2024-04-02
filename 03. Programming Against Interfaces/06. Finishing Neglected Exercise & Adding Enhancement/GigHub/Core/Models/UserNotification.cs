﻿using System;

namespace GigHub.Core.Models
{
    public class UserNotification
    {
        public string UserId { get; private set; }
        public int NotificationId { get; private set; }
        public bool IsRead { get; private set; }
        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }

        protected UserNotification()
        {
        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            User = user ?? throw new ArgumentNullException("User is null.");
            Notification = notification ?? throw new ArgumentNullException("Notification is null.");
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}