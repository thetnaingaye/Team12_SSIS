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
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="RequestedQuantity" HeaderText="RequestedQuantity" SortExpression="RequestedQuantity" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="BtnSubmitForm" runat="server" Text="Submit Form" OnClick="BtnSubmitForm_Click"/>
    </div>
</asp:Content>
