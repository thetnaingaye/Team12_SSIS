<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.CreateCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table >
            <tr>
                <td colspan="2">
                    <h2>Create Stationery Catalog</h2>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--ItemID-->
                <td>Item ID:
                </td>
                <td>
                    <asp:TextBox ID="TxtItemID" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--ItemDescription-->
                <td>Item Description:
                </td>
                <td>
                    <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--CatalogueName DDL-->
                <td>Category Name:
                </td>
                <td>
                    <asp:DropDownList ID="DdlCategoryID" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--BIN-->
                <td>BIN:
                </td>
                <td>
                    <asp:TextBox ID="TxtBIN" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--Shelf-->
                <td>Shelf:
                </td>
                <td>
                    <asp:TextBox ID="TxtShelf" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--Level-->
                <td>Level:
                </td>
                <td>
                    <asp:TextBox ID="TxtLevel" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--ReorderLevel-->
                <td>Reorder Level:
                </td>
                <td>
                    <asp:TextBox ID="TxtReorderLevel" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--ReorderQty-->
                <td>Reorder Quantity:
                </td>
                <td>
                    <asp:TextBox ID="TxtReorderQty" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--UOM-->
                <td>Unit of Measure:
                </td>
                <td>
                    <asp:TextBox ID="TxtUOM" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <!--Btn Submit-->
                <td></td>
                <td>
                    <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BorderColor="#333333" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
