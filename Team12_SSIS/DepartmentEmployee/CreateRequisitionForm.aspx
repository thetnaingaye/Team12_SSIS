<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRequisitionForm.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.CreateRequisitionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Stationery Requisition Form</h2>
        <br />
    <asp:LinkButton ID="LinkButtonGoBack"  runat="server" OnClick="LinkButtonGoBack_Click"> <i><u>Go Back To Catalogue</u></i> </asp:LinkButton>
        <br />

                <div style="margin-left:auto; margin-right:auto; width:700px;">
        <asp:GridView ID="GridViewRequisitionForm" runat="server" AutoGenerateColumns="False"
            Style="width:100%"
             DataKeyNames="ItemID"
            OnRowDataBound="GridViewRequisitionForm_RowDataBound">
            <AlternatingRowStyle BackColor="#f9f9f9"/>
            <RowStyle HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField HeaderText="Item ID" SortExpression="ItemID">
                <ItemTemplate>
                    <asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                </ItemTemplate>
                    <HeaderStyle CssClass="text-center" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <ItemTemplate>
                    <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
                    <HeaderStyle CssClass="text-center" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Requested Quantity" SortExpression="RequestedQuantity">
                <ItemTemplate>


                    <asp:TextBox ID="TxtRequestedQuantity" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorQty" runat="server" ControlToValidate="TxtRequestedQuantity"
                        ForeColor="Red" ErrorMessage="*Quantity Required" ValidationGroup="BtnSubmit"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorQty" ControlToValidate="TxtRequestedQuantity" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$" ValidationGroup="BtnSubmit"/>                 
                </ItemTemplate>
                    <HeaderStyle CssClass="text-center" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
                </div>
    <br />

        <div style="text-align:center">
        <asp:Button ID="BtnSubmitForm" runat="server" cssclass="btn btn-primary" Text="Submit Form" OnClick="BtnSubmitForm_Click" ValidationGroup="BtnSubmit"/>
            </div>
    
</asp:Content>
