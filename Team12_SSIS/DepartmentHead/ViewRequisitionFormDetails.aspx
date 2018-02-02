<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRequisitionFormDetails.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewRequisitionFormDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Requisition Form</h2>
        <h4><asp:Label ID="LblCurrentUser" runat="server" Text=""></asp:Label></h4>
    </div>
    <div>
        <span>Requisition Form ID: </span><asp:Label ID="LblReqFormID" runat="server" Text=""></asp:Label><br />
        <span>Employee Name: </span><asp:Label ID="LblEmployeeName" runat="server" Text=""></asp:Label><br />
        <span>Date Created: </span><asp:Label ID="LblDateCreated" runat="server" Text=""></asp:Label><br />
        <span>Status: </span><asp:Label ID="LblStatus" runat="server" Text=""></asp:Label><br />
        <span>Date Approved / Rejected: </span><asp:Label ID="LblDateApproved" runat="server" Text=""></asp:Label><br />
    </div>
    <br />
    <br />
        <div>
            <asp:Label ID="LblMessage" runat="server" Text="" Font-Italic="True"></asp:Label>
        </div>
    <br />
    <div>
         <asp:GridView ID="GridViewDetails" runat="server" AutoGenerateColumns="False" Width="75%" DataKeyNames="RequestDetailID" ItemType="Team12_SSIS.Model.RequisitionRecordDetail"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="Inset" >
            <Columns>
                <asp:TemplateField HeaderText="Item ID">
                    <ItemTemplate>
                        <asp:Label ID="LblReqID" runat="server" Text='<%#:Item.ItemID %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Name">
                    <ItemTemplate>
                        <asp:Label ID="LblReqID" runat="server" Text='<%#:GetItemDescription(Item.ItemID) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Requested Quantity">
                    <ItemTemplate>
                        <asp:Label ID="LblReqID" runat="server" Text='<%#:Item.RequestedQuantity %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Units Of Measure">
                    <ItemTemplate>
                        <asp:Label ID="LblReqID" runat="server" Text='<%#:GetUnitsOfMeasure(Item.ItemID) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                </asp:TemplateField>
            </Columns>
             <EmptyDataRowStyle Font-Italic="True" Font-Size="Medium" Font-Underline="False" ForeColor="#FF3300" />
                    <EmptyDataTemplate>
                        <table runat="server">
                            <tr>
                                <td>There are no items associated with this request. :(</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="LblRemarks" runat="server" Text="Remarks: " ></asp:Label><asp:TextBox ID="TxtRemarks" runat="server" Text="" Width="40%"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnApprove" CssClass="btn btn-primary" runat="server" Text="Approve" Visible="false" OnClick="BtnApprove_Click" Width="9%" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnReject" ControlStyle-CssClass="btn btn-danger" runat="server" Text="Reject" Visible="false" OnClick="BtnReject_Click" Width="9%" />
    </div>
    <br />
    <br />
    <div>
        <asp:Button ID="BtnBack" class="btn btn-success" runat="server" Text="Back" OnClick="BtnBack_Click" />
    </div>
</asp:Content>
