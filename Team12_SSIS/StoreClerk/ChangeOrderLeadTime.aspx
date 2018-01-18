<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeOrderLeadTime.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ChangeOrderLeadTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <strong>Amend Order Lead Time</strong></p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Supplier Name:"></asp:Label>
        <asp:DropDownList ID="SuppliersDdl" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Order Lead Time (Days):<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="SaveBtn" runat="server" Text="Save" />
    </p>
</asp:Content>
