<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOutRequest.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.CheckOutRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Stationery Request Check Out</h2>
<asp:LinkButton ID="LinkButtonViewCatalogue" runat="server" OnClick="LinkButtonViewCatalogue_Click">View Catalogue</asp:LinkButton>
    </div>
    <div>
        <asp:GridView ID="GridViewCheckOut" runat="server" AutoGenerateColumns="False"
            OnRowDeleting="GridViewCheckOut_RowDeleting" DataKeyNames="ItemID">
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
                
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True"/>
            </Columns> 
        </asp:GridView>
        <asp:Button ID="BtnCheckOut" runat="server" Text="Check Out" OnClick="BtnCheckOut_Click"/>
    </div>
</asp:Content>
