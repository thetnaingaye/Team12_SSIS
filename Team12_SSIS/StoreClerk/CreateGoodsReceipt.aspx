<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateGoodsReceipt.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreateGoodsReceipt" %>

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
    <table style="width: 100%" class="center-block">
        <tr>
            <td colspan="5">
                <asp:Label runat="server" Text="Create Goods Receipt" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label runat="server" Text="PO Number:" Font-Size="Small"></asp:Label>
            </td>
            <td style="width: 10%">
                <asp:TextBox ID="TxtPONumber" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HiddenFieldPONumber" runat="server" />
            </td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPoNumber" ValidationGroup="BtnRetrievePO" ControlToValidate="TxtPONumber" ValidationExpression="^[1-9]\d*$" runat="server" ErrorMessage="Please enter a valid PO number." Display="None"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPoNumber" runat="server" ValidationGroup="BtnRetrievePO" ControlToValidate="TxtPONumber" ErrorMessage="Please enter a PO number." Display="None"></asp:RequiredFieldValidator>
            <td style="width: 70%">
                <asp:Button ID="BtnRetrievePO" runat="server" Text="Retrieve PO" OnClick="BtnRetrievePO_Click" CssClass="btn btn-primary btn-xs" ValidationGroup="BtnRetrievePO" />
            </td>

            <td style="width: 80%">
                <asp:Label runat="server" Text="DO Number:" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtDoNumber" runat="server"></asp:TextBox>

            </td>
        </tr>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDoNumber" ValidationGroup="BtnCreateGR" runat="server" ControlToValidate="TxtDoNumber" ErrorMessage="Please enter a DO number." Display="None"></asp:RequiredFieldValidator>
        <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="ValidationSummaryPo" runat="server" ValidationGroup="BtnRetrievePO" ForeColor="red" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Posting Date:" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <input type="text" id="datepicker" name="datepicker" readonly="true" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div>
                    <asp:GridView ID="GridViewGR" runat="server" AutoGenerateColumns="False"
                        Style="height: 100px; overflow: auto; width: 100%" DataKeyNames="PONumber" ShowHeaderWhenEmpty="True" OnRowDataBound="OnRowDataBound" CellPadding="4" ForeColor="#333333">
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


                            <asp:TemplateField HeaderText="Quantity Ordered" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblOrd" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Quantity Received" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="TxtQty" ValidationGroup="BtnCreateGR" ErrorMessage="Please enter an Integer for quantity" ValidationExpression="^\d+$" Display="None"></asp:RegularExpressionValidator>
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
                                    <asp:TextBox ID="TxtRemarks" runat="server" Width="100%" CssClass="center-block" Text=""></asp:TextBox>
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
        <tr>
            <td colspan="3">
                <asp:Label ID="LblQtyValid" runat="server"></asp:Label></td>
            <td colspan="2" style="align-items: center">

                <asp:ValidationSummary ID="ValidatorSummary1" runat="server" ValidationGroup="BtnCreateGR" ForeColor="Red" />
                <br />
                <asp:Button ID="BtnPostGR" runat="server" Text="Post Goods Receipt" CssClass="btn btn-primary center-block" Visible="false" OnClick="BtnPostGR_Click" ValidationGroup="BtnCreateGR" />
            </td>
        </tr>
    </table>
</asp:Content>
