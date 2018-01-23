﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovePurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreManager.StoreSupervisor.ApprovePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 98px;
        }
        .auto-style2 {
            width: 98px;
            height: 24px;
        }
        .auto-style3 {
            height: 24px;
        }
        .auto-style4 {
            width: 98px;
            height: 21px;
        }
        .auto-style5 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1> 
    <asp:Label ID="Label1" runat="server" style="text-align: center" Text="Purchase Order Approval"></asp:Label></h1>
        <table><tr><td class="auto-style1">
            <asp:Label ID="PoLbl" runat="server" Text="PO#:"></asp:Label>
            <td><asp:Label ID="NumberLbl" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="DsmLbl" runat="server" Text="Date Submitted:"></asp:Label>
            <td><asp:Label ID="DateLbl" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="PosLbl" runat="server" Text="PO Status:"></asp:Label>
            <td class="auto-style3"><asp:Label ID="StatusLbl" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="DltLbl" runat="server" Text="Deliver to:"></asp:Label>
            <td><asp:Label ID="DeliverLbl" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style4">
                <asp:Label ID="AdsLbl" runat="server" Text="Address:"></asp:Label>
            <td class="auto-style5"><asp:Label ID="AddressLbl" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style4">
                <asp:Label ID="ResLbl" runat="server" Text="Requested by:"></asp:Label>
            <td class="auto-style5"><asp:Label ID="RequestLbl" runat="server"></asp:Label></td>
            </td></tr>
                <tr><td class="auto-style1">
                <asp:Label ID="SlcLbl" runat="server" Text="Supplier Code:"></asp:Label>
            <td><asp:Label ID="CodeLbl" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="OdbLbl" runat="server" Text="Ordered by:"></asp:Label>
            <td><asp:Label ID="OrderLbl" runat="server"></asp:Label></td>
            </td></tr>
            <tr>
                 <asp:GridView ID="GridViewAPO" runat="server" AutoGenerateColumns="False">
            <Columns>

                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblUom" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Unit Price" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblUnp" runat="server" Width="100%" CssClass="center-block" Text=""></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblPrice" runat="server" Width="100%" CssClass="center-block" Text=""></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            </asp:TemplateField>
            </Columns>
        </asp:GridView></tr>
            <tr><td class="auto-style1"> <asp:Label ID="RmkLbl" runat="server" Text="Remarks :"></asp:Label></td>
                <td><asp:TextBox ID="txtRmk" runat="server"></asp:TextBox> 
                   </tr></td>
            <tr>
                <td class="auto-style2">
                    <td><td><td><td> <td >
                <asp:Button ID="btnapr" runat="server" Text="Approve" Height="27px" Width="64px" /></td></td></td></td></td>
            <td> <td>
                <asp:Button ID="btncancel" runat="server" Text="Reject"  Height="27px" Width="64px" /></td></td>
                </tr></tr>
             <tr>
                <td class="auto-style3">
                    <td><td><td><td> <td > <td> <td>
                <asp:Button ID="btnback" runat="server" Text="Back" Height="27px" Width="64px" /></td></td></td></td></td></td></td>
                </tr>
            







</table>
    </div>
</asp:Content>
