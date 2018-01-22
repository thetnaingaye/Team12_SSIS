<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementForm.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewDisbursementForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="LblDate" runat="server" Text="Date Range:"></asp:Label>
      &nbsp;&nbsp;
     <br />
      <asp:Label ID="LblStartDate" runat="server" Text="Start Date:"></asp:Label>
     
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     <asp:Calendar ID="CaldatePickerstartdate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="DateChange">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar> &nbsp;&nbsp;<asp:Label ID="LblEnddate" runat="server" Text="End Date:"></asp:Label>
     
     &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnFindDate" runat="server" Text="FIND" OnClick="BtnFindDate_Click"  />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
     &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Calendar ID="CalDatePickerenddate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="DateChange" CssClass="auto-style1">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </p>            
    <asp:Label ID="LblRep" runat="server" Text="Department Representative:"></asp:Label>
     
     <asp:DropDownList ID="DdlSal" runat="server">
         <asp:ListItem>Mr</asp:ListItem>
         <asp:ListItem>Ms</asp:ListItem>
         <asp:ListItem>Mrs</asp:ListItem>
     </asp:DropDownList> 
       <asp:TextBox ID="TxtRep" runat="server"></asp:TextBox>
     <asp:Button ID="BtnFindrep" runat="server" Text="FIND" OnClick="BtnFindrep_Click" />
     <br />
    &nbsp;
&nbsp;
       <br />
 <%--    <asp:GridView ID="GridViewDisbursement" runat="server" AutoPostback="true" autogeneretecolumn="false" >

     
              </asp:GridView>--%>



            <asp:GridView ID="GridViewDisbursement" runat="server" AutoGenerateColumns="False" Width="100%"
            DataKeyNames="ID"
          BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" method="Page_Load">

            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="LblBookID" runat="server" Text='<%# Bind("DisbursementID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="DepartmentID" SortExpression="Title">
                    <ItemTemplate>
                        <asp:Label ID="LblTitle" runat="server" Text='<%# Bind("DepartmentID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                    <ItemTemplate>
                        <asp:Label ID="LblISBN" runat="server" Text='<%# Bind("CollectionPointID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID">
                    <ItemTemplate>
                        <asp:Label ID="LblCatID" runat="server" Text='<%# Bind("CollectionDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author" SortExpression="Author">
                    <ItemTemplate>
                        <asp:Label ID="LblAuthor" runat="server" Text='<%# Bind("RepresentativeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
               
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>




     <br />
     <br />

     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

</asp:Content>
