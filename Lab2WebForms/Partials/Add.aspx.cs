using Billboard.Managers;
using Billboard.Repositories;
using Billboard.Repositories.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2WebForms.Partials
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated) HttpContext.Current.Response.Redirect("/Index.html");
        }

        protected void Addpost_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var title = Request.Form["Title"];
                var text = Request.Form["Text"];
                var file = Request.Files["file"];

                var fileName = new Random().Next().ToString() + ".png";
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                file.SaveAs(path);

                var post = new Post
                {
                    _id = new MongoDB.Bson.ObjectId(),
                    Title = title,
                    Text = text,
                    ImagePath = "/Images/" + fileName,
                    DateCreation = DateTime.Now,
                    UserId = new MongoDB.Bson.ObjectId(SessionManager.GetUserId())
                };

                new PostRepository().Insert(post);

                HttpContext.Current.Response.Redirect("/Index.html");
            }
        }
    }
}