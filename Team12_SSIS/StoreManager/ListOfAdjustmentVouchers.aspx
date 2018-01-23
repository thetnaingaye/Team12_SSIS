<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfAdjustmentVouchers.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ListOfAdjustmentVouchers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div>
        <table style="width: 100%">
                <tr>
                    <td style="height: 25px">
                        <asp:Label runat="server" Text="List Inventory Adjustment Vouchers" Font-Size="Large"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Show: " Style="padding-right: 10px"></asp:Label>
                        <asp:DropDownList ID="DdlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Pending">Pending</asp:ListItem>
                            <asp:ListItem Value="Approved">Approved</asp:ListItem>
                            <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                             <asp:ListItem Value="RequestsToHandle">RequestsToHandle</asp:ListItem>
                            <asp:ListItem Value="All">All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>

                            