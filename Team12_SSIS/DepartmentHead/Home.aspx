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

    <div class="container-fluid" style="padding: 2px 2px 2px 2px">
        <div class="container-fluid">
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            <div class="row">
                <div class="col-sm-6" style="text-align: left">
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
                <div class="col-sm-6" style="text-align: left">
                    <p style="color: #1A6ECC">Upcoming Collection - number of disbursement lists:</p>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" />
                        </Triggers>
                        <ContentTemplate>
                            <h1 style="color: #1A6ECC"><strong><%= GetDisbursementCount() %></strong></h1>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <br />
            <br />
        </div>


        <br />
        <br />
        <br />


        <!-- Full width Chart-->

        <div class="col-lg-12">
            <a href="ViewRequisitionFormList.aspx" style="text-decoration: none">
                <div class="col-sm-4">
                    <p>Approve requisition.</p>
                    <img src="../Images/check.png" class="img-responsive margin" style="width: 100%" alt="Image" />

                </div>
            </a>
            <a href="ManageDelegation.aspx" style="text-decoration: none">
                <div class="col-sm-4">
                    <p>Manage Delegation.</p>
                    <img src="../Images/requisition.png" class="img-responsive margin" style="width: 100%" alt="Image" />

                </div>
            </a>
            <a href="ManageDelegation.aspx" style="text-decoration: none">
                <a href="ViewDisbursementForm.aspx" style="text-decoration: none">
                    <div class="col-sm-4">
                          <p>View Disbursements</p>
                        <img src="../Images/findout.png" class="img-responsive margin" style="width: 100%" alt="Image" />
                    </div>
                </a>
        </div>


        <br />
        <br />
        <br />

    </div>
</asp:Content>
