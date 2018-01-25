<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupplierList.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewSupplierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Supplier List</h2>
        <asp:Button ID="BtnCreate" runat="server" Text="Create" OnClick="BtnCreate_Click" />
        <br />
        <asp:TextBox ID="TxtSearch" placeholder="Search Supplier" runat="server"></asp:TextBox>
<asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
</div>

    <div>
<asp:GridView ID="GridViewSupplier" runat="server" AutoGenerateColumns="False"
    AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewSupplier_PageIndexChanging"
OnRowCancelingEdit="GridViewSupplier_RowCancelingEdit"
OnRowDataBound="GridViewSupplier_RowDataBound"
OnRowDeleting="GridViewSupplier_RowDeleting"
OnRowEditing="GridViewSupplier_RowEditing"
OnRowUpdating="GridViewSupplier_RowUpdating"
DataKeyNames="SupplierID">
<Columns>
<asp:TemplateField HeaderText="SupplierID" SortExpression="SupplierID">
<ItemTemplate>
<asp:Label ID="LblSupplierID" runat="server" Text='<%# Bind("SupplierID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="SupplierName" SortExpression="SupplierName">
<EditItemTemplate>
<asp:TextBox ID="TxtSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="GSTRegistrationNo" SortExpression="GSTRegistrationNo">
<EditItemTemplate>
<asp:TextBox ID="TxtGSTRegistrationNo" runat="server" Text='<%# Bind("GSTRegistrationNo") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblGSTRegistrationNo" runat="server" Text='<%# Bind("GSTRegistrationNo") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ContactName" SortExpression="ContactName">
<EditItemTemplate>
<asp:TextBox ID="TxtContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PhoneNo" SortExpression="PhoneNo">
<EditItemTemplate>
<asp:TextBox ID="TxtPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="FaxNo" SortExpression="FaxNo">
<EditItemTemplate>
<asp:TextBox ID="TxtFaxNo" runat="server" Text='<%# Bind("FaxNo") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblFaxNo" runat="server" Text='<%# Bind("FaxNo") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address" SortExpression="Address">
<EditItemTemplate>
<asp:TextBox ID="TxtAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OLT" SortExpression="OLT">
<EditItemTemplate>
<asp:TextBox ID="TxtOrderLeadTime" runat="server" Text='<%# Bind("OrderLeadTime") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblOrderLeadTime" runat="server" Text='<%# Bind("OrderLeadTime") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="Discontinue" ShowEditButton="True" EditText="Edit" />
</Columns>
</asp:GridView>
</div>
</asp:Content>
