<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDelegationHistory.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewDelegationHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Delegation History</p>
    <p>
        Select Employee:<asp:DropDownList ID="EmployeesDdl" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:GridView ID="DelegationHistoryGridView" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
