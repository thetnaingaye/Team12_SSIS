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
                    <asp:Label ID="LblPON" runat="server" Text="PO Number:"></asp:Label>
                    <asp:Label ID="LblNumber" runat="server"></asp:Label>
                </td>
            <td></td><td class="auto-style4">
                    <asp:Label ID="LblRequest" runat="server" Text="Requested By:"></asp:Label>
                </td>
       
        <td class="auto-style3">
            <asp:Label ID="LblRst" runat="server"></asp:Label></td>
        </tr>
            <tr>
                <td class="auto-style14">
                    <asp:Label ID="LblPos" runat="server" Text="PO Status:"></asp:Label>
                </td>
                <td class="auto-style4">
            <asp:Label ID="LblStatus" runat="server" Text="Pending"></asp:Label>

                </td><td></td><td class="auto-style4">
                    <asp:Label ID="LblSli" runat="server" Text="Supplier ID:"></asp:Label>
                </td>
                 <td class="auto-style6">
            <asp:Label ID="LblCode" runat="server"></asp:Label></td>
        </tr>
             <tr>
                <td class="auto-style14">
                    <asp:Label ID="LblDlt" runat="server" Text="Deliver to:"></asp:Label>
                </td>
                <td class="auto-style7">
            <asp:Label ID="LblDeliver" runat="server"></asp:Label>

                </td><td></td><td class="auto-style4">
                    <asp:Label ID="OdbLbl" runat="server" Text="Ordered by:"></asp:Label>
                </td>
                 <td class="auto-style8">
            <asp:Label ID="OrderLbl" runat="server" Text="Logic University Stationery Store"></asp:Label></td>
        </tr>
             <tr>
                <td class="auto-style14">
                    <asp:Label ID="LblAdd" runat="server" Text="Address:"></asp:Label>
                </td>
                <td class="auto-style9">
            <asp:Label ID="LblAddress" runat="server"></asp:Label>

                </td><td></td><td class="auto-style6">
                    <asp:Label ID="LblSib" runat="server" Text="Supply the following items by(date):"></asp:Label>
                </td>
                 <td class="auto-style11">
            <asp:Label ID="LblSupply" runat="server"></asp:Label></td>
        </tr>
            <tr>
                 <asp:GridView ID="GridVPO" runat="server" AutoGenerateColumns="False"
                        Style="height: 100px; overflow: auto; width: 100%" DataKeyNames="PONumber" ShowHeaderWhenEmpty="True" OnRowDataBound="OnRowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Item No." HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblItemNo" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

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
                 <tr>
        <td class="auto-style14">
                    <asp:Label ID="totLbl" runat="server" Text="Total:"></asp:Label>
                </td>
       
        <td class="auto-style13">
            <asp:Label ID="totalLbl" runat="server"  Text='<%#:GetTotal()%>'></asp:Label></td>
        </tr>

        </div>
</asp:Content>
