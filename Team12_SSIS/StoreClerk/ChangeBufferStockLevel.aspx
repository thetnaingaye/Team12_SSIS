<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeBufferStockLevel.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ChangeBufferStockLevel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <strong>Ammend Buffer Stock Level</strong></p>
    <p>
        Item Code:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="FindBtn" runat="server" Text="Find" />
&nbsp; Item Description:<asp:Label ID="ItemDescriptionLbl" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="AutomationStatusLbl" runat="server"></asp:Label>
    </p>
    <p>
        Indicate desired buffer stock level:</p>
    <p>
        <asp:RadioButton ID="ProportionalRbtn" runat="server" Text="Proportional" />
        (%)<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:RadioButton ID="AbsoluteRbtn" runat="server" Text="Absolute" />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:RadioButton ID="AutomationRbtn" runat="server" Text="Calculate Automatically" />
    </p>
    <p>
        <asp:Button ID="SaveBtn" runat="server" Text="Save" />
    </p>
    <p>
        <asp:Label ID="StatusChangedLbl" runat="server"></asp:Label>
    </p>
</asp:Content>
