<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            padding: 5px 15px 0px 15px;
            text-align: center;
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>

    <asp:Timer ID="Timer3" runat="server" Interval="600000"></asp:Timer>

    <div class="container-fluid">
        <div class="container-fluid" style="padding: 50px 2px 50px 80px">
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            <a href="ViewRequisitionFormList.aspx" style="text-decoration: none">
                <div class="col-sm-5" style="text-align: left; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                    <p style="color: #1A6ECC">No of pending requisitions:</p>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" />
                        </Triggers>
                        <ContentTemplate>
                            <h1 style="color: #1A6ECC"><strong><%= GetPendingRequestCount() %></strong></h1>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </a>
            <div class="col-sm-2">
                <div class="panel">
                </div>

            </div>
            <a href="ManageDepartmentRep.aspx" style="text-decoration: none">
                <div class="col-sm-5" style="text-align: left; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                    <p style="color: #1A6ECC">Current department representative:</p>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" />
                        </Triggers>
                        <ContentTemplate>
                            <h2 style="color: #1A6ECC"><strong><%= GetRep() %></strong></h2>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </a>
            <br />
            <br />
        </div>


        <br />
        <br />
        <br />


        <!-- Full width Chart-->

        <div class="container-fluid" style="padding: 2px 2px 20px 100px">
            <a href="ViewRequisitionFormList.aspx" style="text-decoration: none">
                <div class="col-sm-4">
                    <p>Approve requisition.</p>
                    <img src="../Images/approvereq.png" class="img-responsive margin" style="width: 70%" alt="Image" />

                </div>
            </a>
            <a href="ManageDelegation.aspx" style="text-decoration: none">
                <div class="col-sm-4">
                    <p>Manage Delegation.</p>
                    <img src="../Images/managedis.png" class="img-responsive margin" style="width: 70%" alt="Image" />

                </div>
            </a>
            <a href="ViewDisbursementForm.aspx" style="text-decoration: none">
                <div class="col-sm-4">
                    <p>View Disbursements</p>
                    <img src="../Images/viewreq.png" class="img-responsive margin" style="width: 70%" alt="Image" />
                </div>
            </a>
        </div>


        <br />
        <br />
        <br />

    </div>
</asp:Content>
