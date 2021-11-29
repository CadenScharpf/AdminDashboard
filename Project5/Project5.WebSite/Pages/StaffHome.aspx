<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StaffHome.aspx.cs" Inherits="Project5.WebSite.WebForm2" %>
<%@ Register TagPrefix = "User" TagName="StaffPage"  src="~/Components/StaffPage.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div id="form1" runat="server">
            <User:StaffPage runat="server"/>
        </div>
</asp:Content>
