<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberTable.ascx.cs" Inherits="Project5.WebSite.userControls" %>
<div id="maincontent" runat="server">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">
    <link href="~/Content/dataTables.bootstrap4.css" rel="stylesheet" />
    <p id="labelWarning" runat="server"></p>
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
        Add Device
    </button>
    <br />
    <%-- Data Table --%>
    <table id="example" class="table table-striped table-bordered" style="width: 100%">
        <thead>
            <tr>
                <th>Device Model</th>
                <th>Imei Number</th>
                <th>Activation Status</th>
            </tr>
        </thead>
        <tbody runat="server" id="tbdy"></tbody>
    </table>
    <script src="Scripts/MemberTableInit.js"></script>

    <!-- Add Device Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Device model</label>
                        <input type="email" class="form-control" id="ModelInput" runat="server" aria-describedby="emailHelp" placeholder="Enter model">
                    </div>
                    <div class="form-group"  id="ImeiBox" runat="server">
                        <label id="imeiLabel" for="exampleInputPassword1" runat="server">Imei no.</label>
                        <input type="password" class="form-control" id="ImeiInput" runat="server" placeholder="Imei">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="add btn btn-primary" runat="server" onserverclick="OnAddDeviceButtonClick">Add device</button>
                </div>
            </div>
        </div>
    </div>
</div>
