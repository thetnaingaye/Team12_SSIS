<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Team12_SSIS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
        <div style="width: 400px; margin-left: auto; margin-right: auto;">
            <asp:Login ID="Login1" runat="server" OnLoggedIn="Page_Load"></asp:Login>
        </div>
    </div>

</asp:Content>
