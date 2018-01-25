﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewPurchaseOrder" %>
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
         <asp:Label ID="LblVpo" runat="server" style="text-align: center" Text="View Stationary Purchase Order "></asp:Label></h1>
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
            <asp:Label ID="LblStatus" runat="server"></asp:Label>

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
          </table>
            <tr>
                <asp:ScriptManager ID="sml" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="Upl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewVPO" runat="server" AutoGenerateColumns="False" 
                                        Style="height: 100px; overflow: auto" ShowHeaderWhenEmpty="True"
                                        OnRowDataBound="OnRowDataBound"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ItemID">



                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>
                <asp:TemplateField HeaderText="Item No." HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                                   
                                                            <asp:Label ID="LblItemNo" runat="server" Text='<%# Bind("ItemID") %>' OnTextChanged="Txtitemid_TextChanged" AutoPostBack="true"></asp:Label>
                                                        

                                                
                                                             
                                    </ItemTemplate>
                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDesc" runat="server" ></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                         
                                       
                                        <asp:Label ID="Lblquantity" runat="server" Text='<%# Bind("Quantity") %>' OnTextChanged="Txtquantity_TextChanged" AutoPostBack="true"></asp:Label>
                                                       
                                    </ItemTemplate>
                               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="10%"></HeaderStyle>
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
                                         <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        </asp:GridView> 

                                </ContentTemplate>
                            </asp:UpdatePanel>

            </tr>
                 <tr>
        <td class="auto-style14">
                    <asp:Label ID="totLbl" runat="server" Text="Total:"></asp:Label>
                </td>
       
        <td class="auto-style13">
            <asp:Label ID="totalLbl" runat="server"  Text='<%#:GetTotal()%>'></asp:Label></td>
        </tr>
         
        </div>
</asp:Content>
