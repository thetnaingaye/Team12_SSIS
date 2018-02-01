<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierOrderReport.aspx.cs" Inherits="Team12_SSIS.StoreReport.ReportViewer" %>

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
                <h2>Supplier Order Report</h2>
            </td>
        </tr>
        <tr>
            <td colspan="4">Supplier:
                            <asp:DropDownList ID="DdlSupplier" runat="server" DataTextField="SupplierName" DataValueField="SupplierID"></asp:DropDownList>
                <asp:Button ID="BtnAddSupplier" runat="server" Text="Add Supplier..." OnClick="BtnAddSupplier_Click" CssClass="btn btn-primary btn-xs" />
            </td>
        </tr>
        <tr>
            <td colspan="2">Starting:
                                <input type="text" id="datepickerStart" name="datepickerStart"/>

            </td>
            <td colspan="2">Ending:
                                <input type="text" id="datepickerEnd" name="datepickerEnd" />

            </td>
        </tr>
        <tr>
            <td colspan="2">Item Code:
                        <asp:TextBox ID="TxtItemCode" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a valid item code" ForeColor="Red" ControlToValidate="TxtItemCode" ValidationGroup="GenerateReport"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                <asp:Label ID="LblItemDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridViewSupplier" Style="width: 100%" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Supplier ID">
                            <ItemTemplate>
                                <asp:Label ID="LblSupplierID" runat="server" Text='<%# Eval("SupplierID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Supplier Name">
                            <ItemTemplate>
                                <asp:Label ID="LblSupplierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>

        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" runat="server" Text="Generate Report" ValidationGroup="GenerateReport" OnClick="Button1_Click" CssClass="btn btn-primary btn-xs" />
            </td>
        </tr>
        <tr>

            <td style="width: 100%" colspan="4">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="800px" Width="100%" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                    <LocalReport ReportPath="StoreReport\SupplierOrderReportTemplate.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="" Name="SA45Team12ADDataSet" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

            </td>

        </tr>
    </table>
</asp:Content>
