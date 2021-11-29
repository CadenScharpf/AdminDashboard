using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using Project5.WebSite.Accounts;
namespace Project5.WebSite
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnLoginButtonClick(object sender, EventArgs e)
        {
            string pwhash = Crypto.Encrypt(exampleInputPassword.Value);
            string username = exampleInputEmail.Value;
            string type = Helpers.Authenticate(username, pwhash);
            Response.Cookies.Remove("CSE445Cookie");
            switch (type)
            {
                case "member":
                    {
                        HttpCookie cookie = new HttpCookie("CSE445Cookie");
                        Session["User"] = username;
                        Session["Type"] = "member";
                        Session["Auth"] = pwhash;
                        cookie["User"] = username;
                        cookie["Auth"] = pwhash;
                        cookie["Type"] = "member";
                        cookie.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Add(cookie);
                        LoginBox.Attributes["class"] = "user alert alert-success";
                        Thread.Sleep(2000);
                        Response.Redirect("MemberHome.aspx");
                    }
                    break;

                case "staff":
                    {
                        HttpCookie cookies = new HttpCookie("CSE445Cookie");
                        Session["User"] = username;
                        Session["Type"] = "staff";
                        Session["Auth"] = pwhash;
                        cookies["User"] = username;
                        cookies["Auth"] = pwhash;
                        cookies["Type"] = "staff";
                        cookies.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Add(cookies);
                        LoginBox.Attributes["class"] = "user alert alert-success";
                        Thread.Sleep(2000);
                        Response.Redirect("StaffHome.aspx");
                    }
                    break;

                case "admin":
                    {
                        HttpCookie cookies = new HttpCookie("CSE445Cookie");
                        Session["User"] = username;
                        Session["Type"] = "admin";
                        Session["Auth"] = pwhash;
                        cookies["User"] = username;
                        cookies["Auth"] = pwhash;
                        cookies["Type"] = "admin";
                        cookies.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Add(cookies);
                        LoginBox.Attributes["class"] = "user alert alert-success";
                        Thread.Sleep(2000);
                        Response.Redirect("Admin.aspx");
                    }
                    break;

                case "dne":
                    LoginBox.Attributes["class"] = "user alert alert-danger";
                    warningp.InnerText = "Error. Username does not Exist";
                    break;

                case "!pwd":
                    LoginBox.Attributes["class"] = "user alert alert-danger";
                    warningp.InnerText = "Error. Password invalid";
                    break;

                default:
                    LoginBox.Attributes["class"] = "user alert alert-danger";
                    warningp.InnerText = "An unknown error has occurred";
                    break;
            }
            string c = $"{exampleInputEmail.Value} {pwhash}";

            System.Diagnostics.Debug.WriteLine(c);
        }
    }
}