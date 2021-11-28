using Project5.WebSite.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Library;
using System.Web.UI.WebControls;


namespace Project5.WebSite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void OnIn1Click(Object sender, EventArgs e)
        {
            Dictionary<string, string> x = Crypto.GenerateKey();
            Helpers.AddMember("staff", "testStaff", "password");
            Helpers.AddMember("member", "testMember", "password");
            string authorizedstaff = Helpers.Authenticate("testStaff", "password");
            string authorizedmember = Helpers.Authenticate("testMember", "password");

            System.Diagnostics.Debug.WriteLine("");

            Helpers.ChangePassword("staff","testStaff", "password", "password2");
            Helpers.ChangePassword("member", "testMember", "password", "password2");

            System.Diagnostics.Debug.WriteLine("");

            authorizedstaff = Helpers.Authenticate("testStaff", "password2");
            authorizedmember = Helpers.Authenticate("testMember", "password2");

            System.Diagnostics.Debug.WriteLine("");

            Helpers.AddMember("staff", "testStaff", "password");
            Helpers.AddMember("member", "testMember", "password");

            System.Diagnostics.Debug.WriteLine("");
        }
        public void OnIn2Click(Object sender, EventArgs e)
        {
            Helpers.Reset();
        }
    }
}