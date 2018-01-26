<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Stationery Request</h2>

        <asp:TextBox ID="TxtSearch" placeholder="Search Item" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
    <br />
        <asp:Label ID="LblCount" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="GridViewAddRequest" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridViewAddRequest_PageIndexChanging" DataKeyNames="ItemID" CellPadding="4" ForeColor="#333333" GridLines="None" Width="387px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                    <asp:Button ID="BtnAddRequest" runat="server" Text="Add Request" CommandName="AddRequestClicked" CommandArgument='<%# Bind("ItemID") %>'  OnClick ="BtnAddRequest_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
<br />

<asp:GridView ID="GridViewCheckOut" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewCheckOut_RowDataBound"
            OnRowDeleting="GridViewCheckOut_RowDeleting" DataKeyNames="ItemID" CellPadding="4" ForeColor="#333333" GridLines="None" Width="385px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                <asp:TemplateField HeaderText="RequestedQuantity" SortExpression="RequestedQuantity">
                <ItemTemplate>
                    <asp:TextBox ID="TxtRequestedQuantity" runat="server" ontextchanged="TxtRequestedQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="Delete"/>
            </Columns> 
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    <br />
        <asp:Button ID="BtnCheckOut" runat="server" Text="Check Out" OnClick="BtnCheckOut_Click"/>

</asp:Content>
