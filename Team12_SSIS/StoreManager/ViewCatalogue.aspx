<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Stationery Catalog List</h2>
    <asp:Button ID="BtnCreate" runat="server" Text="Create" OnClick="BtnCreate_Click" />     
<asp:Button ID="BtnPrint" runat="server" Text="Print" />
        <br />
        <asp:TextBox ID="TxtSearch" placeholder="Search Item" runat="server"></asp:TextBox>
<asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
</div>
<div>
<asp:GridView ID="GridViewCatalogue" runat="server" AutoGenerateColumns="False"
OnRowCancelingEdit="GridViewCatalogue_RowCancelingEdit"
OnRowDataBound="GridViewCatalogue_RowDataBound"
OnRowDeleting="GridViewCatalogue_RowDeleting"
OnRowEditing="GridViewCatalogue_RowEditing"
OnRowUpdating="GridViewCatalogue_RowUpdating"
DataKeyNames="ItemID">
<Columns>
<asp:TemplateField HeaderText="ItemID" SortExpression="ItemID">
<ItemTemplate>
<asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID">
<ItemTemplate>
<asp:Label ID="LblCategoryID" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description" SortExpression="Description">
<EditItemTemplate>
<asp:TextBox ID="TxtDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ReorderLevel" SortExpression="ReorderLevel">
<EditItemTemplate>
<asp:TextBox ID="TxtReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ReorderQty" SortExpression="ReorderQty">
<EditItemTemplate>
<asp:TextBox ID="TxtReorderQty" runat="server" Text='<%# Bind("ReorderQty") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblReorderQty" runat="server" Text='<%# Bind("ReorderQty") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM" SortExpression="UOM">
<EditItemTemplate>
<asp:TextBox ID="TxtUOM" runat="server" Text='<%# Bind("UOM") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblUOM" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
</Columns>
</asp:GridView>
</div>
</asp:Content>
