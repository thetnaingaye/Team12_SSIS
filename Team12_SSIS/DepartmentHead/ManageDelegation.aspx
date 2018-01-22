<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDelegation.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ManageDelegation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <strong>Manage Delegation </strong>&nbsp;&nbsp;
    <br />
    <br />
    Delegate:<asp:DropDownList ID="EmployeesDdl" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    From:<asp:Calendar ID="StartCal" runat="server"></asp:Calendar>
    <br />
    To:<asp:Calendar ID="EndCal" runat="server"></asp:Calendar>
    <br />
    <asp:Button ID="ApplyBtn" runat="server" Text="Apply" OnClick="ApplyBtn_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="CancelDelegationBtn" runat="server" Text="Cancel Delegation" />
    <br />
    <br />
    <strong>Employees Delegated:</strong><br />
    <asp:GridView ID="DelegatesListGridView" runat="server">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Amend" ShowHeader="True" Text="Edit" />
        </Columns>
    </asp:GridView>
</asp:Content>
