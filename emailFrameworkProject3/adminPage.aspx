<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="emailFrameworkProject3.adminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
        <style>
        .divider{
            width:10px;
            height:auto;
            display:inline-block;
        }
        .divider2{
            width:30px;
            height:auto;
            display:inline-block;
        }
        .leftMargin{
            width:150px;
            display:inline-block;
        }
        body{
            background-color:wheat;
        }
        img{
            width: 100px;
        }

    </style>
<head runat="server">


    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <asp:Label ID="lblUser" runat="server" Font-Size="23pt" Text="Label"></asp:Label>
            <div class ="divider"></div>
            <asp:Button ID="btnViewFlagged" runat="server" Text="View Flagged Email" OnClick="btnViewFlagged_Click" />
            <div class="divider2"></div>
            <asp:Button ID="btnViewUsers" runat="server" Text="View Users" OnClick="btnViewUsers_Click" />
            <div class="divider"></div>
            <asp:Button ID="btnBan" runat="server" Text="Ban Users" OnClick="btnBan_Click" />
            <div class="divider"></div>
            <asp:Button ID="btnUnban" runat="server" Text="UnBan" OnClick="btnUnban_Click" />
            <div class="divider"></div>
            <asp:Button ID="btnLogout" runat="server" Text="Log out" OnClick="btnLogout_Click"/>
            <br />
            <asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False">
                <Columns>
                    <asp:ImageField DataImageUrlField="avatar" HeaderText="Image">
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="lblGvType" runat="server" Font-Size="30pt" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvAdminInbox" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SenderEmail" HeaderText="From" SortExpression="SenderEmail" />
                    <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                    <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" Visible="False">
                <Columns>
                    <asp:TemplateField HeaderText="ChkBox">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                    <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                    <asp:BoundField DataField="contactEmail" HeaderText="Recovery Email" SortExpression="contactEmail" />
                    <asp:BoundField DataField="phoneNumber" HeaderText="Phone" SortExpression="phoneNumber" />
                    <asp:BoundField DataField="streetname" HeaderText="Street Name" SortExpression="streetname" />
                    <asp:BoundField DataField="zipCode" HeaderText="Zip Code" SortExpression="zipCode" />
                    <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                    <asp:BoundField DataField="active" HeaderText="Acc Status" SortExpression="active" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
