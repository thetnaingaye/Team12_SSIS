<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .gridview {
    width: 100%; 
    word-wrap:break-word;
    table-layout: fixed;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Stationery Catalogue List</h2>
    <table style="width: 100%; align-self:center">
        <tr>
            <td>
                <asp:Button ID="BtnCreate" cssclass="btn btn-primary" runat="server" OnClick="BtnCreate_Click" Text="Create" />
            </td>
            </tr>
      
        <tr>
            <td>
                <div style="float: right"; vertical-align: middle" >
                <asp:TextBox ID="TxtSearch" placeholder="Search Item" Height="45px" Width="150px" runat="server"></asp:TextBox>
                <asp:Button ID="BtnSearch" cssclass="btn btn-primary" runat="server" Text="Search" OnClick="BtnSearch_Click" />
                    </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <div >
                <asp:GridView ID="GridViewCatalogue" class="table" runat="server" AutoGenerateColumns="False" Style="width:100%"
                    AllowPaging="True" PageSize="10" OnPageIndexChanging="GridViewCatalogue_PageIndexChanging"
                    OnRowDataBound="GridViewCatalogue_RowDataBound"
                    OnRowEditing="GridViewCatalogue_RowEditing"
                    OnRowCancelingEdit="GridViewCatalogue_RowCancelingEdit"
                    OnRowUpdating="GridViewCatalogue_RowUpdating"
                    DataKeyNames="ItemID" OnRowCommand="GridViewCatalogue_RowCommand">
                    <AlternatingRowStyle BackColor="#f9f9f9"  />
                    <PagerStyle HorizontalAlign="Center" />
                    <pagersettings mode="Numeric" position="Bottom" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>

                        <asp:TemplateField HeaderText="Item ID" SortExpression="ItemID">
                            <ItemTemplate>
                                <asp:LinkButton ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>' CommandName="EditItem" CommandArgument='<%# Bind("ItemID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtDescription" runat="server" Width="100px" Text='<%# Bind("Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Category ID" SortExpression="CategoryID">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DdlCategoryID" runat="server" OnSelectedIndexChanged="DdlCategoryID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCatID" runat="server" ControlToValidate="DdlCategoryID"
                        ForeColor="Red" ErrorMessage="*CategoryID Required"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblCategoryID" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Category Name" SortExpression="CategoryName">
                            <EditItemTemplate>
                                <asp:Label ID="LblCatalogueNameAuto" runat="server"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblCatalogueName" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BIN" SortExpression="BIN">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtBIN" runat="server" Width="50px" Text='<%# Bind("BIN") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblBIN" runat="server" Text='<%# Bind("BIN") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Shelf" SortExpression="Shelf">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtShelf" runat="server" Width="30px" Text='<%# Bind("Shelf") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblShelf" runat="server" Text='<%# Bind("Shelf") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Level" SortExpression="Level">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtLevel" TextMode="Number" runat="server" Width="50px" Text='<%# Bind("Level") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorlVL" ControlToValidate="TxtLevel" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblLevel" runat="server"  Text='<%# Bind("Level") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reorder Level" SortExpression="ReorderLevel">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtReorderLevel" runat="server" Width="50px" Text='<%# Bind("ReorderLevel") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorReLvl" ControlToValidate="TxtReorderLevel" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Units In Stock" SortExpression="UnitsInStock">
                            
                            <ItemTemplate>
                                <asp:Label ID="LblUnitsInStock" runat="server" Text='<%# Bind("UnitsInStock") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reorder Quantity" SortExpression="ReorderQty">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtReorderQty" runat="server" Width="50px" Text='<%# Bind("ReorderQty") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorReQty" ControlToValidate="TxtReorderQty" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblReorderQty" runat="server" Text='<%# Bind("ReorderQty") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Unit Of Measure" SortExpression="UOM">
                           
                            <ItemTemplate>
                                <asp:Label ID="LblUOM" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DdlDiscontinued" runat="server" AutoPostBack="false">
                                    <asp:ListItem Selected="True" Value="N"> N </asp:ListItem>
                                     <asp:ListItem Value="Y"> Y </asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblDiscontinued" runat="server" Text='<%# Bind("Discontinued") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Units On Order" SortExpression="UnitsOnOrder">
                            
                            <ItemTemplate>
                                <asp:Label ID="LblUnitsOnOrder" runat="server" Text='<%# Bind("UnitsOnOrder") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Buffer Stock Level" SortExpression="BufferStockLevel">
                        
                            <ItemTemplate>
                                <asp:Label ID="LblBufferStockLevel" runat="server" Text='<%# Bind("BufferStockLevel") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                       <asp:TemplateField HeaderText="BFS Proportion" SortExpression="BFSProportion">
                      
                            <ItemTemplate>
                                <asp:Label ID="LblBFSProportion" runat="server" Text='<%# Bind("BFSProportion") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:CommandField ButtonType="Button" ShowEditButton="True" HeaderText ="Edit Item" CausesValidation="true"
                            EditText="Edit" UpdateText="Update" CancelText="Cancel" ><ControlStyle cssClass="btn btn-primary btn-xs" />
                        </asp:CommandField>

                    </Columns>

                </asp:GridView>
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>
