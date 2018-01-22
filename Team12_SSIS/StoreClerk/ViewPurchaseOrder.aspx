<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewPurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type="text/css">
        .auto-style1 {
            margin-top: 0px;
            height: 50px;
            width: 11px;
        }
        .auto-style2 {
            height: 50px;
        }
        .auto-style3 {
            height: 50px;
        }
        .auto-style4 {
            height: 50px;
            width: 100px;
        }
        .auto-style6 {
            width: 100px;
        }
        .auto-style7 {
            height: 50px;
            width: 100px;
        }
        .auto-style9 {
            margin-top: 0px;
            height: 50px;
            width: 100px;
        }
        .auto-style11 {
            margin-top: 0px;
            height: 50px;
            width: 100px;
        }
        .auto-style13 {
        width: 76px;
    }
    .auto-style14 {
        width: 11px;
    }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1>
         <asp:Label ID="VpoLbl" runat="server" style="text-align: center" Text="View Stationary Purchase Order "></asp:Label></h1>
        <table><tr>
        <td class="auto-style1">
                    <asp:Label ID="PodLbl" runat="server" Text="PO date:"></asp:Label>
                </td>
             <td class="auto-style2">
            <asp:Label ID="PODateLbl" runat="server"></asp:Label></td><td></td><td class="auto-style4">
                    <asp:Label ID="RstLbl" runat="server" Text="Requested By:"></asp:Label>
                </td>
       
        <td class="auto-style3">
            <asp:Label ID="RequestLbl" runat="server"></asp:Label></td>
        </tr>
            <tr>
                <td class="auto-style14">
                    <asp:Label ID="PosLbl" runat="server" Text="PO Status:"></asp:Label>
                </td>
                <td class="auto-style4">
            <asp:Label ID="StatusLbl" runat="server"></asp:Label>

                </td><td></td><td class="auto-style4">
                    <asp:Label ID="SliLbl" runat="server" Text="Supplier ID:"></asp:Label>
                </td>
                 <td class="auto-style6">
            <asp:Label ID="CodeLbl" runat="server"></asp:Label></td>
        </tr>
             <tr>
                <td class="auto-style14">
                    <asp:Label ID="DltLbl" runat="server" Text="Deliver to:"></asp:Label>
                </td>
                <td class="auto-style7">
            <asp:Label ID="DeliverLbl" runat="server"></asp:Label>

                </td><td></td><td class="auto-style4">
                    <asp:Label ID="OdbLbl" runat="server" Text="Ordered by:"></asp:Label>
                </td>
                 <td class="auto-style8">
            <asp:Label ID="OrderLbl" runat="server"></asp:Label></td>
        </tr>
             <tr>
                <td class="auto-style14">
                    <asp:Label ID="AdsLbl" runat="server" Text="Address:"></asp:Label>
                </td>
                <td class="auto-style9">
            <asp:Label ID="AddressLbl" runat="server"></asp:Label>

                </td><td></td><td class="auto-style6">
                    <asp:Label ID="SibLbl" runat="server" Text="Supply the following items by(date):"></asp:Label>
                </td>
                 <td class="auto-style11">
            <asp:Label ID="SupplyLbl" runat="server"></asp:Label></td>
        </tr>
            <tr>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Item No." HeaderText="Item No." SortExpression="Item No." />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
                <asp:BoundField DataField="Unit Price" HeaderText="Unit Price" SortExpression="Unit Price" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            </Columns>
        </asp:GridView></tr>
                 <tr>
        <td class="auto-style14">
                    <asp:Label ID="totLbl" runat="server" Text="Total:"></asp:Label>
                </td>
       
        <td class="auto-style13">
            <asp:Label ID="totalLbl" runat="server"></asp:Label></td>
        </tr>

        </div>
</asp:Content>
