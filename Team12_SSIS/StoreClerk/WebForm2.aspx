<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Team12_SSIS.StoreClerk.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Item ID">
                        <ItemTemplate>
                            <asp:TextBox ID="txtitemid" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12ADConnectionString %>" SelectCommand="SELECT * FROM [PORecordDetails]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12ADConnectionString %>" SelectCommand="SELECT * FROM [PORecords]"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
