using Project5.WebSite.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5.WebSite.Components
{
    public partial class StaffPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("login.aspx");

            HttpCookie cookie = Request.Cookies["CSE445Cookie"];
            string type = Helpers.Authenticate(Session["User"].ToString(), Session["Auth"].ToString());
            if (Session["Type"] != "staff" || Session["Auth"] == null || type == "dne" || type == "!pwd")
            { maincontent.InnerText = "Sorry, access is not permitted."; }
            else
            {
                maincontent.InnerText = "Staff Page";
            }
        }
    }
}