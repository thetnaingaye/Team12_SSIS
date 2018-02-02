<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementList.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewDisbursementList1" %>

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
            $("#datepicker").datepicker({ dateFormat: "dd/mm/yy" }).datepicker("setDate", new Date());
        });
    </script>
    <table style="width: 100%">
                <tr>
            <td colspan="7">
                <h2>List of Disbursement Forms</h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Department: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DdlDept" runat="server" DataTextField = "DepartmentName" DataValueField = "DeptID"></asp:DropDownList>
                <asp:Button ID="BtnRetrieve" runat="server" CssClass="btn btn-primary btn-xs" Text="Retrieve..." OnClick="BtnRetrieve_Click" />
            </td>
            <td colspan="4">                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Collection Point and Time: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DdlColPoint" runat="server" DataValueField = "CollectionPointID" DataTextField = "CollectionPoint1"></asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Status: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DdlStatus" runat="server">
                    <asp:ListItem Selected="True" Value="Pending Collection">Pending Collection</asp:ListItem>
                    <asp:ListItem Value="Collected">Collected</asp:ListItem>
                    <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                    <asp:ListItem Value="All">All</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Collection Date: "></asp:Label>
            </td>
            <td>
                <input type="text" id="datepicker" name="datepicker" placeholder="dd/MM/yyyy"/>
            </td>
            <td>
                <asp:Button ID="BtnSearch" CssClass="btn btn-primary btn-xs" runat="server" Text="Search..." OnClick="BtnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:GridView ID="GridViewDisbList" CssClass="table" runat="server" Style="width: 100%" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    OnRowDataBound="GridViewDisbList_RowDataBound" OnRowCommand="GridViewDisbList_RowCommand">
                    <AlternatingRowStyle BackColor="#f9f9f9" />
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <asp:Label ID="LblSn" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="List ID">
                            <ItemTemplate>
                                <asp:LinkButton ID="LBtnListID" runat="server" Text='<%# "DL" + ((int)Eval("DisbursementID")).ToString("0000") %>' CommandName="ViewForm" CommandArgument='<%# Bind("DisbursementID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Collection Date">
                            <ItemTemplate>
                                <asp:Label ID="LblDate" runat="server" Text='<%# ((DateTime)Eval("CollectionDate")).ToString("d") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="LblDept" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Collection Point">
                            <ItemTemplate>
                                <asp:Label ID="LblColPoint" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="LblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Representative Name">
                            <ItemTemplate>
                                <asp:Label ID="LblRep" runat="server" Text='<%# Eval("RepresentativeName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>