<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Stationery Request</h2>
        <asp:TextBox ID="TxtSearch" placeholder="Search Item" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
        <br />
        <asp:Label ID="LblCount" runat="server" Text=""></asp:Label>
        <br />
        <asp:LinkButton ID="LinkButtonCount" runat="server" OnClick="LinkButtonCount_Click">View Requested Items</asp:LinkButton>
</div>
<div>
    <asp:GridView ID="GridViewAddRequest" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID">
        <Columns>
            <asp:TemplateField HeaderText="ItemID" SortExpression="ItemID">
                <ItemTemplate>
                    <asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <ItemTemplate>
                    <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="BtnAddRequest" runat="server" Text="Add Request" CommandName="AddRequestClicked" CommandArgument='<%# Bind("ItemID") %>' OnClick="BtnAddRequest_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
