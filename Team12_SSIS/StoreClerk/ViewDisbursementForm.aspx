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
        <table style="width: 100%">
            <tbody style="width: 100%">
                <tr style="width: inherit">
                    <td colspan="7">
                        <h2>View Disbursement Form</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Disbursement List ID: "></asp:Label>
                        <asp:Label ID="LblDisbId" runat="server"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" Font-Bold="true" Text="Department: " Font-Size="Small"></asp:Label>
                        <asp:Label ID="LblDeptName" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>

                    <td colspan="4">
                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Collection Point: "></asp:Label>
                        <asp:Label ID="LblCollectPoint" runat="server"></asp:Label>

                    </td>
                    <td colspan="3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Representative Name: "></asp:Label>
                        <asp:Label ID="LblDeptRep" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Status: "></asp:Label>
                        <asp:Label ID="LblStatus" runat="server"></asp:Label>
                    </td>

                    <td colspan="3">
                        <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Collection Date: "></asp:Label>
                        <asp:Label ID="LblColDate" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td colspan="7">
                        <asp:GridView ID="GridViewDisbList" runat="server" AutoGenerateColumns="False"
                            Style="height: 100px; overflow: auto; width: 100%" DataKeyNames="ItemID" ShowHeaderWhenEmpty="True"
                            OnRowDataBound="OnRowDataBound" CellPadding="4" ForeColor="#333333">
                            <AlternatingRowStyle BackColor="#F9F9F9" ForeColor="#284775" />
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

                                <asp:TemplateField HeaderText="Description" HeaderStyle-Width="80%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="80%"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Request Quantity" Visible="false" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
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


                                <asp:TemplateField HeaderText="Collected Quantity" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
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

                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="35%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="LblRemarks" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="35%"></HeaderStyle>
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
                        <asp:button id="BtnPrint" onclientclick="javascript:window.print();" runat="Server" cssclass="btn btn-primary" xmlns:asp="#unknown" text="Print" />

                    </td>
                    <td colspan="5" align="right">
                        <asp:Button ID="BtnCancelDis" runat="server" Text="Cancel Disbursement List" CssClass="btn btn-primary" Visible="false" OnClick="BtnCancelDis_Click" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" align="right">
                        <asp:Label ID="LblCollectedBy" runat="server" Text="Collected By:" Visible="false"></asp:Label>
                        <br />
                        <asp:Image ID="ImgSignature" runat="server" Visible="false" Height="250px" Width="250px"/>
                    </td>
                </tr>
            </tbody>
        </table>
</asp:Content>
