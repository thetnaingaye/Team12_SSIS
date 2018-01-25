<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupplierList.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewSupplierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Supplier List</h2>
        </div>
    <div>
        <asp:LinkButton ID="LinkButtonCreate" runat="server" Text="Create New Supplier" OnClick="LinkButtonCreate_Click" />
        <br />
        <br />
        <asp:TextBox ID="TxtSearch" placeholder="Search Supplier" runat="server"></asp:TextBox>
<asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
        <br /><br />
</div>

    <div>
<asp:GridView ID="GridViewSupplier" runat="server" AutoGenerateColumns="False" BackColor="White"
Width="75%" Height="132px"
    AllowPaging="true" PageSize="8" OnPageIndexChanging="GridViewSupplier_PageIndexChanging"
    CellPadding="4" ForeColor="#333333" 
OnRowCancelingEdit="GridViewSupplier_RowCancelingEdit"
OnRowDataBound="GridViewSupplier_RowDataBound"
OnRowEditing="GridViewSupplier_RowEditing"
OnRowUpdating="GridViewSupplier_RowUpdating"
DataKeyNames="SupplierID">
    <HeaderStyle CssClass="gridViewHeader" />
    <RowStyle CssClass="gridViewRow" />
    <AlternatingRowStyle CssClass="gridViewAltRow" />
    <pagersettings mode="Numeric"
          position="Bottom"   />
<Columns>
<asp:TemplateField HeaderText="SupplierID" SortExpression="SupplierID">
<ItemTemplate>
<asp:Label ID="LblSupplierID" runat="server" Text='<%# Bind("SupplierID") %>'></asp:Label>
</ItemTemplate>
    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="text-center" Font-Size="Medium" Width="20%"></HeaderStyle>
            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField HeaderText="SupplierName" SortExpression="SupplierName">
<EditItemTemplate>
<asp:TextBox ID="TxtSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
</ItemTemplate>
    <HeaderStyle CssClass="text-center" Font-Size="Medium" Width="20%"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
</asp:TemplateField>
<asp:TemplateField HeaderText="GSTRegistrationNo" SortExpression="GSTRegistrationNo">
<EditItemTemplate>
<asp:TextBox ID="TxtGSTRegistrationNo" runat="server" Text='<%# Bind("GSTRegistrationNo") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblGSTRegistrationNo" runat="server" Text='<%# Bind("GSTRegistrationNo") %>'></asp:Label>
</ItemTemplate>
    <HeaderStyle CssClass="text-center" Font-Size="Medium" Width="50%"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
</asp:TemplateField>
<asp:TemplateField HeaderText="ContactName" SortExpression="ContactName">
<EditItemTemplate>
<asp:TextBox ID="TxtContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
</ItemTemplate>
    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="text-center" Font-Size="Medium" Width="45%"/>
            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField HeaderText="PhoneNo" SortExpression="PhoneNo">
<EditItemTemplate>
<asp:TextBox ID="TxtPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>'></asp:Label>
</ItemTemplate>
     <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="text-center" Font-Size="Medium" Width="45%"></HeaderStyle>
            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField HeaderText="FaxNo" SortExpression="FaxNo">
<EditItemTemplate>
<asp:TextBox ID="TxtFaxNo" runat="server" Text='<%# Bind("FaxNo") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblFaxNo" runat="server" Text='<%# Bind("FaxNo") %>'></asp:Label>
</ItemTemplate>
       <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" CssClass="text-center" Font-Size="Medium" Width="45%"></HeaderStyle>
            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center"  />
</asp:TemplateField>
<asp:TemplateField HeaderText="Address" SortExpression="Address">
<EditItemTemplate>
<asp:TextBox ID="TxtAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
</ItemTemplate>
        <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" CssClass="text-center" Font-Size="Medium" Width="45%"></HeaderStyle>
            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center"  />
</asp:TemplateField>
<asp:TemplateField HeaderText="Order Lead Time" SortExpression="OLT">
<EditItemTemplate>
<asp:TextBox ID="TxtOrderLeadTime" runat="server" Text='<%# Bind("OrderLeadTime") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="LblOrderLeadTime" runat="server" Text='<%# Bind("OrderLeadTime") %>'></asp:Label>
</ItemTemplate>
        <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" CssClass="text-center" Font-Size="Medium" Width="45%"></HeaderStyle>
            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center"  />
</asp:TemplateField>
    <asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
    <EditItemTemplate>
        <asp:DropDownList ID="DdlDiscontinued" runat="server" AutoPostBack="true">
            <asp:ListItem Selected="True" Value="N"> N </asp:ListItem>
            <asp:ListItem Value="Y"> Y </asp:ListItem>
        </asp:DropDownList>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="LblDiscontinued" runat="server" Text='<%# Bind("Discontinued") %>'></asp:Label>
    </ItemTemplate>
    <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" CssClass="text-center" Font-Size="Medium" Width="45%"></HeaderStyle>
            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center"  />
</asp:TemplateField>
<asp:CommandField ButtonType="Button"  ShowEditButton="True" EditText="Edit" CancelText="Cancel"/>
</Columns>
</asp:GridView>
</div>
</asp:Content>
