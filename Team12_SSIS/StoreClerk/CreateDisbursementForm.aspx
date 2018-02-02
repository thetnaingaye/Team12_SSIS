<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateDisbursementForm.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreateDisbursementList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Calender Script-->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker({dateFormat: "dd/mm/yy"}).datepicker("setDate", new Date());
        });
    </script>
    <table style="width: 100%" class="center-block">
        <tr>
            <td colspan="5">
                <h2>Create Disbursement Form</h2>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label runat="server" Text="Department: " Font-Size="Small"></asp:Label>
            </td>
            <td style="width: 10%">
                <asp:DropDownList ID="DdlDept" runat="server"  AutoPostBack="true" DataTextField="DepartmentName" DataValueField="DeptID" OnSelectedIndexChanged="DdlDept_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td style="width: 40%">
                <asp:Button ID="BtnRetrievePO" runat="server" Text="Retrieve" OnClick="BtnRetrieve_Click" CssClass="btn btn-primary btn-xs" ValidationGroup="BtnRetrievePO" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Representative Name: "></asp:Label></td>
            <td>
                <asp:Label ID="LblDeptRep" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="Label2" runat="server" Text="Collection Point: "></asp:Label>

            </td>
            <td colspan="2">
                <asp:Label ID="LblCollectPoint" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Collection Date: "></asp:Label>
            </td>
            <td>
                <input type="text" id="datepicker" name="datepicker" readonly="true" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                    <asp:GridView ID="GridViewDisbList" CssClass="table" runat="server" AutoGenerateColumns="False"
                        Style="height: 100px; overflow: auto; width: 100%" DataKeyNames="ItemID" ShowHeaderWhenEmpty="True"
                        OnRowDataBound="OnRowDataBound" OnRowDeleting="RowDeleting" CellPadding="4" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="#f9f9f9"/>
                        <Columns>

                            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                <ItemTemplate>
                                    <asp:Label ID="LblSn" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Item Code" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblItemCode" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                                    <asp:HiddenField ID="HideRetriId" runat="server" Value='<%# Bind("RetrievalID") %>'/>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Request Quantity" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblReqQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("RequestedQuantity") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actual Quantity" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblActulQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("ActualQuantity") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblUom" runat="server"></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtRemarks" runat="server" Width="100%" CssClass="center-block"></asp:TextBox>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />

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
        <tr>
            <td colspan="5" style="align-content:flex-end">
                <asp:Button ID="BtnCreateDis" runat="server" Text="Create Disbursement List" CssClass="btn btn-primary center-block" Visible="false" OnClick="BtnCreateDis_Click" ValidationGroup="BtnCreateGR" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
            </td>
        </tr>
    </table>
</asp:Content>
