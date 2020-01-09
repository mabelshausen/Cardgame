using CardGame.MVC.Constants;
using CardGame.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.MVC.Services
{
    public class UserStateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserStateService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            LoadUserState();
        }

        public UserState UserState { get; set; }

        public void LoadUserState()
        {
            string sessionUserState = _httpContextAccessor.HttpContext
                .Session.GetString(UserStateConstants.UserStateSessionKey);
            UserState = JsonConvert.DeserializeObject<UserState>(sessionUserState);
        }

        public void SaveUserState()
        {
            _httpContextAccessor.HttpContext.Session.SetString(
                UserStateConstants.UserStateSessionKey, 
                JsonConvert.SerializeObject(UserState));
        }
    }
}
