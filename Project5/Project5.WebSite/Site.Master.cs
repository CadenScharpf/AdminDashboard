using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Library;
namespace Project5.WebSite
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) { sobutton.InnerText = "Sign out"; libutton.InnerText = ""; }
            else { sobutton.InnerText = ""; libutton.InnerText = "Sign in"; }
        }


        /*
        protected void On_Register_Button(object sender, EventArgs e)
        {
            string username = usernameInput.Value;
            string password = passwordInput.Value;
        }
        protected void On_Login_Button(object sender, EventArgs e)
        {
            string username = usernameInput.Value;
            string password = passwordInput.Value;
            
        }
        */
        protected void OnSignOutClick(object sender, EventArgs e)
        {

            Session.Clear();
            Response.Cookies.Remove("CSE445Cookie");
            Response.Redirect("~/Default.aspx");
        }
    }
}