<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.DepartmentRep.ChangeCollectionPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <h2>Change Collection Point</h2>
        
    <p>
        Current Collection Point: <asp:Label ID="CurrentCollectionPointLbl" runat="server"></asp:Label>
    </p>
    <p>
        New Collection Point:
    </p>
    <p>
        <asp:RadioButtonList ID="CollectionPointRbtnl" runat="server">
        </asp:RadioButtonList>
    </p>
    <p>
        <asp:Button ID="ChangeCollectionPointBtn" CssClass="btn btn-primary" runat="server" Text="Change Collection Point" OnClick="ChangeCollectionPointBtn_Click" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
    </p>
    <p>
        <asp:Label ID="ChangedLbl" runat="server" Visible="False"></asp:Label>
    </p>
</asp:Content>
