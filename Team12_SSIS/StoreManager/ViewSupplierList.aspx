<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupplierList.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewSupplierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 1115px;
            overflow: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Supplier List</h2>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Button ID="BtnCreate" cssclass="btn btn-primary" runat="server" Text="Create" OnClick="BtnCreate_Click" />
                </td>
            </tr>
        <tr>
            <td>
                <div style="float: right"; vertical-align: middle" >
                <asp:TextBox ID="TxtSearch" placeholder="Search Supplier" Height="45px" Width="150px" runat="server"></asp:TextBox>
                <asp:Button ID="BtnSearch" cssclass="btn btn-primary" runat="server" Text="Search" OnClick="BtnSearch_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <div style="width:100%">
                <asp:GridView ID="GridViewSupplier" class="table" runat="server" AutoGenerateColumns="False"  
                    Style="width: 100%"
                    AllowPaging="True" PageSize="10" OnPageIndexChanging="GridViewSupplier_PageIndexChanging"
                    OnRowCancelingEdit="GridViewSupplier_RowCancelingEdit"
                    OnRowDataBound="GridViewSupplier_RowDataBound"
                    OnRowEditing="GridViewSupplier_RowEditing"
                    OnRowUpdating="GridViewSupplier_RowUpdating"
                    DataKeyNames="SupplierID">
                    <AlternatingRowStyle BackColor="#f9f9f9"  />
                     <PagerStyle HorizontalAlign="Center" />
                    <pagersettings mode="Numeric" position="Bottom"   />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        
                        <asp:TemplateField HeaderText="Supplier ID" SortExpression="SupplierID">
                            <ItemTemplate>
                                <asp:Label ID="LblSupplierID" runat="server" Text='<%# Bind("SupplierID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Supplier Name" SortExpression="SupplierName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="GST No" SortExpression="GSTRegistrationNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtGSTRegistrationNo" runat="server" Text='<%# Bind("GSTRegistrationNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblGSTRegistrationNo" runat="server" Text='<%# Bind("GSTRegistrationNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Contact Name" SortExpression="ContactName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Phone No" SortExpression="PhoneNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" ControlToValidate="TxtPhoneNo" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Fax No" SortExpression="FaxNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtFaxNo" runat="server" Text='<%# Bind("FaxNo") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorFax" ControlToValidate="TxtFaxNo" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblFaxNo" runat="server" Text='<%# Bind("FaxNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Address" SortExpression="Address">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Lead Time" SortExpression="OLT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtOrderLeadTime" runat="server" TextMode="Number" Text='<%# Bind("OrderLeadTime") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorOLT" ControlToValidate="TxtOrderLeadTime" ErrorMessage="*Positive Number Only" ForeColor="Red"
                        runat="server" ValidationExpression="^\d+$"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblOrderLeadTime" runat="server" Text='<%# Bind("OrderLeadTime") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Discontinue" SortExpression="Discontinued">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DdlDiscontinued" runat="server" AutoPostBack="false">
                                    <asp:ListItem Selected="True" Value="No"> No </asp:ListItem>
                                    <asp:ListItem Value="Yes"> Yes </asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblDiscontinued" runat="server" Text='<%# Bind("Discontinued") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        
                        <asp:CommandField ButtonType="Button"  ShowEditButton="True" HeaderText ="Edit Supplier" 
                            EditText="Edit" UpdateText="Update" CancelText="Cancel"><ControlStyle cssClass="btn btn-primary btn-xs" />
                        </asp:CommandField>

                    </Columns>
                    
                </asp:GridView>
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>
