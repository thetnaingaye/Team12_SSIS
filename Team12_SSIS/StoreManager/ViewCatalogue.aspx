<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 1115px;
            overflow: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Stationery Catalog List</h2>
    <table style="width: 100%">
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
                <div style="overflow-x:auto;width:1100px">
                <asp:GridView ID="GridViewCatalogue" class="table" runat="server" AutoGenerateColumns="False" Style="width:100%"
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewCatalogue_PageIndexChanging"
                    OnRowDataBound="GridViewCatalogue_RowDataBound"
                    OnRowEditing="GridViewCatalogue_RowEditing"
                    OnRowCancelingEdit="GridViewCatalogue_RowCancelingEdit"
                    OnRowUpdating="GridViewCatalogue_RowUpdating"
                    DataKeyNames="ItemID">
                    <AlternatingRowStyle BackColor="#f9f9f9"  />
                    <PagerStyle HorizontalAlign="Center" />
                    <pagersettings mode="Numeric" position="Bottom" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>

                        <asp:TemplateField HeaderText="Item ID" SortExpression="ItemID">
                            <ItemTemplate>
                                <asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Category ID" SortExpression="CategoryID">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DdlCategoryID" runat="server" OnSelectedIndexChanged="DdlCategoryID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                                <asp:TextBox ID="TxtBIN" runat="server" Text='<%# Bind("BIN") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblBIN" runat="server" Text='<%# Bind("BIN") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Shelf" SortExpression="Shelf">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtShelf" runat="server" Text='<%# Bind("Shelf") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblShelf" runat="server" Text='<%# Bind("Shelf") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Level" SortExpression="Level">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtLevel" runat="server" Text='<%# Bind("Level") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblLevel" runat="server" Text='<%# Bind("Level") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reorder Level" SortExpression="ReorderLevel">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reorder Quantity" SortExpression="ReorderQty">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtReorderQty" runat="server" Text='<%# Bind("ReorderQty") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblReorderQty" runat="server" Text='<%# Bind("ReorderQty") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Unit Of Measure" SortExpression="UOM">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtUOM" runat="server" Text='<%# Bind("UOM") %>'></asp:TextBox>
                            </EditItemTemplate>
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

                        <asp:CommandField ButtonType="Button" ShowEditButton="True" HeaderText ="Edit Item"
                            EditText="Edit" UpdateText="Update" CancelText="Cancel" ><ControlStyle cssClass="btn btn-primary btn-xs" />
                        </asp:CommandField>

                    </Columns>

                </asp:GridView>
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>
