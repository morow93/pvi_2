using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billboard.Managers
{
    public static class SessionManager
    {
        public static String GetUserId()
        {
            const String userIdField = "UserId";
            var context = HttpContext.Current;
            var user = context.User.Identity;

            if (user.IsAuthenticated)
            {
                String userId = user.Name;
                return userId;
            }

            return "";
        }
    }
}