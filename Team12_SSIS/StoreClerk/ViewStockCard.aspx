<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStockCard.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewStockCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
  


    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style5 {
            height: 84px;
        }
        .auto-style6 {
            width: 100px;
            height: 23px;
        }
    </style>
    
  


    </asp:Content>

 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
   <%-- Datetime picker script --%>
   <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
    $( "#datepicker" ).datepicker();
  } );
  </script>
    <script>
  $( function() {
    $( "#datepicker2" ).datepicker();
  } );
  </script>


        <table>
            <tbody style="width: 100%">

            <tr>
            <td class="auto-style1">
           <%--<asp:Label ID="LblTitle" runat="server" Font-Size="Large"></asp:Label>--%>
               <h2>Stock Card</h2>
            </td>-
            </tr>
            
           <tr>
            <td class="auto-style5">
                 
                        <%-- Input ItemId --%>
                      <asp:Label ID="LblInput" runat="server"   Text="Enter Item Code:" Style="padding-right: 5px" ></asp:Label>
                      &nbsp;<asp:TextBox ID="TxtId" runat="server" Height="23px" Width="100px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Italic="True" ForeColor="Blue" NavigateUrl="~/StoreClerk/ViewInventoryList.aspx">Find Item Code</asp:HyperLink>
&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<%-- Search button to search the transaction details --%>&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

                         <%--Button redirect to inventory  --%>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Lblstratdate" runat="server" Text="Start Date:"></asp:Label>
                            &nbsp;&nbsp;&nbsp; <input type="text" id="datepicker" name="datepicker" readonly="true" placeholder="Start Date" class="auto-style6" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" Text="End Date:"></asp:Label>
                            &nbsp;&nbsp;&nbsp; <input type="text" id="datepicker2" name="datepicker2" readonly="true" placeholder="End Date" class="auto-style6" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnFind" runat="server" CssClass="btn btn-primary btn-xs" Text="View Transaction Details" OnClick="BtnFind_Click" Width="182px" Height="30px"  />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      </td>
                      </tr>
                       <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           </td>
                   
                        </tr>
                        </tbody>
                        </table>
               
            <br />
                       <table style="width: 100%">
                        <tbody style="width: 100%">
                      <tr>
                      <td margin-top:77 class="auto-style2">
                         
                      <asp:Label ID="LblId" runat="server" Text="ItemCode: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblIdD" runat="server" Font-Bold="true"></asp:Label>
                      <br />
                      </td>
                      </tr>
                      <tr style="height:20px">
                      <td margin-top:77>
                      <asp:Label ID="LbldDes" runat="server" Text="Description: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblDesD" runat="server" Font-Bold="true"></asp:Label>
                          <br />
                      </td>
                      <td margin-top:77>
                      <asp:Label ID="LblS1" runat="server" Text="Supplier1: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblS1D" runat="server" Font-Bold="true"></asp:Label>
                      </td>
                      </tr>

                     <tr style="height:20px">
                     <td margin-top:77>
                      <asp:Label ID="LblUom" runat="server" Text="Unit Of Measurement: " Style="padding-right: 10px"></asp:Label>
                      <asp:Label ID="LblUomD" runat="server" Font-Bold="true"></asp:Label>
                         <br />
                      </td>
                      <td margin-top:77>
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

                    
               
                  <asp:GridView ID="GridViewStockCard" Class="table" runat="server" AutoGenerateColumns="False"
                                        Style="width:100%;padding-top:50px" 
                                       
                                        CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ItemID" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found">
                                        <AlternatingRowStyle BackColor="#f9f9f9"  />
                                        <Columns>

                                        <asp:TemplateField HeaderText="#" HeaderStyle-Width="2%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                            <ItemTemplate>
                                            <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="2%"></HeaderStyle>
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Transaction Date" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                <asp:Label ID="LblDate" runat="server" CssClass="center-block" Text='<%# Eval("Date","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                </ItemTemplate><HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Description" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDate" runat="server" CssClass="center-block" Text='<%# Eval("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                             <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            
                                             <asp:TemplateField HeaderText="Transaction Type" HeaderStyle-Width="3%" HeaderStyle-CssClass="text-left" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                              <ItemTemplate>
                                              <asp:Label ID="Type" runat="server" CssClass="center-block" Text='<%# Eval("Type") %>'></asp:Label>
                                              </ItemTemplate>
                                            <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="3%"></HeaderStyle>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Units Of Measurement" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                              <ItemTemplate>
                                              <asp:Label ID="Type" runat="server" CssClass="center-block" Text='<%# Eval("UOM") %>'></asp:Label>
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
                    
                                    </asp:GridView>
                                <br />
               
                            <asp:Label ID="LblMsg" runat="server" Text="statusMsg" Font-Size="Larger" ForeColor="Green"></asp:Label>
               
                            <br />
                               
                        </div>
                    </td>
                </tr>

            </tbody>
        </table>
               

    
  
</asp:Content>

                

                 

























