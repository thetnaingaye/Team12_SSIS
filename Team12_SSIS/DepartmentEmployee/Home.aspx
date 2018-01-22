<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        This is an employee page</p>
    <p>
        <asp:Label ID="LblUserName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        change name
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </p>
    <p>
        change email
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    </p>
</asp:Content>
