<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCatalogue.aspx.cs" Inherits="Team12_SSIS.StoreManager.CreateCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table >
            <tr>
                <td colspan="2">
                    <h2>Create Stationery Catalogue</h2>
                </td>
            </tr>

            <tr>
                <!--ItemID-->
                <td>Item ID:
                </td>
                <td>
                    <asp:TextBox ID="TxtItemID" runat="server" CssClass="form-control" OnTextChanged="TxtItemID_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="LblExist" runat="server" Text="" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorItemID" runat="server" ControlToValidate="TxtItemID" ForeColor="Red" ErrorMessage="* Item ID Required"/>
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
                    <asp:DropDownList ID="DdlCategoryID" runat="server" CssClass="form-control" AppendDataBoundItems="true" Width="200px">
                        <asp:ListItem Selected="true" Value=""> -- Choose Category -- </asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCatID" runat="server" ControlToValidate="DdlCategoryID" ForeColor="Red" ErrorMessage="* Category ID Required"/>
                </td>
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
                <!--Shelf-->
                <td>Shelf:
                </td>
                <td>
                    <asp:TextBox ID="TxtShelf" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
       
            <tr>
                <!--Level-->
                <td>Level:
                </td>
                <td>
                    <asp:TextBox ID="TxtLevel" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLvl" ControlToValidate="TxtLevel" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
            </tr>
            
            <tr>
                <!--ReorderLevel-->
                <td>Reorder Level:
                </td>
                <td>
                    <asp:TextBox ID="TxtReorderLevel" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorReLvl" ControlToValidate="TxtReorderLevel" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
            </tr>
        
            <tr>
                <!--ReorderQty-->
                <td>Reorder Quantity:
                </td>
                <td>
                    <asp:TextBox ID="TxtReorderQty" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorReQty" ControlToValidate="TxtReorderQty" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
            </tr>

            <tr>
                <!--UnitsInStock-->
                <td>Units In Stock:
                </td>
                <td>
                    <asp:TextBox ID="TxtUnitsInStock" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUIS" runat="server" ControlToValidate="TxtUnitsInStock" ForeColor="Red" ErrorMessage="* Units In Stock Required"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorUIS" ControlToValidate="TxtUnitsInStock" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
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
                <!--UnitsOnOrder-->
                <td>Units On Order:
                </td>
                <td>
                    <asp:TextBox ID="TxtUnitsOnOrder" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorUOO" ControlToValidate="TxtUnitsOnOrder" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
            </tr>

            <tr>
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
            </tr>
            <tr>
                <!--BFSProportion-->
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">
                </td>
            </tr>

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
