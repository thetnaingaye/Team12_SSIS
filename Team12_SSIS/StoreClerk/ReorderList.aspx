<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReorderList.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ReorderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Reorder List</h1>
        <h5><%#:DateTime.Now %></h5>
        <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <br />
    <div>
         <asp:GridView ID="GridViewReorderList" runat="server" AutoGenerateColumns="False" Width="75%" DataKeyNames="ReorderID" ItemType="Team12_SSIS.Model.ReorderRecord"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="Inset">
             <Columns>
                 <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <asp:Label ID="No" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Item ID">
                        <ItemTemplate>
                            <asp:Label ID="LblItemID" runat="server" Text='<%#:Item.ItemID %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="LblItemName" runat="server" Text='<%#:GetItemDescription(Item.ItemID) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                            <asp:Label ID="LblSuppName" runat="server" Text='<%#:GetSuppilerName(Item.SupplierID) %>'></asp:Label>
                            <asp:Label ID="LblSuppID" runat="server" Text='<%#:Item.SupplierID %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="LblOrderedQty" runat="server" Text='<%#:Item.OrderedQuantity %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Units Of Measurement">
                        <ItemTemplate>
                            <asp:Label ID="LblReqID" runat="server" Text='<%#:GetUnitsOfMeasure(Item.ItemID) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
             </Columns>
             <EmptyDataRowStyle Font-Italic="True" Font-Size="Medium" Font-Underline="False" ForeColor="#FF3300" />
                    <EmptyDataTemplate>
                        <table runat="server">
                            <tr>
                                <td>There are no reorder entries at present.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
         </asp:GridView>
    </div>
    <div>
        <br />
        <br />
        <asp:Button ID="BtnSubmitAll" runat="server" Text="Send all for approval" OnClick="BtnSubmitAll_Click" />
    </div>
</asp:Content>
