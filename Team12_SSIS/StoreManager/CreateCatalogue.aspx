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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server" ControlToValidate="TxtDescription" ForeColor="Red" ErrorMessage="* Description Required"/>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBIN" runat="server" ControlToValidate="TxtBIN" ForeColor="Red" ErrorMessage="* BIN Required"/>
                </td>
            </tr>
     
            <tr>
                <!--Shelf-->
                <td>Shelf:
                </td>
                <td>
                    <asp:TextBox ID="TxtShelf" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShelf" runat="server" ControlToValidate="TxtShelf" ForeColor="Red" ErrorMessage="* Shelf Required"/>
                </td>
            </tr>
       
            <tr>
                <!--Level-->
                <td>Level:
                </td>
                <td>
                    <asp:TextBox ID="TxtLevel" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLevel" runat="server" ControlToValidate="TxtLevel" ForeColor="Red" ErrorMessage="* Level Required"/>
                </td>
            </tr>
            
            <tr>
                <!--ReorderLevel-->
                <td>Reorder Level:
                </td>
                <td>
                    <asp:TextBox ID="TxtReorderLevel" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReorderLevel" runat="server" ControlToValidate="TxtReorderLevel" ForeColor="Red" ErrorMessage="* Reorder Level Required"/>
                </td>
            </tr>
        
            <tr>
                <!--ReorderQty-->
                <td>Reorder Quantity:
                </td>
                <td>
                    <asp:TextBox ID="TxtReorderQty" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReorderQty" runat="server" ControlToValidate="TxtReorderQty" ForeColor="Red" ErrorMessage="* Reorder Quantity Required"/>
                </td>
            </tr>
         
            <tr>
                <!--UOM-->
                <td>Unit of Measure:
                </td>
                <td>
                    <asp:TextBox ID="TxtUOM" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUOM" runat="server" ControlToValidate="TxtUOM" ForeColor="Red" ErrorMessage="* Unit Of Measure Required"/>
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
