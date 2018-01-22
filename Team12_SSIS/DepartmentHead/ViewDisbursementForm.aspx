<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementForm.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewDisbursementForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="LblDate" runat="server" Text="Date Range:"></asp:Label>
      &nbsp;&nbsp;
     <br />
      <asp:Label ID="LblStartDate" runat="server" Text="Start Date:"></asp:Label>
  
      <!--Calender Script-->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker().datepicker("setDate", new Date());
        });
    </script>
    <script>
        $(function () {
            $("#datepicker2").datepicker().datepicker("setDate", new Date());
        });
    </script>

	&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" id="datepicker" name="datepicker" readonly="true" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="End Date:">

    </asp:Label>&nbsp;<input type="text" id="datepicker2" name="datepicker2" readonly="true" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="BtnFindDate" runat="server" Text="FIND" OnClick="BtnFindDate_Click" Height="25px" />
     <br />
    &nbsp;
&nbsp;&nbsp;
       <br />
    <br />






    <asp:Label ID="LblRep" runat="server" Text="Department Representative:"></asp:Label>
     
     <asp:DropDownList ID="DdlSal" runat="server">
         <asp:ListItem>Mr</asp:ListItem>
         <asp:ListItem>Ms</asp:ListItem>
         <asp:ListItem>Mrs</asp:ListItem>
     </asp:DropDownList> 
       <asp:TextBox ID="TxtRep" runat="server"></asp:TextBox>
     <asp:Button ID="BtnFindrep" runat="server" Text="FIND" OnClick="BtnFindrep_Click" />
     <br />
       <br />
    <asp:GridView ID="GridViewDisbursement" runat="server" DataKeyNames="DisbursementID" OnRowDataBound="GridViewDisbursement_RowDataBound" ItemType="Team12_SSIS.Model.DisbursementList">
        <Columns>
            <asp:HyperLinkField NavigateUrl="~/DepartmentHead/ViewDisbursementList.aspx" Text="Click to see details" />
           
             </Columns>
    </asp:GridView>

     <br />
     <br />

     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

</asp:Content>
