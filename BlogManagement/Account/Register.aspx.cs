using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using BlogManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogManagement.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dbContext = new ApplicationDbContext();
                var roles = dbContext.Roles.ToList();
                ddRoles.DataSource = roles;
                ddRoles.DataValueField = "Id";
                ddRoles.DataTextField = "Name";
                ddRoles.DataBind();
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, Name = Name.Text };
            var result = manager.CreateAsync(user, Password.Text).Result;
            if (result.Succeeded)
            {
                manager.AddToRoleAsync(user.Id, ddRoles.SelectedItem.Text).Wait();
                Response.Redirect("/Admin/Index");
                //signInManager.SignInAsync( user, isPersistent: false, rememberBrowser: false).Wait();
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}