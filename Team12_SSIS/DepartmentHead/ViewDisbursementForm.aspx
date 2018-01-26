<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementForm.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewDisbursementForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="LblTitle" runat="server" Text="DisbursementList" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LblDate" runat="server" Text="Filter by date range:"></asp:Label>
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
            $("#datepicker").datepicker().datepicker("setDate", new Date());
        });
    </script>
    <script>
        $(function () {
            $("#datepicker2").datepicker().datepicker("setDate", new Date());
        });
    </script>

	&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" id="datepicker" name="datepicker" readonly="true" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="End Date:"> </asp:Label>&nbsp;<input type="text" id="datepicker2" name="datepicker2" readonly="true" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="BtnFindDate" runat="server" Text="FIND" OnClick="BtnFindDate_Click" Height="25px" />
     <br />
    &nbsp;
&nbsp;&nbsp;
       <br />
    <br />



    <asp:Label ID="LblRep" runat="server" Text="Department Representative:"></asp:Label>
     
     <asp:DropDownList ID="DdlSal" runat="server">
         <asp:ListItem>Mr</asp:ListItem>
         <asp:ListItem>Ms</asp:ListItem>
         <asp:ListItem>Mrs</asp:ListItem>
     </asp:DropDownList> 
       &nbsp; 
       <asp:TextBox ID="TxtRep" runat="server"></asp:TextBox>
     &nbsp;
     <asp:Button ID="BtnFindrep" runat="server" Text="FIND" OnClick="BtnFindrep_Click" />
     <br />
       <br />
    <asp:GridView ID="GridViewDisbursement" runat="server"    autogeneratecolumns="false" Width="100%" GridLines="None"  BackColor="White"    ShowHeaderWhenEmpty="True" OnRowCommand="GridViewDisbList_RowCommand">
        <Columns>
          
                    
                                          <asp:TemplateField HeaderText="Disbursement ID" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                   <%-- <asp:Label ID="LblDate" runat="server" CssClass="center-block" Text='<%# Eval("DisbursementID")%>'></asp:Label>--%>
                                                 <asp:LinkButton ID="LBtnListID" runat="server" Text='<%# "DL" + (Eval("DisbursementID")) %>' CommandName="show" CommandArgument='<%# Bind("DisbursementID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Department" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDepartment" runat="server" CssClass="center-block" Text='<%# Eval("DepartmentName")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

            <asp:TemplateField HeaderText="Collection Date" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDate" runat="server" CssClass="center-block" Text='<%# Eval("CollectionDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                         <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

             <asp:TemplateField HeaderText="Collection Point" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCPoint" runat="server" CssClass="center-block" Text='<%# Eval("CollectionPoint")%>'></asp:Label>
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

    

     </asp:Content>
<%----%>