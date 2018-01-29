<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ViewCatalogue.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewCatalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Stationery Request</h2>
    <div style="float: right"; vertical-align: middle" >
    <asp:TextBox ID="TxtSearch" placeholder="Search Item" Height="45px" Width="150px"  runat="server"></asp:TextBox>
    <asp:Button ID="BtnSearch" cssclass="btn btn-primary" runat="server" Text="Search" OnClick="BtnSearch_Click" />
        </div>
    <br />
    <asp:Label ID="LblCount" runat="server" Text="" ></asp:Label>
    <br />
    <table style="width: 100%">
        <tr>

<%--First GridView: ADD REQUEST --%>


            <td style="width: 63%">
                <asp:GridView ID="GridViewAddRequest" Style="width:95%" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" PageSize="10" OnPageIndexChanging="GridViewAddRequest_PageIndexChanging"
                    DataKeyNames="ItemID">
                    <AlternatingRowStyle BackColor="#f9f9f9"  />
                     <PagerStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <pagersettings mode="Numeric" position="Bottom"   />
                    <Columns>
                        <asp:TemplateField HeaderText="Item ID" SortExpression="ItemID">
                            <ItemTemplate>
                                <asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                            <ItemTemplate>
                                <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add Request" SortExpression="Description">
                            <ItemTemplate>
                                <asp:Button ID="BtnAddRequest" runat="server" Text="Add"
                                    cssclass="btn btn-primary  btn-xs"
                                    CommandName="AddRequestClicked" CommandArgument='<%# Bind("ItemID") %>'
                                    OnClick="BtnAddRequest_Click" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>



<%--Second GridView: CHECK OUT --%>


            <td style="width:37%" >
                <asp:GridView ID="GridViewCheckOut" runat="server" Style="width:95%" AutoGenerateColumns="False"
                    
                    OnRowDeleting="GridViewCheckOut_RowDeleting"
                    AllowPaging="True" PageSize="8" OnPageIndexChanging="GridViewCheckOut_PageIndexChanging"
                    DataKeyNames="ItemID">
                    <PagerStyle HorizontalAlign="Center" />
                    <pagersettings mode="Numeric" position="Bottom"   />
                    <AlternatingRowStyle BackColor="#f9f9f9" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Item ID" SortExpression="ItemID">
                            <ItemTemplate>
                                <asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                            <ItemTemplate>
                                <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText ="Delete"  DeleteText="Delete" >
                            <ControlStyle cssClass="btn btn-primary btn-xs" />
                            </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <div style="text-align:center">
    <asp:Button ID="BtnCheckOut" runat="server" cssclass="btn btn-primary"
        Text="Check Out" OnClick="BtnCheckOut_Click" />
        </div>

</asp:Content>
