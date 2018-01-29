<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAdjustmentVoucherRequest.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreateAdjustmentVoucherRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="height: 25px">
                <asp:Label runat="server" Text="Create Inventory Adjustment Voucher Request" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <asp:UpdatePanel ID="Up1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <td colspan="2">

                        <asp:GridView ID="GridViewAdjV" runat="server" AutoGenerateColumns="False"
                            Style="width: 100%" ShowHeaderWhenEmpty="True"
                            OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"
                            CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ItemID">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>

                                <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                    <ItemTemplate>
                                        <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Item Code" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="UpId" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <asp:TextBox ID="TxtItemCode" runat="server" Text='<%# Bind("ItemID") %>' OnTextChanged="TxtItemCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Description" HeaderStyle-Width="50%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="50%"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Adjustment Type" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DdlAdjType" runat="server" Width="100%">
                                            <asp:ListItem Text="Minus" Value="Minus" Selected="true" />
                                            <asp:ListItem Text="Add" Value="Add" />
                                        </asp:DropDownList>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Adjustment Quantity" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="UpValue" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <asp:TextBox ID="TxtAdjQty" runat="server" Width="80%" CssClass="center-block" Text='<%# Bind("Quantity") %>' OnTextChanged="TxtAdjQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtAdjQty" ValidationGroup="BtnSendReq" runat="server" ErrorMessage="Please enter a valid quantity" ValidationExpression="^\d+$" Display="None"></asp:RegularExpressionValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UOM" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="LblUom" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Value" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="LblValue" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reason" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtReason" runat="server" Text='<%# Bind("Reason") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnAddItem" runat="server" Text="Add Item" CssClass="btn btn-success" OnClick="BtnAddItem_Click" />
            </td>
            <td align="right">
                <asp:Button ID="BtnSendReq" runat="server" Text="Send Request" CssClass="btn btn-primary" OnClick="BtnSendReq_Click" ValidationGroup="BtnSendReq" OnClientClick="this.disabled=true;" UseSubmitBehavior="false"/>
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="BtnSendReq" />
            </td>
        </tr>
    </table>
</asp:Content>
