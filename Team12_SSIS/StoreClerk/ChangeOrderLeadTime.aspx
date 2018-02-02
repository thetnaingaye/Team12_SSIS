<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeOrderLeadTime.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ChangeOrderLeadTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <h2>Amend Order Lead Time</h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Supplier Name:"></asp:Label>
        <asp:DropDownList ID="SuppliersDdl" runat="server" OnSelectedIndexChanged="SuppliersDdl_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        Current Order Lead Time: <asp:Label ID="LblCurrentOrderLeadTime" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        Order Lead Time (Days): <asp:TextBox ID="OrderLeadTimeTxt" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="SaveBtn" CssClass="btn btn-primary" runat="server" OnClick="SaveBtn_Click" Text="Save" />
    </p>
    <p>
        <asp:Label ID="ChangedLbl" runat="server" Visible="False"></asp:Label>
    </p>
</asp:Content>
