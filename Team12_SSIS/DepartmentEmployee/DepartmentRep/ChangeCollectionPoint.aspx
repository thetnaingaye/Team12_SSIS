﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.DepartmentRep.ChangeCollectionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Change Collection Point</p>
    <p>
        Current Collection Point:<asp:Label ID="CurrentCollectionPointLbl" runat="server"></asp:Label>
    </p>
    <p>
        New Collection Point:</p>
    <p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        </asp:RadioButtonList>
    </p>
</asp:Content>
