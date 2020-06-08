using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogManagement.Models;

namespace BlogManagement
{
    public partial class BlogList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("/");
            if (User.IsInRole("Author"))
            {
                if (!IsPostBack)
                {
                    var dbContext = new ApplicationDbContext();
                    var blogs = dbContext.Blog.Where(x => x.IsActive)
                        .ToList();
                    gv1.DataSource = blogs;
                    gv1.DataBind();
                }
            }
            else
                Response.Redirect("/");
        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {

        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            var row  = (GridViewRow)((LinkButton)sender).NamingContainer;
            var lblHeader = (HiddenField)row.FindControl("hfId");
            var id = lblHeader.Value;
            Response.Redirect($"blog.aspx?id={id}");
        }
    }
}