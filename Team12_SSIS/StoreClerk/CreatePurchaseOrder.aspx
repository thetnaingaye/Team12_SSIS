﻿<%@ Page Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreatePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
            height: 50px;
            width: 707px;
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
        .auto-style5 {
            height: 50px;
            width: 100px;
        }
        .auto-style6 {
            width: 100px;
        }
        .auto-style7 {
            height: 50px;
            width: 707px;
        }
        .auto-style8 {
            width: 707px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
    <asp:Label ID="RpoLbl" runat="server" style="text-align: center" Text="Raise Stationary Purchase Order "></asp:Label>
         
    <table><tr>
        <td class="auto-style1">
                    <asp:Label ID="PodLbl" runat="server" Text="PO date:"></asp:Label>
                </td>
       
        <td class="auto-style2">
            <asp:Label ID="PODateLbl" runat="server"></asp:Label></td>
        </tr>
         <tr>
                <td class="auto-style7">
                    <asp:Label ID="DltLbl" runat="server" Text="Deliver to :"></asp:Label>
                </td>
             <td class="auto-style4">
                    <asp:TextBox ID="txtDlt" runat="server"></asp:TextBox> </td><td></td>
             <td class="auto-style5">
                    <asp:Label ID="SlcLbl" runat="server" Text="Supplier code:"></asp:Label>
                </td><td class="auto-style6">
             <asp:DropDownList ID="ddlSlc" runat="server" Height="27px" Width="131px"></asp:DropDownList></td>
             <tr>
              <td class="auto-style7">
                    <asp:Label ID="AdsLbl" runat="server" Text="Address:"></asp:Label>
                </td>
             <td class="auto-style3">
                 <asp:TextBox ID="txtAds" runat="server"></asp:TextBox>   </td><td class="auto-style3"></td>
             <td class="auto-style5">
             <tr><td class="auto-style7">
                  <asp:Label ID="SidLbl" runat="server" Text="Please supply the items by(date):"></asp:Label></td>
                 <td class="auto-style9">
            <asp:TextBox ID="txtSid" runat="server" Height="16px" Width="122px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="22px" ImageUrl="~/Images/2-2-calendar-png-image.png" OnClick="ImageButton1_Click" />
        </td>
        <td class="auto-style10">
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar> 
            </td>
             <td class="auto-style6">
                    <asp:Label ID="OdbLbl" runat="server" Text="Ordered by:"></asp:Label>
                </td> <td class="auto-style12">
                    <asp:TextBox ID="txtord" runat="server"></asp:TextBox> </td>
                </td></tr>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Item ID">
                        <ItemTemplate>
                            <asp:TextBox ID="txtitemid" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                         </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtquantity" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UOM">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddluom" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price">
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                    </asp:TemplateField>
               </Columns>
            </asp:GridView>
        <tr>
        <td class="auto-style1">
                    <asp:Label ID="totLbl" runat="server" Text="Total:"></asp:Label>
                </td>
       
        <td class="auto-style2">
            <asp:Label ID="totalLbl" runat="server"></asp:Label></td>
        </tr>
        <tr><tr><td><td><td>
            <td class="auto-style1">
                <asp:Button ID="btSfa" runat="server" Text="Submit for approval" /></td></td></td>
            <td> <td>
                <asp:Button ID="btcancel" runat="server" Text="Cancel" /></td></td>
                </tr></tr>
    </table>
                 
    </div>
    </asp:Content>
    

 
          

