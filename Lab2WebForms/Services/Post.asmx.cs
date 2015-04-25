using Billboard.Managers;
using Billboard.Repositories;
using Billboard.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Lab2WebForms.Services
{
    /// <summary>
    /// Сводное описание для Post
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class Post : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CatPost> Posts(String page = "", String query = "")
        {
            var _postRepository = new PostRepository();
            if (query.Length == 0)
            {
                return _postRepository.GetPostsByUserId(SessionManager.GetUserId(), page).ToList();
            }
            else return _postRepository.GetPostsByQuery(page, query).ToList();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool DeletePost(String id)
        {
            var result = new PostRepository().DeletePostById(id);

            if (result.FromDb)
            {
                var path = HttpContext.Current.Request.MapPath("~" + result.ImagePath);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            return result.FromDb;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool SavePost(String id, string title, string text)
        {
            return new PostRepository().UpdatePostById(id, title, text);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CatPost> FriendsPosts(String login)
        {
            var userId = new UserRepository().GetUserIdByLogin(login);

            return new PostRepository().GetPostsByUserId(userId).ToList();
        }
    }
}
