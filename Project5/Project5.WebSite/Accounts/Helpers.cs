using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using Library;

namespace Project5.WebSite.Accounts
{
    public static class Helpers
    {
        public static readonly string MEMBERFILE = Path.Combine(HttpRuntime.AppDomainAppPath, "Accounts/Member");
        public static readonly string STAFFFILE = Path.Combine(HttpRuntime.AppDomainAppPath, "Accounts/Staff");
        public static readonly string USRFFILE = Path.Combine(HttpRuntime.AppDomainAppPath, "Accounts/Users");
        static readonly string SCHEMAFILE = Path.Combine(HttpRuntime.AppDomainAppPath, "Accounts/Member/xsd");
        static readonly string ADMIN_USR = "admin";
        static readonly string ADMIN_PASS = "pass";

        public static bool HasFile(string filepath)
        {
            if (File.Exists(filepath)){return true;}
            else{return false;}
        }
        public static XmlDocument LoadXml(string filepath)
        {
            if(!HasFile(filepath)) { return null; }
            XmlDocument xml = new XmlDocument();
            xml.Load(filepath);
            return xml;
        }
        public static void ClearFile(string which)
        {
            string filepath = (which == "user") ? USRFFILE : getfp(which);
            XmlDocument xml = LoadXml(filepath);
            XmlNode node = xml.SelectSingleNode("//members");
            node.InnerText = "";
            xml.Save(filepath);
            if (which == "staff") {AddMember("staff", "TA", "Cse445ta!"); AddMember("staff", "testStaff", "password"); }
            if (which == "member") { AddMember("member", "testMember", "password");}
        }
        public static void Reset()
        {
            ClearFile("user");
            ClearFile("member");
            ClearFile("staff");
            AccountDetailsService.AccountServiceClient client = new AccountDetailsService.AccountServiceClient();
            client.Reset();
            client.CreateAccount("testStaff", "password"); client.CreateAccount("TA", "password");
            client.CreateAccount("testMember", "password");
        }
        private static string getfp(string which) { return which == "member" ? MEMBERFILE : STAFFFILE; }
        public static string Authenticate(string username, string password)
        {
            if(username==ADMIN_USR && Crypto.Encrypt(ADMIN_PASS) == password) { return "admin"; }
            string which = GetAccountType(username);
            if (which == "") { return "dne"; };
            XmlDocument xml = LoadXml(getfp(which));
            XmlNode member = xml.SelectSingleNode($"//uname[text()[contains(., '{username}')]]");
            if(member == null) { return "dne"; }
            string pwHash = member.SelectSingleNode("../pwd").InnerText;
            if (pwHash == password) { return which; };
            return "!pwd";
        }
        public static string ChangePassword(string which, string username, string password, string newPasswd)
        {
            string filepath = getfp(which);
            XmlDocument xml = LoadXml(filepath);
            XmlNode member = xml.SelectSingleNode($"//uname[text()[contains(., '{username}')]]");
            if (member == null) { return "!exist"; }
            string type = Authenticate(username, password);
            if ((type == "dne") && (type == "!pwd")) 
            { return "pwInvalid"; };
            XmlNode pwnode = member.SelectSingleNode("../pwd");
            pwnode.InnerText = Crypto.Encrypt(newPasswd);
            xml.Save(filepath);
            return "success";
        }
        public static bool AddMember(string which, string username, string password)
        {
            string filepath = getfp(which);
            XmlDocument members = LoadXml(filepath);
            if (!addUsername(username, which)) { return false; }
            XmlElement elem = members.CreateElement("member");
            XmlElement uname = members.CreateElement("uname");
            uname.InnerText = username;
            XmlElement pwd = members.CreateElement("pwd");
            pwd.InnerText = Crypto.Encrypt(password);
            elem.AppendChild(uname);
            elem.AppendChild(pwd);
            members.SelectSingleNode("//members").AppendChild(elem);
            members.Save(filepath);
            return true;
        }
        public static bool DeleteAccount(string which, string username)
        {
            string filepath = (which == "user") ? USRFFILE : getfp(which);
            XmlDocument members = LoadXml(filepath);
            XmlNode member = members.SelectSingleNode($"//uname[text()[contains(., '{username}')]]");
            if (member == null) { return false; }
            member = member.SelectSingleNode("..");
            member.ParentNode.RemoveChild(member);
            members.Save(filepath);
            return true;
        }
        public static string GetAccountType(string username)
        {
            if(username == ADMIN_USR) { return "admin"; };
            XmlDocument members = LoadXml(USRFFILE);
            XmlNode member = members.SelectSingleNode($"//uname[text()[contains(., '{username}')]]");
            if (member == null){ return ""; };
            member = member.SelectSingleNode("../type");
            return member.InnerText;
        }
        
        private static bool addUsername(string username, string which)
        {
            XmlDocument members = LoadXml(USRFFILE);
            if (members.SelectSingleNode($"//uname[text()[contains(., '{username}')]]") != null){ return false; };
            XmlElement elem = members.CreateElement("user");
            XmlElement uname = members.CreateElement("uname");
            uname.InnerText = username;
            XmlElement type = members.CreateElement("type");
            type.InnerText = which;
            elem.AppendChild(uname);
            elem.AppendChild(type);
            members.SelectSingleNode("//members").AppendChild(elem);
            members.Save(USRFFILE);
            return true;
        }
    }
}