<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.Home" %>

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
    <!-- First Container - quick research-->
    <div class="container-fluid" style="padding: 0px 0px 0px 150px">

        <!-- Third Container - quick buttons -->

        <div class="row" style="align-content: center">
            <a href="ViewCatalogue.aspx" style="text-decoration: none">
                <div class="col-sm-6">

                    <img src="../Images/requisition.png" class="img-responsive margin" style="width: 60%" alt="Image" />
                    <h5>Raise another requisition...</h5>
                </div>
            </a>
            <div class="col-sm-6" style="text-combine-upright: all">
                <div class="panel">
                </div>

            </div>
        </div>
        <div class="row" style="align-content: center">


            <div class="col-sm-6" style="align-content: center">
                <div class="panel">
                </div>
            </div>
            <a href="ViewRequisitionHistory.aspx" style="text-decoration: none">
                <div class="col-sm-6" style="align-content: center">

                    <img src="../Images/check.png" class="img-responsive margin" style="width: 60%" alt="Image" />
                    <h5>Check the status of recent requests...</h5>
                </div>
            </a>
        </div>
    </div>
</asp:Content>
