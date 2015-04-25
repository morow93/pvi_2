using Billboard.Managers;
using Billboard.Repositories;
using Billboard.Repositories.DTO;
using Billboard.Repositories.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;

namespace Lab2WebForms.Services
{
    /// <summary>
    /// Сводное описание для Auth
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class Auth : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public CatUser RegisterUser(string login, string password)
        {
            var salt = CreateSalt(10);
            var _userRepository = new UserRepository();
            var user = new User
            {
                _id = new MongoDB.Bson.ObjectId(),
                Login = login,
                Password = CreatePasswordHash(password, salt)
            };

            try
            {
                if (!_userRepository.FindUser(login))
                {
                    _userRepository.Insert(user);
                    return new CatUser(user);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public CatUser Login(string login, string password)
        {
            var salt = CreateSalt(10);
            var user = new UserRepository().getUser(login, CreatePasswordHash(password, salt));

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user._id.ToString(), false);
                return new CatUser(user);
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public CatUser CheckLogin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = SessionManager.GetUserId();
                var user = new UserRepository().getUserById(userId);

                FormsAuthentication.SetAuthCookie(user._id.ToString(), false);

                return new CatUser(user);

            }
            else return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool Logout()
        {
            FormsAuthentication.SignOut();
            return true;
        }

        private static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);

            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, pwd);
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
