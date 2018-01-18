<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <body>
<form id="form1" runat="server">
<h2>Stationery Catalog List</h2>
  <asp:TextBox ID="TextBox1" placeholder="Search Item Id" runat="server"></asp:TextBox>
<asp:Button ID="Button3" runat="server" Text="Search" />
    <asp:Button ID="Button1" runat="server" Text="Create" />     
<asp:Button ID="Button2" runat="server" Text="Print" />

<div>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
OnRowDeleting="OnRowDeleting"
OnRowEditing="OnRowEditing"
DataKeyNames="ItemID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
<Columns>
<asp:TemplateField HeaderText="ItemId" SortExpression="ItemId">
<ItemTemplate>
<asp:Label ID="Label5" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Category" SortExpression="Category">
<ItemTemplate>
<asp:Label ID="Label6" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description" SortExpression="Description">
<ItemTemplate>
<asp:Label ID="Label7" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ReorderLevel" SortExpression="ReorderLevel">
<ItemTemplate>
<asp:Label ID="Label7" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ReorderQuantity" SortExpression="ReorderQuantity">
<ItemTemplate>
<asp:Label ID="Label7" runat="server" Text='<%# Bind("ReorderQuantity") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnitofMeasure" SortExpression="UnitofMeasure">
<ItemTemplate>
<asp:Label ID="Label7" runat="server" Text='<%# Bind("UnitofMeasure") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
</Columns>
</asp:GridView>
</div>
</form>
</body>
</asp:Content>
