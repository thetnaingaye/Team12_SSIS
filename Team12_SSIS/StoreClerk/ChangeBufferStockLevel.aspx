<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeBufferStockLevel.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ChangeBufferStockLevel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <strong>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <strong>Ammend Buffer Stock Level<br />
                <br />
                Item Code:<asp:TextBox ID="TxtItemCode" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Button ID="FindBtn" runat="server" OnClick="FindBtn_Click" Text="Find" />
                &nbsp;
                <br />
                </strong>
            </asp:View>
            <br />
            <asp:View ID="View2" runat="server">
                <strong>Ammend Buffer Stock Level<br /> <br /> Item Code:
                <asp:Label ID="LblItemCode" runat="server"></asp:Label>
                <br />
                Item Description:<asp:Label ID="LblItemDescription" runat="server"></asp:Label>
                <br />
                </strong>
                <br />
                <p>
                    <asp:Label ID="AutomationStatusLbl" runat="server"></asp:Label>
                </p>
                <p>
                    Indicate desired buffer stock level:</p>
                <p>
                    <asp:RadioButton ID="ProportionalRbtn" runat="server" Text="Proportional" GroupName ="RadioButtonGroup" AutoPostBack ="true" OnCheckedChanged="ProportionalRbtn_CheckedChanged" />
                    (%)<asp:TextBox ID="TxtProportional" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:RadioButton ID="AbsoluteRbtn" runat="server" Text="Absolute" GroupName ="RadioButtonGroup" OnCheckedChanged="AbsoluteRbtn_CheckedChanged" AutoPostBack="True" />
                    <asp:TextBox ID="TxtAbsolute" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:RadioButton ID="AutomationRbtn" runat="server" Text="Calculate Automatically" GroupName ="RadioButtonGroup" AutoPostBack="True" OnCheckedChanged="AutomationRbtn_CheckedChanged"/>
                </p>
                <p>
                    <asp:Button ID="SaveBtn" runat="server" Text="Save" OnClick="SaveBtn_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back" />
                </p>
                <p>
                    <asp:Label ID="StatusChangedLbl" runat="server"></asp:Label>
                </p>
            </asp:View>
        </asp:MultiView>
        </strong></p>
    <p>
        &nbsp;</p>
    </asp:Content>
