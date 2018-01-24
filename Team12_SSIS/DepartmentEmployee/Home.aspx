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
    <div class="container-fluid">
                <asp:Xml ID="Xml1" runat="server"></asp:Xml>

      <!-- Second Container - quick research-->
    <div class="col-lg-12 text-center">
        <h3 class="margin">Looking for an item</h3>
        <p>It's one click away. </p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" />
    </div>
    <br />
    <br />
    <!-- Third Container - quick buttons -->

        <div class="row">
            <div class="col-sm-4">
                <p>Raise another requisition.</p>
                <img src="../Images/birds3.jpg"" class="img-responsive margin" style="width: 100%" alt="Image"/>
            </div>
            <div class="col-sm-4">
                <p>Check the status of recent requests.</p>
                <img src="../Images/birds2.jpg"" class="img-responsive margin" style="width: 100%" alt="Image"/>
            </div>
            <div class="col-sm-4">
                <p>When and where is the next collection?</p>
                <a href="#"><img src="../Images/birds1.jpg"" class="img-responsive margin" style="width: 100%" alt="Image"/></a>
            </div>
        </div>
    </div>
</asp:Content>
