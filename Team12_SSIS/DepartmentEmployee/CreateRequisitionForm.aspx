<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRequisitionForm.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.CreateRequisitionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<h2>Stationery Requisition Form</h2>
</div>
    <div>
        <asp:GridView ID="GridViewRequisitionForm" runat="server" AutoGenerateColumns="False"
            OnRowDeleting="GridViewCheckOut_RowDeleting" DataKeyNames="ItemID">
            <Columns>
                <asp:TemplateField HeaderText="ItemID" SortExpression="ItemID">
                <ItemTemplate>
                    <asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <ItemTemplate>
                    <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="RequestedQuantity" SortExpression="RequestedQuantity">
                <ItemTemplate>
                    <asp:Label ID="LblRequestedQuantity" runat="server" Text='<%# Bind("RequestedQuantity") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="BtnSubmitForm" runat="server" Text="Submit Form" OnClick="BtnSubmitForm_Click"/>
    </div>
</asp:Content>
