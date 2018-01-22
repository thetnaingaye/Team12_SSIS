<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInventoryList.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewInventoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Label ID="LblInput" runat="server" Text="Filter By:"></asp:Label>
   
&nbsp;
     <asp:RadioButtonList ID="RbtnFilter" runat="server" CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal" OnSelectedIndexChanged="Rbtn_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="1" Text="ItemCode" />
            <asp:ListItem Value="2" Text="Catagory" />
</asp:RadioButtonList>
   
    <asp:Label ID="LblItemCode" runat="server" Text="ItemCode:"></asp:Label>
    <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnId" runat="server" Text="SUBMIT" OnClick="BtnId_Click"  />
    <br />
      <asp:Label ID="LblCatagory" runat="server" Text="Catagory:"></asp:Label>
    <asp:DropDownList ID="DdlCatagory" runat="server">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnCatagory" runat="server" Text="SUBMIT" OnClick="BtnCatagory_Click" />
    <br />
    <br />
    <asp:Label ID="LblCatName" runat="server" Text="Catagory:"></asp:Label> <asp:Label ID="LblCatNameD" runat="server" Text=""></asp:Label><br />
     <asp:Label ID="LblId" runat="server" Text="CatagoryID:"></asp:Label> <asp:Label ID="LblIdD" runat="server" Text=""></asp:Label><br />
      <asp:Label ID="LblReorder" runat="server" Text="ReorderLevel:"></asp:Label> <asp:Label ID="LblReorderD" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="LblReorderQty" runat="server" Text="ReorderQuantity:"></asp:Label> <asp:Label ID="LblReorderQtyD" runat="server" Text=""></asp:Label><br />
      <asp:Label ID="LblUOM" runat="server" Text="Unit of Measurement:"></asp:Label> <asp:Label ID="LblUOMD" runat="server" Text=""></asp:Label>
    <br />
    <br />

    
    <asp:GridView ID="GridViewInventory" runat="server" OnRowDataBound="GridViewInventory_RowDataBound">
    </asp:GridView>
    <br />
    <asp:Label ID="LblMsg" runat="server" Text="" ForeColor="Green"></asp:Label>
    </asp:Content>
