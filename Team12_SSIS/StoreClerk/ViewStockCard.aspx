<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStockCard.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewStockCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    
       Enter Item Code: <asp:TextBox ID="TextBox1" runat="server" Width="203px"></asp:TextBox>
         <asp:Button ID="Button1" runat="server" Text="FIND" />
    </p>
    <p>
       
        Item Code:<asp:Label ID="Label1" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" 
        runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
       
      Item Description: <asp:Label ID="Label2" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" 
        runat="server" Text=""></asp:Label>
    </p>
    <p>
       
       <%-- Bin:<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>--%>
        Bin: <asp:Label ID="Label3" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" 
        runat="server" Text=""></asp:Label></p>
    <p>
       
        UOM: <asp:Label ID="Label4" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" 
        runat="server" Text=""></asp:Label>
    </p>
    <p>
       
        First Supplier:<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
    </p>
    <p>
       
        Second supplier:<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
    </p>
    <p>
       
        Third Supplier:<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
    </p>
    <p>
       
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
