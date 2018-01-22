<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreatePurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
            height: 50px;
            width: 100px;
        }

        .auto-style2 {
            height: 50px;
        }

        .auto-style3 {
            height: 50px;
        }

        .auto-style4 {
            height: 50px;
            width: 100px;
        }

        .auto-style5 {
            height: 50px;
            width: 100px;
        }

        .auto-style6 {
            width: 100px;
        }

        .auto-style7 {
            height: 50px;
            width: 100px;
        }

        .auto-style14 {
            width: 100px;
        }
        .auto-style15 {
            height: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>
            <asp:Label ID="RpoLbl" runat="server" Style="text-align: center" Text="Raise Stationary Purchase Order "></asp:Label></h1>

        <table>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="PodLbl" runat="server" Text="PO date:"></asp:Label>
                </td>

                <td class="auto-style2">
                    <asp:Label ID="PODateLbl" runat="server"></asp:Label></td>
                <td></td>
                <td class="auto-style3">
                    <asp:Label ID="RstLbl" runat="server" Text="Requested By:"></asp:Label>
                </td>

                <td class="auto-style2">
                    <asp:Label ID="RequestLbl" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="DltLbl" runat="server" Text="Deliver to :"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TxtDlt" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td class="auto-style5">
                    <asp:Label ID="SliLbl" runat="server" Text="Supplier ID:"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DdlSli" runat="server" Height="27px" Width="131px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="AdsLbl" runat="server" Text="Address:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="TxtAds" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                    <td class="auto-style5">
                       
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="SidLbl" runat="server" Text="Please supply the items by(date):"></asp:Label></td>
                            <td class="auto-style4">
                                <asp:TextBox ID="txtSid" runat="server" Height="16px" Width="122px"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="22px" ImageUrl="~/Images/2-2-calendar-png-image.png" OnClick="ImageButton1_Click" />
                            </td>
                            <td class="auto-style1">
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
                            </td>
                            <td class="auto-style4">
                                <asp:Label ID="OdbLbl" runat="server" Text="Ordered by:"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:Label ID="Lblorder" runat="server"></asp:Label>
                            </td>
                    </td>
                </tr>
            <tr><td>
                <asp:ScriptManager ID="sml" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="Upl" runat="server" UpdateMode="Conditional" ChildrenAsTriger="true">
                    <ContentTemplate>
                        <asp:GridView ID="GridViewPO" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                             Style="height: 100px; overflow: auto" ShowHeaderWhenEmpty="True"
                                        OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ItemID">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                            <Columns>
                                <asp:TemplateField HeaderText="Item ID">
                                    <ItemTemplate>
                                        <asp:UpdatePanel ID="Upid" runat="server" UpdateMode="Conditional" ChildrenAsTriger="true">
                                            <ContentTemplate>
                                                <asp:TextBox ID="Txtitemid" runat="server" Text='<%# Bind("ItemID") %>' OnTextChanged="Txtitemid_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="DesLbl" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="UpValue" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                        <asp:TextBox ID="Txtquantity" runat="server" Text='<%# Bind("Quantity") %>' OnTextChanged="Txtquantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UOM">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DdlUOM" runat="server">
                                            <asp:ListItem Text="UOM" Value="string" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Price">
                                    <ItemTemplate>
                                        <asp:Label ID="UnpLbl" runat="server"></asp:Label>
                                    </ItemTemplate></asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:Label ID="PriceLbl" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                </tr>
            <tr>
                    <td>
                        <asp:Button ID="BtnAddItem" runat="server" Text="Add Item" CssClass="btn btn-success" OnClick="BtnAddItem_Click" />
                    </td></tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="totLbl" runat="server" Text="Total:"></asp:Label>
                    </td>

                    <td class="auto-style15">
                        <asp:Label ID="totalLbl" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="auto-style16">
                        <td>
                            <td>
                                <td>
                                    <td>
                                        <td>
                                            <asp:Button ID="btnSfa" runat="server" Text="Submit for approval" /></td>
                                    </td>
                                </td>
                            </td>
                        </td>
                        <td>
                            <td>
                                <asp:Button ID="btcancel" runat="server" Text="Cancel" /></td>
                        </td>
                </tr>
            </tr>
        </table>

    </div>
</asp:Content>





