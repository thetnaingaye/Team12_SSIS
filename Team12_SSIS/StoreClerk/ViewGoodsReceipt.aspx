<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewGoodsReceipt.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewGoodsReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%" class="center-block">
        <tr>
            <td colspan="5" style="height: 25px">
                <asp:Label runat="server" Text="View Goods Receipt" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label runat="server" Text="Goods Receipt:" Font-Size="Small"></asp:Label>
            </td>
            <td style="width: 10%">
                <asp:TextBox ID="TxtGRNumber" runat="server"></asp:TextBox>
            </td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPoNumber" ValidationGroup="BtnRetrieveGR" ControlToValidate="TxtGRNumber" ValidationExpression="[Gg][Rr][0-9]\d*" runat="server" ErrorMessage="Please enter a valid GR number." Display="None"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPoNumber" runat="server" ValidationGroup="BtnRetrieveGR" ControlToValidate="TxtGRNumber" ErrorMessage="Please enter a GR number." Display="None"></asp:RequiredFieldValidator>
            <td style="width: 40%">
                <asp:Button ID="BtnRetrievePO" runat="server" Text="Retrieve GR" OnClick="BtnRetrieveGR_Click" CssClass="btn btn-primary btn-xs" ValidationGroup="BtnRetrieveGR" />
            </td>

            <td colspan="2">
                <asp:Label runat="server" Text="DO Number:" Font-Size="Small" Style="padding-right: 10px"></asp:Label>
                <asp:Label ID="LblDoNumber" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummaryPo" runat="server" ValidationGroup="BtnRetrieveGR" ForeColor="red" />
            </td>
            <td></td>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Posting Date:" Font-Size="Small" Style="padding-right: 10px"></asp:Label>
                <asp:Label ID="LblGRDate" runat="server"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="PO Number:" Font-Size="Small" Style="padding-right: 10px"></asp:Label>
                <asp:Label ID="LblPoNumber" runat="server"></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Received By:" Font-Size="Small" Style="padding-right: 10px"></asp:Label>
                <asp:Label ID="LblClerkName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div>
                    <asp:GridView ID="GridViewGR" runat="server" AutoGenerateColumns="False"
                        Style="height: 100px; overflow: auto; width: 100%" DataKeyNames="GRNumber" ShowHeaderWhenEmpty="True" OnRowDataBound="OnRowDataBound" CellPadding="4" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="#F9F9F9"/>
                        <Columns>

                            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
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

                            <asp:TemplateField HeaderText="Quantity Received" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblUom" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblRemarks" runat="server" Width="100%" CssClass="center-block" Text=""></asp:Label>
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
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
