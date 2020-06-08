using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogManagement.Models;
using Microsoft.AspNet.Identity;

namespace BlogManagement
{
    public partial class Blog : System.Web.UI.Page
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("/");
            if (User.IsInRole("Author"))
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString.Count > 0)
                    {
                        var id = Request.QueryString["id"];
                        var isInt = int.TryParse(id, out var idValue);
                        var blog = dbContext.Blog.FirstOrDefault(x => x.Id == idValue);
                        if (blog != null)
                        {
                            hfId.Value = id;
                            editor1.InnerHtml = blog.Content;
                            txtHeader.Text = blog.Header;
                            imgFile.Src = !string.IsNullOrEmpty(blog.FileName) ? $"/Files/{blog.FileName}" : "/Files/no-image.png";
                        }

                    }
                    else
                        imgFile.Src = "/Files/no-image.png";
                }
            }
            else
                Response.Redirect("/");

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            var fileName = "";
            if (fileUpload.HasFile && fileUpload.PostedFile != null)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);
                fileUpload.SaveAs(Request.PhysicalApplicationPath + "Files\\" + fileName);
            }
            if (!string.IsNullOrEmpty(hfId.Value))
            {
                var id = int.Parse(hfId.Value);
                var blog = dbContext.Blog.First(d => d.Id == id);
                blog.Content = editor1.InnerHtml;
                blog.Header = txtHeader.Text;
                if (!string.IsNullOrEmpty(fileName))
                    blog.FileName = fileName;
                dbContext.Entry(blog).State = EntityState.Modified;
            }
            else
            {
                var blog = new Blogs
                {
                    Content = editor1.InnerHtml,
                    Header = txtHeader.Text,
                    IsActive = true,
                };
                blog.FileName = fileName;
                blog.CreateDate = DateTime.Now;
                blog.ApplicationUserId = User.Identity.GetUserId();
                dbContext.Blog.Add(blog);
            }
            dbContext.SaveChanges();
            Response.Redirect("BlogList.aspx");
        }
    }
}