<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Stationery Catalog List</h2>
  <asp:TextBox ID="TextBox1" placeholder="Search Item Id" runat="server"></asp:TextBox>
<asp:Button ID="Button3" runat="server" Text="Search" />
    <asp:Button ID="Button1" runat="server" Text="Create" />     
<asp:Button ID="Button2" runat="server" Text="Print" />



</asp:Content>
