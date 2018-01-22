<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOutRequest.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.CheckOutRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Stationery Request Check Out</h2>
</div>
    <div>
        <asp:GridView ID="GridViewCheckOut" runat="server" AutoGenerateColumns="False"
            OnRowDeleting="GridViewCheckOut_RowDeleting" DataKeyNames="ItemID">
            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:TemplateField HeaderText="RequestedQuantity" SortExpression="RequestedQuantity">
                <ItemTemplate>
                    <asp:TextBox ID="TxtRequestedQuantity" runat="server" Text='<%# Bind("RequestedQuantity") %>'></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True"/>
            </Columns>
        </asp:GridView>
        <asp:Button ID="BtnCheckOut" runat="server" Text="Check Out" OnClick="BtnCheckOut_Click"/>
        <asp:Label ID="LblStatus" runat="server" forecolor="red" Text=""></asp:Label>
    </div>
</asp:Content>
