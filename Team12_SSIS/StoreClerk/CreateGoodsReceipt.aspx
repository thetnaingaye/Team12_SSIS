<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateGoodsReceipt.aspx.cs" Inherits="Team12_SSIS.StoreClerk.CreateGoodsReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Scripts -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
    <!--End of Scripts-->
    <table style="width: 70%" class="center-block">
        <tr>
            <td colspan="5">
                <asp:Label runat="server" Text="Create Goods Receipt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label runat="server" Text="PO Number:"></asp:Label>
            </td>
            <td style="width: 10%">
                <asp:TextBox runat="server"></asp:TextBox>
            </td>

            <td style="width: 70%">
                <asp:Button runat="server" Text="Button" OnClick="Unnamed4_Click" />
            </td>

            <td style="width: 80%">
                <asp:Label runat="server" Text="DO Number"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Posting Date"></asp:Label>
            </td>
            <td>
                <input type="text" runat="server" id="datepicker">
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div>
                    <asp:GridView ID="GridViewGR" runat="server" AutoGenerateColumns="False" 
                        style="height:100px; overflow:auto; width:100%" DataKeyNames="ItemID" ShowHeader="true" ShowFooter="true" OnRowDataBound="OnRowDataBound">
                        <Columns>
  
                            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="LblSn" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
  
                            <asp:TemplateField HeaderText="Item Code" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="LblItemCode" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantity Received" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtQty" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="LblUom" runat="server" Text='<%# Bind("UOM") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtRemarks" runat="server" Width="100%" CssClass="center-block" Text=""></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>  
                        </Columns>


                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td colspan="2" style="align-items:center">
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </td>
        </tr>
        </table>
</asp:Content>
