<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDelegation.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ManageDelegation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    
    <strong>Manage Delegation </strong>&nbsp;&nbsp;
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            Current Delegate:
            <asp:Label ID="LblCurrentDelegate" runat="server"></asp:Label>
            <br />
            From:<asp:Label ID="LblCurrentDelStartDate" runat="server"></asp:Label>
            &nbsp;&nbsp; To:<asp:Label ID="LblCurrentDelEndDate" runat="server"></asp:Label>
            <br />
            <asp:Button ID="BtnEdit" runat="server" OnClick="BtnEdit_Click" Text="Edit" />
            <asp:Button ID="CancelDelegationBtn" runat="server" OnClick="CancelDelegationBtn_Click" Text="Cancel Delegation" />
        </asp:View>
        <br />
        <asp:View ID="View2" runat="server">
            Delegate:<asp:Label ID="LblCurrentDelegateView2" runat="server"></asp:Label>
            <br />
            From:
            <asp:Calendar ID="CalStartEditDelegate" runat="server"></asp:Calendar>
            <br />
            To:
            <asp:Calendar ID="CalEndEditDelegate" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="ApplyBtn" runat="server" OnClick="ApplyBtn_Click" Text="Apply" />
        </asp:View>
        <br />
        <asp:View ID="View3" runat="server">
            Delegate:<asp:DropDownList ID="EmployeesDdl" runat="server">
            </asp:DropDownList>
            <br />
            From:<asp:Calendar ID="CalStartAddDelegate" runat="server"></asp:Calendar>
            <br />
            To:<asp:Calendar ID="CalEndAddDelegate" runat="server"></asp:Calendar>
            <asp:Button ID="BtnAddDelegate" runat="server" OnClick="BtnAddDelegate_Click" Text="Add Delegate" />
            <br />
        </asp:View>
        <br />
        <br />
    </asp:MultiView>
     <br />
    <br />
    
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <br />
    </asp:Content>
