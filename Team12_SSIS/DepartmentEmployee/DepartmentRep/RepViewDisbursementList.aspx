<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepViewDisbursementList.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.DepartmentRep.RepViewDisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 782px;
        }
        .auto-style2 {
            width: 782px;
            height: 20px;
        }
        .auto-style3 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Disbursement Details</h2>
    <%--<asp:Label ID="LblTitle" runat="server" Text="Disbursement Details" Font-Size="Large"></asp:Label>--%>
    <br />
     <br />
    <table>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LblId" runat="server" Text="Disbursement ID:" ></asp:Label>
                <asp:Label ID="LblIdD" runat="server" Text="" Font-Bold="true"> </asp:Label></td>
           <td class="auto-style3">
                <asp:Label ID="LblCollectionPoint" runat="server" Text="Collection Point:" ></asp:Label>
                &nbsp;<asp:Label ID="LblCollectionPointD" runat="server" Text="" Font-Bold="true"></asp:Label>
           </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="LblRepresentativeName" runat="server" Text="Representative Name:" ></asp:Label>
    &nbsp;<asp:Label ID="LblRepresentativeNameD" runat="server" Text="" Font-Bold="true" ></asp:Label>
            </td>
            <td>
                  <asp:Label ID="LblCollectionDate" runat="server" Text="Collection Date:" ></asp:Label>
    &nbsp; <asp:Label ID="LblCollectionDateD" runat="server" Text="" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridViewDisbursementDetails" Class="table" runat="server"  AutoGenerateColumns="false" Width="100%" GridLines="None"  BackColor="White"    ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found">
        <Columns>
        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDepartment" runat="server" CssClass="center-block" Text='<%# Eval("ItemDescription")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

             <asp:TemplateField HeaderText="Quantity Requested" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDepartment" runat="server" CssClass="center-block" Text='<%# Eval("QuantityRequested")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

             <asp:TemplateField HeaderText="Quantity Collected" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDepartment" runat="server" CssClass="center-block" Text='<%# Eval("QuantityCollected")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unit Of Measurement" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDepartment" runat="server" CssClass="center-block" Text='<%# Eval("UnitOfMeasurement")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

              <asp:TemplateField HeaderText="status" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDepartment" runat="server" CssClass="center-block" Text='<%# Eval("status")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
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
</asp:Content>
