﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreatePurchaseOrder" %>

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
    <div>
        <h1>
            <asp:Label ID="LblRpo" runat="server" Style="text-align: center" Text="Raise Stationary Purchase Order "></asp:Label></h1>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="LblPod" runat="server" Text="PO date:"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="LblPODate" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="LblRst" runat="server" Text="Requested By:"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="LblRequest" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblDlt" runat="server" Text="Deliver to :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDlt" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LblSli" runat="server" Text="Supplier ID:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlSli" runat="server" DataTextField="SupplierName" DataValueField="SupplierID"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAds" runat="server" Text="Address:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAds" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblSid" runat="server" Text="Please supply the items by(date):"></asp:Label></td>
                <td>
                    <input type="text" id="datepicker" name="datepicker" readonly="true" />
                </td>
                <td class="auto-style4">
                    <asp:Label ID="OdbLbl" runat="server" Text="Ordered by:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="Lblorder" runat="server" Text="Logic University Stationery Store"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ScriptManager ID="sml" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="Upl" runat="server" UpdateMode="Conditional" ChildrenAsTriger="true">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewPO" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewPO_SelectedIndexChanged"
                                Style="width: 100%" ShowHeaderWhenEmpty="True"
                                OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"
                                CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ItemID">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                        <ItemStyle CssClass="text-center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID">
                                        
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="Upid" runat="server" UpdateMode="Conditional" ChildrenAsTriger="true">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="Txtitemid" runat="server" Text='<%# Bind("ItemID") %>' OnTextChanged="Txtitemid_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
ControlToValidate="Txtitemid" ForeColor="Red"
ErrorMessage="RequiredFieldValidator">Item ID is required</asp:RequiredFieldValidator>--%>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="10%"></HeaderStyle>
                                        <ItemStyle CssClass="text-center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDes" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="15%"></HeaderStyle>
                                        <ItemStyle CssClass="text-center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:UpdatePanel runat="server" ID="UpValue" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="Txtquantity" runat="server" Text='<%# Bind("Quantity") %>' OnTextChanged="Txtitemid_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                        <ItemStyle CssClass="text-center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UOM">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DdlUOM" runat="server">
                                                <asp:ListItem Selected="True" Value="Each">Each</asp:ListItem>
                                                <asp:ListItem Value="Box">Box</asp:ListItem>
                                                <asp:ListItem Value="Packet">Packet</asp:ListItem>
                                                <asp:ListItem Value="Dozen">Dozen</asp:ListItem>
                                                <asp:ListItem Value="Set">Set</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LblUnp" runat="server"></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                        <ItemStyle CssClass="text-center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LblPrice" runat="server"></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                        <ItemStyle CssClass="text-center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger">
                                        <ControlStyle CssClass="btn btn-danger" />
                                    </asp:CommandField>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnAddItem" runat="server" Text="Add Item" CssClass="btn btn-success" OnClick="BtnAddItem_Click" />
                </td>
                <td colspan="3" align="center">Total Price: 
                    <asp:Label ID="LblTotal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="BtnSfa" runat="server" Text="Submit for approval" OnClick="BtnSfa_Click" />

                </td>
                
            </tr>
        </table>

    </div>
</asp:Content>





