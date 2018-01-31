<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDelegation.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ManageDelegation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    
    <h2>Manage Delegation</h2>
     &nbsp;&nbsp;
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            Current Delegate:
            <asp:Label ID="LblCurrentDelegate" runat="server"></asp:Label>
            <br />
            <br />                  
            From:<asp:Label ID="LblCurrentDelStartDate" runat="server"></asp:Label>
            &nbsp;&nbsp; To:<asp:Label ID="LblCurrentDelEndDate" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="BtnEdit" CssClass="btn btn-primary btn-xs" runat="server" OnClick="BtnEdit_Click" Text="Edit" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CancelDelegationBtn" CssClass="btn btn-primary btn-xs" runat="server" OnClick="CancelDelegationBtn_Click" Text="Cancel Delegation" />
        </asp:View>
        
        <asp:View ID="View2" runat="server">
            Delegate:<asp:Label ID="LblCurrentDelegateView2" runat="server"></asp:Label>
            <br />
            <br />
            <div id="starteditdelegate"> 
            From:
            <asp:Calendar ID="CalStartEditDelegate" runat="server"></asp:Calendar>
            </div>
            <div id="endeditdelegate" style="position: relative; left: 30%; margin-top: -270px;">
            To:
            <asp:Calendar ID="CalEndEditDelegate" runat="server"></asp:Calendar>
             </div>
            <br />
            <asp:Button ID="ApplyBtn" CssClass="btn btn-primary" runat="server" OnClick="ApplyBtn_Click" Text="Apply" />
        </asp:View>
        
        <asp:View ID="View3" runat="server">
            <h3>Add New Delegate</h3>
            <p>
                &nbsp;</p>
            Delegate:<asp:DropDownList ID="EmployeesDdl" runat="server">
            </asp:DropDownList>
            <br />
            <br />
              <div id="startadddelegate">
            From:<asp:Calendar ID="CalStartAddDelegate" runat="server"></asp:Calendar>
            </div>
              <div id="endadddelegate" style="position: relative; left: 30%; margin-top: -270px;">
            To:<asp:Calendar ID="CalEndAddDelegate" runat="server"></asp:Calendar>
            </div>
            <br />
            <asp:Button ID="BtnAddDelegate" CssClass="btn btn-primary" runat="server" OnClick="BtnAddDelegate_Click" Text="Add Delegate" />
            <br />
        </asp:View>
    </asp:MultiView>
     &nbsp;<br />
    </asp:Content>
