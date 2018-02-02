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
     <style type="text/css">
         .highlight{
             background-color: #FFFF00;
             
         }
         </style>
    
    <%-- styling the search box --%>
     <style type="text/css">
    @import url(https://fonts.googleapis.com/css?family=Open+Sans);

body{
  background: #f2f2f2;
  font-family: 'Open Sans', sans-serif;
}

.search {
  width: 100%;
  position: relative
}

.searchTerm {
  float: left;
  width: 100%;
  border: 3px solid #00B4CC;
  padding: 5px;
  height: 20px;
  border-radius: 5px;
  outline: none;
  color: #9DBFAF;
}

.searchTerm:focus{
  color: #00B4CC;
}

.searchButton {
  position: absolute;  
  right: -50px;
  width: 40px;
  height: 36px;
  border: 1px solid #00B4CC;
  background: #00B4CC;
  text-align: center;
  color: #fff;
  border-radius: 5px;
  cursor: pointer;
  font-size: 20px;
}

/*Resize the wrap to see the search bar change!*/
.wrap{
  width: 30%;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
         .auto-style14 {
             width: 1018px;
             height: 20px;
         }
         .auto-style15 {
             width: 428px;
             height: 20px;
         }
         .auto-style16 {
             width: 1018px;
         }
         .auto-style17 {
             width: 650px;
         }
         .auto-style18 {
             width: 718px;
         }
         </style>    

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Inventory List</h2>
      <br />
    </div> 

                                 
      &nbsp;<asp:TextBox ID="TxtSearch" placeholder="Enter keyword to search" runat="server" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged" CssClass="auto-style12" Height="34px" Width="365px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" CssClass="auto-style19" Height="34px" Text="Search" Width="57px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <br />
    &nbsp;<br />
    <br />
  








    <table class="nav-justified">
             <tbody style="width: 100%">
                    
        <tr>
            <td class="auto-style18">
 <asp:Label ID="LblCatagory" runat="server" Text="Category:"></asp:Label>
                 &nbsp; <asp:DropDownList ID="DdlCatagory" runat="server" Height="26px" Width="130px" OnSelectedIndexChanged="DdlCatagory_SelectedIndexChanged">
      <asp:ListItem></asp:ListItem>
      <asp:ListItem>All</asp:ListItem>
    </asp:DropDownList>
                 &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="LblUIS0" runat="server" Text="Units In Stock:"></asp:Label>
                           &nbsp;
                           <asp:DropDownList ID="DdlUIS" runat="server" Height="28px" Width="130px">
      <asp:ListItem Value="0">All</asp:ListItem>
<asp:ListItem Value="1">&lt;Reorder Level</asp:ListItem>
                     <asp:ListItem Value="200">&lt;200</asp:ListItem>
                     <asp:ListItem Value="100">&lt;100</asp:ListItem>
                     <asp:ListItem Value="50">&lt;50</asp:ListItem>
      <asp:ListItem Value="10">&lt;10</asp:ListItem>
    </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnSearch" runat="server" Text="VIEW" OnClick="Btnsearch_Click" Width="100px" CssClass="auto-style7" Height="28px" />
            </td>
            <td class="auto-style17">
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp; 
            &nbsp;
                &nbsp;
            </td>
        </tr>
             </tbody>
    </table>

                                 
     
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
    

   
        <table class="nav-justified">
             <tbody style="width: 100%">
                    
                    
                      <tr>
                      <td class="auto-style14">
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <br />
                      <asp:Label ID="LblCatName" runat="server" Text="Category: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblCatNameD" runat="server" Font-Bold="true"></asp:Label>
                      </td>
                      <td class="auto-style15">
                      &nbsp;&nbsp;&nbsp;
                      <asp:Label ID="LblReorder" runat="server" Text="Reorder Level: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblReorderD" runat="server" Font-Bold="true"></asp:Label>
                     </td>
                     </tr>
                 
                   <tr>
                     <td class="auto-style14">
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <br />
                      <asp:Label ID="LblId" runat="server" Text="Category ID: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblIdD" runat="server" Font-Bold="true"></asp:Label>
                      </td>
                      <td class="auto-style15">
                      &nbsp;&nbsp;&nbsp;
                      <asp:Label ID="LblReorderQty" runat="server" Text="Reorder Quantity: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblReorderQtyD" runat="server" Font-Bold="true"></asp:Label>
                     </td>
                     </tr>
                 
            </tbody>
        </table>
    <asp:GridView ID="GridViewInventory" runat="server"   AutoGenerateColumns="false" Width="100%" GridLines="None" datakeynames="ItemID" ItemType="Team12_SSIS.Model.InventoryCatalogue" BackColor="White"  AllowPaging="true"  PageSize="10"  OnPageIndexChanging="OnPaging" OnRowDataBound="GridViewInventory_RowDataBound" ShowHeaderWhenEmpty="True" OnRowCommand="GridViewDisbList_RowCommand" EmptyDataText="No records Found"> 
      
        <HeaderStyle CssClass="gridViewHeader" />
    <RowStyle CssClass="gridViewRow" />
    <AlternatingRowStyle CssClass="gridViewAltRow" />
         <PagerStyle CssClass="cssPager" />
    <Columns>
        <asp:TemplateField HeaderText="ItemID">
            <ItemTemplate>
              
                <asp:LinkButton ID="LBtnListID" runat="server" Text=' <%# HighlightText(TxtSearch.Text, (string) Eval("ItemID")) %>' CommandName="show" CommandArgument='<%# Bind("ItemID") %>'></asp:LinkButton>
            </ItemTemplate>
              <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
                 <%# HighlightText(TxtSearch.Text, (string) Eval("Description")) %>Description
               <%-- <asp:Label ID="Lbldes" runat="server" Text="<%#:Item.Description %>" HeaderText="Description"></asp:Label>--%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%" ></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="BIN">
            <ItemTemplate>
                <asp:Label ID="LblBin" runat="server" Text='<%# HighlightText(TxtSearch.Text, (string) Eval("BIN")) %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
              <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Shelf">
            <ItemTemplate>
                <asp:Label ID="LblShelf" runat="server" Text='<%# HighlightText(TxtSearch.Text, (string) Eval("Shelf")) %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Level">
            <ItemTemplate>
                <asp:Label ID="LblLevel" runat="server" Text='<%# HighlightText(TxtSearch.Text, Convert.ToString( Eval("Level")))%> '></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
               
        </asp:TemplateField>
    
        <asp:TemplateField HeaderText="UnitsInStock"> 
            <ItemTemplate>
                <asp:Label ID="LblUIS" runat="server" Text='<%#:Item.UnitsInStock %>' HeaderText="Units In Stock"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
              <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Reorder Level"> 
            <ItemTemplate>
                <asp:Label ID="LblReorder" runat="server" Text="<%#:Item.ReorderLevel %>" HeaderText="Reorder Level"></asp:Label>
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






   
   