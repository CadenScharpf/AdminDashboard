using Project5.WebSite.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Project5.WebSite.Components
{
    public partial class AdminPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("login.aspx");

            HttpCookie cookie = Request.Cookies["CSE445Cookie"];
            string type = Helpers.Authenticate(Session["User"].ToString(), Session["Auth"].ToString());
            if (cookie == null || cookie["Type"] != "admin" || cookie["Auth"] == null || type == "dne" || type == "!pwd")
            { maincontent.InnerText = "Sorry, access is not permitted."; }
            else
            {
                if (tbdy.InnerHtml == "")
                {
                    XmlDocument x = Helpers.LoadXml(Helpers.STAFFFILE);
                    XmlNodeList accounts = x.ChildNodes[1].ChildNodes;
                    if (x == null || accounts == null) { return; }
                    if (accounts.Count == 0) { return; }
                    foreach (XmlNode account in accounts)
                    {
                        string username = account.ChildNodes[0].InnerText;
                        string pwhash = account.ChildNodes[1].InnerText;
                        XmlDocument doc = new XmlDocument();
                        XmlNode row = doc.CreateElement("tr");
                        XmlNode usr = doc.CreateElement("td");
                        XmlNode pwd = doc.CreateElement("td");
                        XmlNode date = doc.CreateElement("td");
                        usr.InnerText = username;
                        pwd.InnerText = pwhash.Substring(0,10)+"...";
                        date.InnerText = DateTime.Now.ToString();
                        row.AppendChild(usr);
                        row.AppendChild(pwd);
                        row.AppendChild(date);
                        doc.AppendChild(row);
                        using (var sw = new System.IO.StringWriter())
                        {
                            using (var xw = new System.Xml.XmlTextWriter(sw))
                            {
                                doc.WriteContentTo(xw);
                            }
                            tbdy.InnerHtml += ("\r\n" + sw.ToString() + "\r\n");
                        }
                    }
                }
            }
        }//end page load

        protected void OnDeleteButtonClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("");
            string usr = DeleteUsr.Value;
            if (!Helpers.DeleteAccount("staff", usr))
            {
                labelWarning.InnerText = "Failed. User does not exist";
                labelWarning.Attributes["class"] += "alert alert-danger"; return;
            }
            else
            {
                Helpers.DeleteAccount("user", usr);
                Response.Redirect("~/Pages/Admin.aspx");
            }
        }

        protected void OnAddEmployeeButtonClick(object sender, EventArgs e)
        {
            if (UserInput.Value=="" || PassInput.Value=="")
            {
                labelWarning.InnerText = "Failed. Username/password must not be null";
                labelWarning.Attributes["class"] += "alert alert-danger"; return;
            }
            else
            {
                if(!Helpers.AddMember("staff", UserInput.Value, PassInput.Value) || UserInput.Value == "admin")
                {
                    labelWarning.InnerText = "Failed. Username taken";
                    labelWarning.Attributes["class"] += "alert alert-danger";
                    return;
                }
                Response.Redirect("~/Pages/Admin.aspx");
            }
        }
    }
}