<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project5.WebSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <input id="in2" value="Press reset to default accounts" runat="server" type="button" onserverclick="OnIn2Click" />
        <p class="lead">This is a mock up of a cell providers website where members can manually enter their Imei numbers and purchase a service plan</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Default admin credentials</h2>
            <p>Username: admin</p>
            <p>Password: pass</p>
        </div>
        <div class="col-md-4">
            <h2>Staff credentials for testing</h2>
            <p>Username: TA</p>
            <p>Password: Cse445ta!</p>
        </div>
        <div class="col-md-4">
            <h2>Member credentials for testing</h2>
            <p>Username: testMember</p>
            <p>Password: password</p>
        </div>

    </div>

</asp:Content>
