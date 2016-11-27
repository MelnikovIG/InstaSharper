﻿using InstagramAPI.Classes.Models;

namespace InstagramAPI.Classes
{
    public class UserSessionData
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public InstaUser LoggedInUder { get; set; }

        public string RankToken { get; set; }
        public string CsrfToken { get; set; }
    }
}