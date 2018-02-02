<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementForm.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.DepartmentRep.ViewDisbursementForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 81px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <%--<asp:Label ID="LblTitle" runat="server" Text="DisbursementList" Font-Size="Large"></asp:Label>--%>
    <h2>Disbursement Form</h2>
    <br />
    <br />
      &nbsp;&nbsp;
     <br />
      <asp:Label ID="LblStartDate" runat="server" Text="Start Date:"></asp:Label>
  
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
    <script>
        $(function () {
            $("#datepicker2").datepicker({ dateFormat: "dd/mm/yy" }).datepicker("setDate", new Date());
        });
    </script>

	&nbsp;<input type="text" id="datepicker" name="datepicker" readonly="true" class="auto-style1" />&nbsp;
    &nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Text="End Date:"> </asp:Label>&nbsp;<input type="text" id="datepicker2" name="datepicker2" readonly="true" class="auto-style1" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnFindDate" CssClass="btn btn-primary btn-xs" runat="server" Text="FIND" OnClick="BtnFindDate_Click" Height="25px" Width="72px" />
     <br />
    &nbsp;
&nbsp;&nbsp;
       <br />
    <br />



    <asp:Label ID="LblRep" runat="server" Text="Department Representative:"></asp:Label>
     
       &nbsp; 
       <asp:TextBox ID="TxtRep" runat="server" Width="142px"></asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnFindrep" CssClass="btn btn-primary btn-xs" runat="server" Text="FIND" OnClick="BtnFindrep_Click" Width="72px" />
     <br />
       <br />
    <asp:GridView ID="GridViewDisbursement" runat="server"  Class="table"  autogeneratecolumns="false" Width="100%" GridLines="None"  BackColor="White"    ShowHeaderWhenEmpty="True" OnRowCommand="GridViewDisbList_RowCommand" EmptyDataText="No Record Found">
        <Columns>
          
                    
                                          <asp:TemplateField HeaderText="Disbursement ID" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                 
                                                 <asp:LinkButton ID="LBtnListID" runat="server" Text='<%# "DL" + (Eval("DisbursementID","{0:0000}")) %>' CommandName="show" CommandArgument='<%# Bind("DisbursementID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>


                                  

            <asp:TemplateField HeaderText="Collection Date" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDate" runat="server" CssClass="center-block" Text='<%# Eval("CollectionDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

          


             <asp:TemplateField HeaderText="Representative Name" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblrep" runat="server" CssClass="center-block" Text='<%# Eval("RepresentativeName")%>'></asp:Label>
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

    

     <br />
    <asp:Label ID="LblMsg" runat="server" ForeColor="#009900" Text="[LblStatus]"></asp:Label>

    

     </asp:Content>
<%----%>