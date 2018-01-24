<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDepartmentRep.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ManageDepartmentRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="CurrentRepTextLbl" runat="server" Text="Current Representative:"></asp:Label>
    <asp:Label ID="CurrentRepLbl" runat="server"></asp:Label>
    <br />
    <asp:Label ID="NewRepTextLbl" runat="server" Text="New Representative:"></asp:Label>
    <asp:DropDownList ID="EmployeesDdl" runat="server">
        <asp:ListItem>
        </asp:ListItem>
        
    </asp:DropDownList>
    <br />
    <asp:Button ID="AssignRepBtn" runat="server" OnClick="AssignRepBtn_Click" Text="Assign Representative" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
    <br />
    <asp:Label ID="NewRepAssignedLbl" runat="server"></asp:Label>
    <br />
</asp:Content>
