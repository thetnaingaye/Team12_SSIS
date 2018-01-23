<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInventoryList.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewInventoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LblTitle" runat="server" Text="Inventory List" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LblInput" runat="server" Text="Choose item to filter the inventory list:"></asp:Label><asp:RadioButtonList ID="RbtnFilter" runat="server" AutoPostBack="True" CellPadding="2" CellSpacing="2" OnSelectedIndexChanged="Rbtn_SelectedIndexChanged" RepeatDirection="Horizontal">
        <asp:ListItem Text="ItemCode" Value="1" />
        <asp:ListItem Text="Catagory" Value="2" />
    </asp:RadioButtonList>
   

   
    <br />
    <asp:Label ID="LblItemCode" runat="server" Text="ItemCode:"></asp:Label>
    <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnId" runat="server" Text="SUBMIT" OnClick="BtnId_Click"  />
    <br />
      <br />
      <asp:Label ID="LblCatagory" runat="server" Text="Catagory:"></asp:Label>
    &nbsp;<asp:DropDownList ID="DdlCatagory" runat="server">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnCatagory" runat="server" Text="SUBMIT" OnClick="BtnCatagory_Click" />
    <br />
    <br />
    <asp:Label ID="LblCatName" runat="server" Text="Catagory:"></asp:Label> <asp:Label ID="LblCatNameD" runat="server" Text=""></asp:Label><br />
     <asp:Label ID="LblId" runat="server" Text="CatagoryID:"></asp:Label> <asp:Label ID="LblIdD" runat="server" Text=""></asp:Label><br />
      <asp:Label ID="LblReorder" runat="server" Text="ReorderLevel:"></asp:Label> <asp:Label ID="LblReorderD" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="LblReorderQty" runat="server" Text="ReorderQuantity:"></asp:Label> <asp:Label ID="LblReorderQtyD" runat="server" Text=""></asp:Label><br />
      <asp:Label ID="LblUOM" runat="server" Text="Unit of Measurement:"></asp:Label> <asp:Label ID="LblUOMD" runat="server" Text=""></asp:Label>
    <br />

    <%--Gridview formatting--%>
    <asp:GridView ID="GridViewInventory" runat="server"   AutoGenerateColumns="false" Width="75%"  datakeynames="ItemID" ItemType="Team12_SSIS.Model.InventoryCatalogue" BackColor="White" >
         <HeaderStyle BackColor="#6495ED" Font-Bold="false" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" >
          </HeaderStyle>
        

    <Columns>
        <asp:TemplateField HeaderText="ItemID">
            <ItemTemplate>
                <asp:Label ID="LblitemId" runat="server" Text="<%#:Item.ItemID %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
                <asp:Label ID="Lbldes" runat="server" Text="<%#:Item.Description %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="BIN">
            <ItemTemplate>
                <asp:Label ID="LblBin" runat="server" Text="<%#:Item.BIN %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Shelf">
            <ItemTemplate>
                <asp:Label ID="LblShelf" runat="server" Text="<%#:Item.Shelf %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>

        
         <asp:TemplateField HeaderText="Level">
            <ItemTemplate>
                <asp:Label ID="LblLevel" runat="server" Text="<%#:Item.Level %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>
    
        <asp:TemplateField HeaderText="UnitsInStock"> 
            <ItemTemplate>
                <asp:Label ID="LblUIS" runat="server" Text="<%#:Item.UnitsInStock %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>

         <asp:TemplateField HeaderText="UnitsOnOrder"> 
            <ItemTemplate>
                <asp:Label ID="LblUIO" runat="server" Text="<%#:Item.UnitsOnOrder %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>

          <asp:TemplateField HeaderText="BufferStockLevel"> 
            <ItemTemplate>
                <asp:Label ID="LblBuffer" runat="server" Text="<%#:Item.BufferStockLevel %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Discontinued"> 
            <ItemTemplate>
                <asp:Label ID="Lbldesc" runat="server" Text="<%#:Item.Discontinued %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>
    
    </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="LblMsg" runat="server" Text="" ForeColor="Green"></asp:Label>
    </asp:Content>
<%--OnRowDataBound="GridViewInventory_RowDataBound"--%>