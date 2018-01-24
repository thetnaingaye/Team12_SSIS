<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementForm.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewDisbursementList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Print Script -->
    <style type="text/css" media="screen">
        .button {
            border: 1px;
        }
    </style>
    <style type="text/css" media="print">
        .button {
            display: none;
        }
    </style>
    <!-- End of Print -->
    <table style="width: 100%" class="center-block">
        <tr>
            <td colspan="5">
                <asp:Label runat="server" Text="Create Disbursement Form" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label ID="Label5" runat="server" Text="Disbursement List ID: "></asp:Label>
            </td>
            <td style="width: 10%">
                <asp:Label ID="LblDisbId" runat="server"></asp:Label>
            </td>
            <td style="width: 40%"></td>
            <td>
                <asp:Label runat="server" Text="Department: " Font-Size="Small"></asp:Label></td>
            <td>
                <asp:Label ID="LblDeptName" runat="server"></asp:Label></td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="Label2" runat="server" Text="Collection Point: "></asp:Label>

            </td>
            <td colspan="2" class="auto-style1">
                <asp:Label ID="LblCollectPoint" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Representative Name: "></asp:Label></td>
            <td>
                <asp:Label ID="LblDeptRep" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Status: "></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="LblStatus" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Collection Date: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblColDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="GridViewDisbList" runat="server" AutoGenerateColumns="False"
                    Style="height: 100px; overflow: auto; width: 100%" DataKeyNames="ItemID" ShowHeaderWhenEmpty="True"
                    OnRowDataBound="OnRowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                                <asp:Label ID="LblReqQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("QuantityRequested") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actual Quantity" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblActulQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("ActualQuantity") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Collected Quantity" Visible="false" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblCollectQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("QuantityCollected") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblUom" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblRemarks" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("Remarks") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
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
        <tr>
            <td colspan="2">
              <asp:Button id="BtnPrint" onclientclick="javascript:window.print();" runat="Server" cssclass="button" xmlns:asp="#unknown" Text="Print"/>

            </td>
            <td colspan="3" style="align-content: flex-end">
                <asp:Button ID="BtnCancelDis" runat="server" Text="Cancel Disbursement List" CssClass="btn btn-group-xs" Visible="false" OnClick="BtnCancelDis_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
