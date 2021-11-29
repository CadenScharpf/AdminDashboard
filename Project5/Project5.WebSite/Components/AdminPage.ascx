<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.ascx.cs" Inherits="Project5.WebSite.Components.AdminPage" %>
<div id="maincontent" runat="server">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">
    <link href="~/Content/dataTables.bootstrap4.css" rel="stylesheet" />
    <p id="labelWarning" runat="server"></p>
    <br />
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
        Add Employee
    </button>    
    <!-- Button trigger delete modal -->
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#DeleteAccModal">
        Remove Employee
    </button>
    <br />
    <%-- Data Table --%>
    <table id="example" class="table table-striped table-bordered" style="width: 100%">
        <thead>
            <tr>
                <th>Username</th>
                <th>Password hash</th>
                <th>Employee since</th>
            </tr>
        </thead>
        <tbody runat="server" id="tbdy"></tbody>
    </table>
    <script src="Scripts/MemberTableInit.js"></script>
    <!-- Add Account Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Staff Credentials</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Username</label>
                        <input type="email" class="form-control" id="UserInput" runat="server" aria-describedby="emailHelp" placeholder="Enter model">
                    </div>
                    <div class="form-group" id="ImeiBox" runat="server">
                        <label id="imeiLabel" for="exampleInputPassword1" runat="server">password</label>
                        <input type="password" class="form-control" id="PassInput" runat="server" placeholder="Imei">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="add btn btn-primary" runat="server" onserverclick="OnAddEmployeeButtonClick">Add Employee</button>
                </div>
            </div>
        </div>
    </div>
        <!-- Delete Account Modal -->
    <div class="modal fade" id="DeleteAccModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="deleteModalLabel">Staff Credentials</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Username</label>
                        <input type="email" class="form-control" id="DeleteUsr" runat="server" aria-describedby="emailHelp" placeholder="Enter model">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="add btn btn-primary" runat="server" onserverclick="OnDeleteButtonClick">Remove Employee</button>
                </div>
            </div>
        </div>
    </div>
</div>
