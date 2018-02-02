<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovePurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreManager.StoreSupervisor.ApprovePurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            <asp:Label ID="Label1" runat="server" Style="text-align: center" Text="Purchase Order Approval"></asp:Label></h1>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="LblPo" runat="server" Text="PO#:"></asp:Label>
                    <td>
                        <asp:Label ID="LblNumbeer" runat="server"></asp:Label></td>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LblDsm" runat="server" Text="Date Submitted:"></asp:Label>
                    <td class="auto-style1">
                        <asp:Label ID="LblDate" runat="server"></asp:Label></td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPos" runat="server" Text="PO Status:"></asp:Label>
                    <td>
                        <asp:Label ID="LblStatus" runat="server"></asp:Label></td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblDlt" runat="server" Text="Deliver to:"></asp:Label>
                    <td>
                        <asp:Label ID="LblDeliver" runat="server"></asp:Label></td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAds" runat="server" Text="Address:"></asp:Label>
                    <td>
                        <asp:Label ID="LblAddress" runat="server"></asp:Label></td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblRes" runat="server" Text="Requested by:"></asp:Label>
                    <td>
                        <asp:Label ID="LblRequest" runat="server"></asp:Label></td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblSlc" runat="server" Text="Supplier:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblCode" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblOdb" runat="server" Text="Ordered by:"></asp:Label>
                    <td>
                        <asp:Label ID="LblOrder" runat="server" Text="Logic University Stationery Store"></asp:Label></td>
                </td>
            </tr>
            <td colspan="2">
                <asp:GridView ID="GridViewAPO" runat="server" AutoGenerateColumns="False"
                    Style="width: 100%" ShowHeaderWhenEmpty="True"
                    OnRowDataBound="OnRowDataBound"
                    CellPadding="4" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="#f9f9f9"/>
                    <Columns>

                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="50%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblDesc" runat="server"></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="50%"></HeaderStyle>
                            <ItemStyle CssClass="text-center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="Lblquantity" runat="server" Text='<%# Bind("Quantity") %>' OnTextChanged="Txtquantity_TextChanged" AutoPostBack="true"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="10%"></HeaderStyle>
                            <ItemStyle CssClass="text-center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblUom" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            <ItemStyle CssClass="text-center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Price" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblUnp" runat="server" Width="100%" CssClass="center-block" Text='<%# ((double)Eval("UnitPrice")).ToString("c") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            <ItemStyle CssClass="text-center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblPrice" runat="server" Width="100%" CssClass="center-block" Text=""></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            <ItemStyle CssClass="text-center"></ItemStyle>
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

            <tr>

                <td>
                    <asp:Button ID="btnapr" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnapr_Click" /></td>


                <td>
                    <asp:Button ID="btncancel" runat="server" Text="Reject" CssClass="btn btn-danger" OnClick="btncancel_Click" /></td>

            </tr>
        </table>
    </div>
</asp:Content>
