<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberHome.aspx.cs" Inherits="Project5.WebSite.MemberHome" %>
<%@ Register TagPrefix = "User" TagName="MemberTable" src="~/Components/MemberTable.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div id="form1" runat="server">
            <User:MemberTable runat="server"/>
        </div>
</asp:Content>
