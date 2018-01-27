<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="Team12_SSIS.StoreReport.ReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%; vertical-align: top">
        <tr>
            <td style="width: 30%">
                <table style="width: 100%; vertical-align: top">
                    <tr>
                        <td>Starting:
                            <asp:DropDownList ID="DdlStartMonth" runat="server">
                                <asp:ListItem Text="Jan" Value="01/01/2018"></asp:ListItem>
                                <asp:ListItem Text="Feb" Value="01/02/2018"></asp:ListItem>
                                <asp:ListItem Text="Mar" Value="01/03/2018"></asp:ListItem>
                                <asp:ListItem Text="Apr" Value="01/04/2018"></asp:ListItem>
                                <asp:ListItem Text="May" Value="01/05/2018"></asp:ListItem>
                                <asp:ListItem Text="Jun" Value="01/06/2018"></asp:ListItem>
                                <asp:ListItem Text="Jul" Value="01/07/2018"></asp:ListItem>
                                <asp:ListItem Text="Aug" Value="01/08/2018"></asp:ListItem>
                                <asp:ListItem Text="Sept" Value="01/09/2018"></asp:ListItem>
                                <asp:ListItem Text="Oct" Value="01/10/2018"></asp:ListItem>
                                <asp:ListItem Text="Nov" Value="01/11/2018"></asp:ListItem>
                                <asp:ListItem Text="Dec" Value="01/12/2018"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>Year:
                            <asp:TextBox ID="TxtStartYear" runat="server"></asp:TextBox>
                        </td>
                        <td>Ending:
                          <asp:DropDownList ID="DdlEndMonth" runat="server">
                                                              <asp:ListItem Text="Jan" Value="31/01/2018"></asp:ListItem>
                              <asp:ListItem Text="Feb" Value="31/02/2018"></asp:ListItem>
                              <asp:ListItem Text="Mar" Value="31/03/2018"></asp:ListItem>
                              <asp:ListItem Text="Apr" Value="31/04/2018"></asp:ListItem>
                              <asp:ListItem Text="May" Value="31/05/2018"></asp:ListItem>
                              <asp:ListItem Text="Jun" Value="31/06/2018"></asp:ListItem>
                              <asp:ListItem Text="Jul" Value="31/07/2018"></asp:ListItem>
                              <asp:ListItem Text="Aug" Value="31/08/2018"></asp:ListItem>
                              <asp:ListItem Text="Sept" Value="31/09/2018"></asp:ListItem>
                              <asp:ListItem Text="Oct" Value="31/10/2018"></asp:ListItem>
                              <asp:ListItem Text="Nov" Value="31/11/2018"></asp:ListItem>
                              <asp:ListItem Text="Dec" Value="31/12/2018"></asp:ListItem>
                          </asp:DropDownList>
                        </td>
                        <td>Year:
                            <asp:TextBox ID="TxtEndYear" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">Supplier:
                            <asp:DropDownList ID="DdlSupplier" runat="server" DataTextField="SupplierName" DataValueField="SupplierID"></asp:DropDownList>
                        </td>
                        <td colspan="2">
                            <asp:Button ID="BtnAddSupplier" runat="server" Text="Add Supplier..." OnClick="BtnAddSupplier_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">Item Code:
                        <asp:TextBox ID="TxtItemCode" runat="server"></asp:TextBox>
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
                            <asp:Button ID="Button1" runat="server" Text="Generate Report" OnClick="Button1_Click" />
                        </td>
                    </tr>

                </table>
            </td>
            <td style="width: 70%">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="800px" Width="100%" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                                <LocalReport ReportPath="StoreReport\Report2.rdlc">
                                    <DataSources>
                                        <rsweb:ReportDataSource DataSourceId="" Name="SA45Team12ADDataSet" />
                                    </DataSources>
                                </LocalReport>
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
