<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDisbursementList.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewDisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LblTitle" runat="server" Text="Disbursement Details" Font-Size="Large"></asp:Label>
    <br />
     <asp:Label ID="LblCollectionPoint" runat="server" Text="CollectionPoint:" ></asp:Label>
    &nbsp;<asp:Label ID="LblCollectionPointD" runat="server" Text="" ></asp:Label>
    <br />
      <asp:Label ID="LblCollectionDate" runat="server" Text="CollectionDate:" ></asp:Label>
    &nbsp; <asp:Label ID="LblCollectionDateD" runat="server" Text="" ></asp:Label>
    <br />
     <asp:Label ID="LblRepresentativeName" runat="server" Text="RepresentativeName:" ></asp:Label>
    &nbsp;<asp:Label ID="LblRepresentativeNameD" runat="server" Text="" ></asp:Label><br />
    <br />
    <asp:GridView ID="GridViewDisbursementDetails" runat="server"></asp:GridView>
</asp:Content>
