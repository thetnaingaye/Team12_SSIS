<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.EditCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table >
            <tr>
                <td colspan="2">
                    <h2>Edit Supplier-Catalogue</h2>
                </td>
            </tr>

            <tr>
                <!--ItemID-->
                <td>Item ID:
                </td>
                <td>
                    <asp:TextBox ID="TxtItemID" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </td>
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
                <!--CatalogueName DDL-->
                <td>Category Name:
                </td>
                <td>
                    <asp:TextBox ID="TxtCategory" runat="server"></asp:TextBox>
            </tr>
                <!--BufferStockLevel-->
                <td>&nbsp;Suppliers:</td>
                <td>
                    Priority 1:
                    <asp:DropDownList ID="DdlSupplier1" runat="server" DataTextField="SupplierName" DataValueField="SupplierID">
                    </asp:DropDownList>
&nbsp;Price:
                    <asp:TextBox ID="TxtPriceS1" runat="server"></asp:TextBox>
                    <br />
                    Priority 2:
                    <asp:DropDownList ID="DdlSupplier2" runat="server" DataTextField="SupplierName" DataValueField="SupplierID">
                    </asp:DropDownList>
&nbsp;Price:
                    <asp:TextBox ID="TxtPriceS2" runat="server"></asp:TextBox>
                    <br />
                    Priority 3:
                    <asp:DropDownList ID="DdlSupplier3" runat="server" DataTextField="SupplierName" DataValueField="SupplierID">
                    </asp:DropDownList>
&nbsp;Price: <asp:TextBox ID="TxtPriceS3" runat="server"></asp:TextBox>
                </td>
          

            <tr>
                <!--Btn Submit-->
                <td></td>
                <td>
                    <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" CausesValidation="true"
                        cssclass="btn btn-primary" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
