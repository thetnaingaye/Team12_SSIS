<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStockCard.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewStockCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Label ID="LblTitle" runat="server" Text="STOCK CARD" Font-Size="Large" ></asp:Label>
   
      <br />
   
    <p>
        <asp:Label ID="LblInput" runat="server" Text="Enter ItemId:"></asp:Label>
        <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="BtnFind" runat="server" CssClass="auto-style1" Text="Find Transaction Details" OnClick="BtnFind_Click" />
      <br />
     <p>
        <asp:Label ID="LblId" runat="server" Text="ItemID:"></asp:Label><asp:Label ID="LblIdD" runat="server" Text="Label" Font-Bold="true" ></asp:Label>
    </p>
    <p>
        <asp:Label ID="LbldDes" runat="server" Text="ItemDescription:"></asp:Label><asp:Label ID="LblDesD" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
         <asp:Label ID="LblBin" runat="server" Text="Bin:"></asp:Label> <asp:Label ID="LblBinD" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
      <asp:Label ID="LblUom" runat="server" Text="UOM:"></asp:Label><asp:Label ID="LblUomD" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
         <asp:Label ID="LblS1" runat="server" Text="Supplier1:"></asp:Label><asp:Label ID="LblS1D" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="LblS2" runat="server" Text="Supplier2:"></asp:Label><asp:Label ID="LblS2D" runat="server" Text="Label" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="LblsS3" runat="server" Text="Supplier3:"></asp:Label><asp:Label ID="LblS3D" runat="server" Text="Label" Font-Bold="true"></asp:Label>
         <br />
         </p>
        <asp:GridView ID="GridViewStockCard" runat="server"  OnRowDataBound="GridViewStockCard_RowDataBound" Autopostback="true">
        </asp:GridView>
   
</asp:Content>
