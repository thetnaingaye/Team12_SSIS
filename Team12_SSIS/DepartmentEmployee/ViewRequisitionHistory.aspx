<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRequisitionHistory.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewRequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1>
         <asp:Label ID="VpoLbl" runat="server" style="text-align: center" Text="List of Past Request"></asp:Label></h1>
        <table><tr>
            <td class="auto-style1">
            <asp:Label ID="EmnLbl" runat="server" Text="Emplyee Name:"></asp:Label>
            <td><asp:Label ID="Name" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="EpnLbl" runat="server" Text="Employee Number:"></asp:Label>
            <td><asp:Label ID="NumberLbl" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="EeaLbl" runat="server" Text="Employee Email Address:"></asp:Label>
            <td><asp:Label ID="AddressLbl" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="DpnLbl" runat="server" Text="Dept Name:"></asp:Label>
            <td><asp:Label ID="DpnameLbl" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="DpcLbl" runat="server" Text="Dept Code:"></asp:Label>
            <td><asp:Label ID="CodeLbl" runat="server"></asp:Label></td>
            </td></tr>
             <tr>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Serial No." HeaderText="Serial No." SortExpression="Serial No." />
                <asp:BoundField DataField="Requisition Form ID" HeaderText="Requisition Form ID" SortExpression="Requisition Form ID" />
                <asp:BoundField DataField="Date Created" HeaderText="Date Created" SortExpression="Date Created" />
                <asp:BoundField DataField="Status" HeaderText="Unit Price" SortExpression="Unit Price" />
                <asp:BoundField DataField="Date Processed" HeaderText="Date Processed" SortExpression="Date Processed" />
                <asp:BoundField DataField="Handled By" HeaderText="Handled By" SortExpression="Handled By" />
            </Columns>
        </asp:GridView></tr>
            <tr>
                <td class="auto-style3">
                    <td><td><td><td> <td > <td> <td>
                <asp:Button ID="btnback" runat="server" Text="Back" Height="27px" Width="64px" /></td></td></td></td></td></td></td>
                </tr>
            





        </div>
</asp:Content>
