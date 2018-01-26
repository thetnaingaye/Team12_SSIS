<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStockCard.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewStockCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
        .auto-style2 {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--refinining--%>

     <div>
        <table style="width: 75%">
             <tbody style="width: 75%">
                     <tr style="height:20px">
                    <td colspan="2" style="height: 25px">
                        
                        <asp:Label ID="LblTitle" runat="server" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                  <tr style="height:80px">
                    
                    <td> 
                      <asp:Label ID="LblInput" runat="server"   Text="Enter Item Code:" Style="padding-right: 10px" ></asp:Label>
                      <asp:TextBox ID="TxtId" runat="server" Height="20px" Width="180px"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Button ID="BtnFind" runat="server" CssClass="auto-style1" Text="Find Transaction Details" OnClick="BtnFind_Click" Width="180px"  />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="..." />
                        <br />
                      </td>
                      <td>
                          &nbsp;</td>
                     </tr>
              
                      <tr style="height:20px">
                      <td class="auto-style2">
                      <asp:Label ID="LblId" runat="server" Text="ItemCode: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblIdD" runat="server" Font-Bold="true"></asp:Label>
                          <br />
                      </td>
                      </tr>

                      <tr style="height:20px">
                      <td class="auto-style2">
                      <asp:Label ID="LbldDes" runat="server" Text="Description: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblDesD" runat="server" Font-Bold="true"></asp:Label>
                          <br />
                      </td>
                      <td class="auto-style2">
                      <asp:Label ID="LblS1" runat="server" Text="Supplier1: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblS1D" runat="server" Font-Bold="true"></asp:Label>
                     </td>
                     </tr>

                     <tr style="height:20px">
                     <td class="auto-style2">
                      <asp:Label ID="LblUom" runat="server" Text="Unit Of Measurement: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblUomD" runat="server" Font-Bold="true"></asp:Label>
                         <br />
                      </td>
                      <td class="auto-style2">
                      <asp:Label ID="LblS2" runat="server" Text="Supplier2: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblS2D" runat="server" Font-Bold="true"></asp:Label>
                     </td>
                     </tr>

                      <tr style="height:20px">
                      <td>
                      <asp:Label ID="LblBin" runat="server" Text="BIN: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblBinD" runat="server" Font-Bold="true"></asp:Label>
                          <br />
                      </td>
                      <td>
                      <asp:Label ID="LblS3" runat="server" Text="Supplier3: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblS3D" runat="server" Font-Bold="true"></asp:Label>
                     </td>
                    </tr>
                  <tr>
                    <td colspan="2">
                        <div>
                            <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="Up1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
               
                  <asp:GridView ID="GridViewStockCard" runat="server" AutoGenerateColumns="False"
                                        Style="width:100%;padding-top:50px" ShowHeaderWhenEmpty="True"
                                        OnRowDataBound="GridViewStockCard_RowDataBound"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ItemID" >
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>

                                        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                        <ItemTemplate>
                                        <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="TransactionDate" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDate" runat="server" CssClass="center-block" Text='<%# Eval("Date","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Description" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDate" runat="server" CssClass="center-block" Text='<%# Eval("Description") %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            
                                             <asp:TemplateField HeaderText="Transaction Type" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                              <ItemTemplate>
                                              <asp:Label ID="Type" runat="server" CssClass="center-block" Text='<%# Eval("Type") %>'></asp:Label>
                                              </ItemTemplate>
                                            <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                              <ItemTemplate>
                                              <asp:Label ID="Type" runat="server" CssClass="center-block" Text='<%# Eval("Quantity") %>'></asp:Label>
                                              </ItemTemplate>
                                            <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Balance" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                              <ItemTemplate>
                                              <asp:Label ID="Type" runat="server" CssClass="center-block" Text='<%# Eval("Balance") %>'></asp:Label>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>

            

            </tbody>
        </table>
               

     </div>

        
</asp:Content>

                

                 


























     <%-- <asp:Label ID="LblTitle" runat="server" Text="STOCK CARD" Font-Size="Large" ></asp:Label>
   
      <br />
   
    <p>
        <asp:Label ID="LblInput" runat="server" Text="Enter ItemId:"></asp:Label>
        <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnFind" runat="server" CssClass="auto-style1" Text="Find Transaction Details" OnClick="BtnFind_Click" />
    </p>
      <br />
     <p>
        <asp:Label ID="LblId" runat="server" Text="ItemID:"></asp:Label><asp:Label ID="LblIdD" runat="server" Text="Label" Font-Bold="true" ></asp:Label>
    </p>
    <p>
        <asp:Label ID="LbldDes" runat="server" Text="ItemDescription:"></asp:Label><asp:Label ID="LblDesD" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
         <asp:Label ID="LblBin" runat="server" Text="Bin:"></asp:Label> <asp:Label ID="LblBinD" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
      <asp:Label ID="LblUom" runat="server" Text="UOM:"></asp:Label><asp:Label ID="LblUomD" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
         <asp:Label ID="LblS1" runat="server" Text="Supplier1:"></asp:Label><asp:Label ID="LblS1D" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="LblS2" runat="server" Text="Supplier2:"></asp:Label><asp:Label ID="LblS2D" runat="server" Text="Label" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="LblsS3" runat="server" Text="Supplier3:"></asp:Label><asp:Label ID="LblS3D" runat="server" Text="Label" Font-Bold="true"></asp:Label>
         <br />
         </p>
        <asp:GridView ID="GridViewStockCard" runat="server"  OnRowDataBound="GridViewStockCard_RowDataBound" Autopostback="true">
        </asp:GridView>--%>
  
  