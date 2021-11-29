using Project5.WebSite.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5.WebSite.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnRegisterButtonClick(object sender, EventArgs e)
        {
            string username = InputUser.Value;
            string pwhash = Library.Crypto.Encrypt(InputPassword.Value);
            if (InputUser.Value == "" || InputPassword.Value == "") { return; }
            if (!Helpers.AddMember("member",InputUser.Value,InputPassword.Value))
            {
                regeBox.Attributes["class"] = "user alert alert-danger";
                warningp.InnerText = "Username is taken";return;
            }
            else
            {
                HttpCookie cookie = new HttpCookie("CSE445Cookie");
                AccountDetailsService.AccountServiceClient client = new AccountDetailsService.AccountServiceClient();
                client.CreateAccount(username, "password");
                Session["User"] = username;
                Session["Type"] = "member";
                Session["Auth"] = pwhash;
                cookie["User"] = username;
                cookie["Auth"] = pwhash;
                cookie["Type"] = "member";
                cookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(cookie);
                regeBox.Attributes["class"] = "user alert alert-success";
                Thread.Sleep(2000);
                Response.Redirect("MemberHome.aspx");
            }
        }

    }
}