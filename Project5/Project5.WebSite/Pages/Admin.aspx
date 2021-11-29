<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Project5.WebSite.Pages.Admin" %>
<%@ Register TagPrefix = "User" TagName="AdminPage"  src="~/Components/AdminPage.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="form1" runat="server">
            <User:AdminPage runat="server" />
    </div>
</asp:content>
