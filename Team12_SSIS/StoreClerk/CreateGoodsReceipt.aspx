<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateGoodsReceipt.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreateGoodsReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" style="width: 80%">
        <tr>
            <td colspan ="5">
                <asp:label runat="server" text="Create Goods Receipt"></asp:label>
            </td>
        </tr>
        <tr>
            <td width="10%">
                <asp:label runat="server" text="PO Number:"></asp:label>
            </td>
            <td width ="10%">
                <asp:textbox runat="server"></asp:textbox>
                </td>
            
            <td width="70%">
                    <asp:button runat="server" text="Button" />
                </td>

            <td width="90%">
                <asp:label runat="server" text="DO Number"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server"></asp:textbox>
            </td>

        </tr>
    </table>
    </asp:Content>
