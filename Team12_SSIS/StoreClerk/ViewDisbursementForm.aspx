
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementForm.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewDisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="LblTitle" runat="server" Text="DisbursementList" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LblDate" runat="server" Text="Filter by date range:"></asp:Label>
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
    <asp:Label ID="Label2" runat="server" Text="End Date:"> </asp:Label>&nbsp;<input type="text" id="datepicker2" name="datepicker2" readonly="true" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="BtnFindDate" runat="server" Text="FIND" OnClick="BtnFindDate_Click" Height="25px" />
     <br />
    &nbsp;
&nbsp;&nbsp;
       <br />
    <br />






    <asp:Label ID="LblDep" runat="server" Text="Department :"></asp:Label>
     
     <asp:DropDownList ID="DdlDep" runat="server">
         <asp:ListItem></asp:ListItem>
         <asp:ListItem></asp:ListItem>
         <asp:ListItem></asp:ListItem>
     </asp:DropDownList> 
       &nbsp; 
       &nbsp;
     <asp:Button ID="BtnFinddep" runat="server" Text="FIND" OnClick="BtnFindrep_Click" />
     <br />
       <br />
    <asp:GridView ID="GridViewDisbursement" runat="server"    autogeneratecolumns="true" ItemType="Team12_SSIS.Model.DisbursementList" DataKeyNames="DisbursementID">
        <Columns>
            <asp:TemplateField HeaderText="Click to see details">
                <ItemTemplate>
                    <%--<asp:Button ID="BtnLink" runat="server" Text="click to see details" CommandName="gridviewbuttonclick"  CommandArgument="<%#Item.DisbursementID %>" OnClick="btnView_click"  />--%>
                <asp:LinkButton ID="btnDetails" runat="server" CommandArgument='<%#Eval("DisbursementID")%>' OnCommand="Btndetailclick" Text="Details">
                      </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
             </Columns>
    </asp:GridView>

     <br />

     <br />
  
   
     <br />

     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

</asp:Content>

