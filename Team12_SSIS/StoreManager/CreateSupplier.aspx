<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateSupplier.aspx.cs" Inherits="Team12_SSIS.StoreManager.CreateSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table >
            <tr>
                <td colspan="2">
                    <h2>Create Supplier</h2>
                </td>
            </tr>
    
            <tr>
                <!--SupplierID-->
                <td>Supplier ID:
                </td>
                <td>
                    <asp:TextBox ID="TxtSupplierID" runat="server" OnTextChanged="TxtSupplierID_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="LblExist" runat="server" Text="" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSupplierID" runat="server" ControlToValidate="TxtSupplierID" ForeColor="Red" ErrorMessage="* Supplier ID Required"/>
                </td>
            </tr>

            <tr>
                <!--SupplierName-->
                <td>Supplier Name:
                </td>
                <td>
                    <asp:TextBox ID="TxtSupplierName" runat="server" CssClass="form-control"></asp:TextBox>
                    
                </td>
            </tr>
     
            <tr>
                <!--GSTRegistrationNo-->
                <td>GST Registration No:
                </td>
                <td>
                    <asp:TextBox ID="TxtGSTRegistrationNo" runat="server" CssClass="form-control"></asp:TextBox>
                    
                </td>
            </tr>
  
            <tr>
                <!--ContactName-->
                <td>Contact Name: 
                </td>
                <td>
                    <asp:TextBox ID="TxtContactName" runat="server" CssClass="form-control"></asp:TextBox>
                    
                </td>
            </tr>
       
            <tr>
                <!--PhoneNo-->
                <td>Phone No: 
                </td>
                <td>
                    <asp:TextBox ID="TxtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" ControlToValidate="TxtPhoneNo" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
            </tr>
  
            <tr>
                <!--FaxNo-->
                <td>Fax No:
                </td>
                <td>
                    <asp:TextBox ID="TxtFaxNo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorFax" ControlToValidate="TxtFaxNo" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
            </tr>
     
            <tr>
                <!--Address-->
                <td>Address:
                </td>
                <td>
                    <asp:TextBox ID="TxtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                   
                </td>
            </tr>
    
            <tr>
                <!--OrderLeadTime-->
                <td>Order Lead Time:
                </td>
                <td>
                    <asp:TextBox ID="TxtOrderLeadTime" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorOLT" ControlToValidate="TxtOrderLeadTime" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                </td>
            </tr>
   
            <tr>
                <!--Btn Submit-->
                <td>
                </td>
                <td>
                    <asp:Button ID="BtnSubmit" runat="server" CausesValidation="true" Text="Submit" cssclass="btn btn-primary"  OnClick="BtnSubmit_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
