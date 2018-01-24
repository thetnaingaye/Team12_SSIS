<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDelegationHistory.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewDelegationHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Delegation History</p>
    <p>
        Search Employee:<asp:TextBox ID="SearchTxt" runat="server"></asp:TextBox>
        <asp:Button ID="SearchBtn" runat="server" OnClick="SearchBtn_Click" Text="Search" />
        <asp:Button ID="ViewAllBtn" runat="server" OnClick="ViewAllBtn_Click" Text="View All" />
    </p>
    <p>
        <asp:GridView ID="GridViewDelegationHistory" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
