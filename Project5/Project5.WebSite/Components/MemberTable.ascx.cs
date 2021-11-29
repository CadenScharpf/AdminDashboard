using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Project5.WebSite.Accounts;

namespace Project5.WebSite
{
    public partial class userControls : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("login.aspx");

            HttpCookie cookie = Request.Cookies["CSE445Cookie"];
            string type = Helpers.Authenticate(Session["User"].ToString(), Session["Auth"].ToString());
            if ( Session["Type"] != "member" || Session["Auth"] == null || type == "dne" || type == "!pwd")
            { maincontent.InnerText = "Sorry, access is not permitted."; }
            else
            {
                if (tbdy.InnerHtml == "")
                {
                    AccountDetailsService.AccountServiceClient adsClient = new AccountDetailsService.AccountServiceClient();
                    string[][] devices = adsClient.GetDeviceInfo(Session["User"].ToString());
                    if (devices == null) { maincontent.InnerText = "An error has occured"; return; }
                    foreach (string[] device in devices)
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlNode row = doc.CreateElement("tr");
                        XmlNode model = doc.CreateElement("td");
                        XmlNode imei = doc.CreateElement("td");
                        XmlNode status = doc.CreateElement("td");
                        model.InnerText = device[0];
                        imei.InnerText = device[1];
                        status.InnerText = device[2];
                        row.AppendChild(model);
                        row.AppendChild(imei);
                        row.AppendChild(status);
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

        protected void OnAddDeviceButtonClick(object sender, EventArgs e)
        {
            int x;
            ;
            if (!int.TryParse(ImeiInput.Value, out x))
            {
                labelWarning.InnerText = "Failed. Imei must be a number";
                labelWarning.Attributes["class"] += "alert alert-danger";
            }
            else
            {
                AccountDetailsService.AccountServiceClient client = new AccountDetailsService.AccountServiceClient();
                string s = client.AddDevice(ImeiInput.Value, ModelInput.Value, Session["User"].ToString(), "password");
                ImeiInput.Value = ""; ModelInput.Value = "";
                Response.Redirect("~/Pages/MemberHome.aspx");
            }
        }


    }
}