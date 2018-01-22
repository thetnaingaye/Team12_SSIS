<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfPurchaseOrders.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ListOfPurchaseOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 25px;
        }
        .auto-style4 {
            height: 25px;
            width: 442px;
        }
        .auto-style5 {
            width: 442px;
        }
        .auto-style6 {
            height: 25px;
            width: 27px;
        }
        .auto-style7 {
            width: 27px;
        }
        .auto-style8 {
            margin-left: 1112px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1> 
    <asp:Label ID="Label1" runat="server" style="text-align: center" Text="List of Purchase Order "></asp:Label></h1>
        <table> <tr><td class="auto-style2"><td class="auto-style2"><td class="auto-style2"><td class="auto-style2"><td class="auto-style4">
            <td class="auto-style6">
            <asp:Label ID="UserLbl" runat="server" Text="User:"></asp:Label>
        
                </td>
            <td class="auto-style2">
            <asp:Label ID="ULbl" runat="server"></asp:Label></td>
            <td class="auto-style2">
                </td><td class="auto-style2">
            <td class="auto-style2">
                <asp:Label ID="RoleLbl" runat="server" Text="Role:"></asp:Label>
            <asp:Label ID="RLbl" runat="server"></asp:Label></td></td></tr></tr></td></td></td></td></td>
            <tr><td><td><td><td><td class="auto-style5">
               <td class="auto-style7"> <asp:Label ID="ShowLbl" runat="server" Text="Show:"></asp:Label>  </td>
                  <td> <asp:DropDownList ID="ddlShow" runat="server" Height="16px" Width="117px"></asp:DropDownList></td></tr></tr></td></td></td></td></td>
        <tr>
            <td >
                <asp:GridView ID="GridViewLPO" runat="server" AutoGenerateColumns="False">
                    <Columns>
                    <asp:BoundField DataField="PO#" HeaderText="PO#" SortExpression="PO#" />
                    
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        
                        <asp:BoundField DataField="DateProcessed" HeaderText="DateProcessed" SortExpression="DateProcessed" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="RequestedBy" SortExpression="CreatedBy" />
                        
                    </Columns>
                </asp:GridView>
                </tr></td>
                <td>
                <asp:Button ID="backBtn" runat="server" Text="Back"  /></td>

</div>

        </table>

</asp:Content>






















