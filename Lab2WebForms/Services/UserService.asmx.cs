using Billboard.Managers;
using Billboard.Repositories;
using Billboard.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Lab2WebForms.Services
{
    /// <summary>
    /// Сводное описание для User
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<FriendInfo> Friends(String userId)
        {
            var friends = new UserRepository().GetFriends(userId);
            var _postRepository = new PostRepository();
            var friendsList = new List<FriendInfo>();

            friends.ForEach(x =>
            {
                var info = new FriendInfo
                {
                    Login = x.Login,
                    CountPosts = _postRepository.GetCountPostsByUserId(x._id)
                };
                friendsList.Add(info);
            });

            return friendsList;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CatUser> AllUsers()
        {
            return new UserRepository().GetAll();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool AddToFriend(string id)
        {
            return new UserRepository().AddFriend(SessionManager.GetUserId(), id);
        }
    }
}
