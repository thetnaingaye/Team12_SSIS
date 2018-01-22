<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.DepartmentRep.ChangeCollectionPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Change Collection Point
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
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
        <asp:Button ID="ChangeCollectionPointBtn" runat="server" Text="Change Collection Point" OnClick="ChangeCollectionPointBtn_Click" />
    </p>
    <p>
        <asp:Label ID="ChangedLbl" runat="server" Visible="False"></asp:Label>
    </p>
</asp:Content>
