<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeptRequisitionReport.aspx.cs" Inherits="Team12_SSIS.StoreReport.DeptRequisitionReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Calender Script-->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepickerStart").datepicker({ dateFormat: "dd/mm/yy" }).datepicker("setDate", new Date());
            $("#datepickerEnd").datepicker({ dateFormat: "dd/mm/yy" }).datepicker("setDate", new Date());
        });
    </script>
    <table style="width: 100%; vertical-align: top">
        <tr>
            <td colspan="4">
                <h2>Department Requisition Report</h2>
            </td>
        </tr>
        <tr>
            <td colspan="2">Department:
                            <asp:DropDownList ID="DdlDept" runat="server" DataTextField="DepartmentName" DataValueField="DeptID"></asp:DropDownList>
                <asp:Button ID="BtnAddSupplier" runat="server" Text="Add Department..." OnClick="BtnAddDept_Click" CssClass="btn btn-primary btn-xs" />

            </td>
            <td colspan="2"></td>
        </tr>


        <tr>
            <td colspan="2">Starting:
                                <input type="text" id="datepickerStart" name="datepickerStart" />

            </td>
            <td colspan="2">Ending:
                                <input type="text" id="datepickerEnd" name="datepickerEnd" />

            </td>
        </tr>
        <tr>
            <td colspan="2">Item Code:
                        <asp:TextBox ID="TxtItemCode" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a valid item code." ForeColor="Red" ControlToValidate="TxtItemCode" ValidationGroup="GenerateReport"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                <asp:Label ID="LblItemDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridViewDept" Style="width: 100%" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Department ID">
                            <ItemTemplate>
                                <asp:Label ID="LblDeptID" runat="server" Text='<%# Eval("DeptID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Department Name">
                            <ItemTemplate>
                                <asp:Label ID="LblDeptName" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>

        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" runat="server" Text="Generate Report" OnClick="Button1_Click" CssClass="btn btn-primary btn-xs" ValidationGroup="GenerateReport" />
            </td>
        </tr>
        <tr>

            <td style="width: 100%" colspan="4">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewerDeptReq" runat="server" Height="800px" Width="100%" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" BackColor="">
                    <LocalReport ReportPath="StoreReport\DeptRequisitionReportTemplate.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="" Name="SA45Team12ADDataSetReqHx" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

            </td>

        </tr>
    </table>
</asp:Content>
