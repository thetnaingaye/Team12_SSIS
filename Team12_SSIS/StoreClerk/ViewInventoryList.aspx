<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInventoryList.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewInventoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">           
             
          .cssPager span { background-color:#4f6b72; font-size:18px;}    
              .cssPager td
            {
                  padding-left: 4px;     
                  padding-right: 4px;    
              }
              .one {
            margin: 10px;
            padding: 10px;
        }
               .radiobuttonlist .red 
               {
                   margin-right:20px;
               }
             
        </style>
     <style type="text/css">
        .greenRadio
        {
            color: Green;
          word-spacing:20px;
        }
        .redRadio
        {
            color: Red;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="LblTitle" runat="server" Text="Inventory List" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LblInput" runat="server" Text="Choose item to filter the inventory list:"   CellPadding="10" CellSpacing="10"></asp:Label>
    <asp:RadioButtonList ID="RbtnFilter" runat="server" AutoPostBack="True"  CellSpacing="30" 
        OnSelectedIndexChanged="Rbtn_SelectedIndexChanged" RepeatDirection="Horizontal" margin-rigt="80px">
          <asp:ListItem Text="Item Code" Value="1"    />
         <asp:ListItem Text="Catagory" Value="2"    />
      
        <asp:ListItem Value="3" >All</asp:ListItem>
    </asp:RadioButtonList>
   

   
    <br />
    <asp:Label ID="LblItemCode" runat="server" Text="Item Code:"></asp:Label>
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

      <div>
        <table style="width: 100%">
             <tbody style="width: 100%">
                    
                        
                      <tr style="height:20px">
                      <td class="auto-style2">
                      <asp:Label ID="LblCatName" runat="server" Text="Catagory: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblCatNameD" runat="server" Font-Bold="true"></asp:Label>
                          <br />
                      </td>
                      <td class="auto-style2">
                      <asp:Label ID="LblReorder" runat="server" Text="Reorder Level: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblReorderD" runat="server" Font-Bold="true"></asp:Label>
                     </td>
                     </tr>
                 
                   <tr style="height:20px">
                     <td class="auto-style2">
                      <asp:Label ID="LblId" runat="server" Text="Catagory ID: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblIdD" runat="server" Font-Bold="true"></asp:Label>
                         <br />
                      </td>
                      <td class="auto-style2">
                      <asp:Label ID="LblReorderQty" runat="server" Text="Reorder Quantity: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblReorderQtyD" runat="server" Font-Bold="true"></asp:Label>
                     </td>
                     </tr>
                  <tr style="height:20px">
                     <td class="auto-style2">
                      <asp:Label ID="LblUOM" runat="server" Text="Unit Of Measurement: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblUOMD" runat="server" Font-Bold="true"></asp:Label>
                         <br />
                      </td>
                </tr>
                 
            </tbody>
        </table>
          </div>


   
    <br />

    <%--Gridview formatting--%>
    <asp:GridView ID="GridViewInventory" runat="server"   AutoGenerateColumns="false" Width="100%" GridLines="None" datakeynames="ItemID" ItemType="Team12_SSIS.Model.InventoryCatalogue" BackColor="White"  AllowPaging="true"  PageSize="10"  OnPageIndexChanging="OnPaging" OnRowDataBound="GridViewInventory_RowDataBound" ShowHeaderWhenEmpty="True"> 
       <%-- <HeaderStyle BackColor="#6495ED" Font-Bold="false" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" >
          </HeaderStyle>
        --%>
        <HeaderStyle CssClass="gridViewHeader" />
    <RowStyle CssClass="gridViewRow" />
    <AlternatingRowStyle CssClass="gridViewAltRow" />
         <PagerStyle CssClass="cssPager" />
    <Columns>
        <asp:TemplateField HeaderText="ItemID">
            <ItemTemplate>
                <asp:Label ID="LblitemId" runat="server" Text="<%#:Item.ItemID %>" HeaderText="Item Code" ></asp:Label>
            </ItemTemplate>
              <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
                <asp:Label ID="Lbldes" runat="server" Text="<%#:Item.Description %>" HeaderText="Description"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%" ></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="BIN">
            <ItemTemplate>
                <asp:Label ID="LblBin" runat="server" Text="<%#:Item.BIN %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
              <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Shelf">
            <ItemTemplate>
                <asp:Label ID="LblShelf" runat="server" Text="<%#:Item.Shelf %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>

        
         <asp:TemplateField HeaderText="Level">
            <ItemTemplate>
                <asp:Label ID="LblLevel" runat="server" Text="<%#:Item.Level %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
               
        </asp:TemplateField>
    
        <asp:TemplateField HeaderText="UnitsInStock"> 
            <ItemTemplate>
                <asp:Label ID="LblUIS" runat="server" Text="<%#:Item.UnitsInStock %>" HeaderText="Units In Stock"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
              <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="UnitsOnOrder"> 
            <ItemTemplate>
                <asp:Label ID="LblUIO" runat="server" Text="<%#:Item.UnitsOnOrder %>" HeaderText="Units in Order"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>

          <asp:TemplateField HeaderText="BufferStockLevel"> 
            <ItemTemplate>
                <asp:Label ID="LblBuffer" runat="server" Text="<%#:Item.BufferStockLevel %>"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Discontinued"> 
            <ItemTemplate>
                <asp:Label ID="Lbldesc" runat="server" Text="<%#:Item.Discontinued %>" HeaderText="Discontinue status"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
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
    <asp:Label ID="LblMsg" runat="server" Text="" ForeColor="Green"></asp:Label>
    </asp:Content>
