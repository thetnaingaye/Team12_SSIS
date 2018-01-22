<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Stationery Request</h2>
        <asp:TextBox ID="TxtSearch" placeholder="Search Item" runat="server"></asp:TextBox>
<asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
</div>
    <div>
        <asp:GridView ID="GridViewAddRequest" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="BtnAddRequest" Text="Add" runat="server" OnClick="BtnAddRequest_Click"/>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
