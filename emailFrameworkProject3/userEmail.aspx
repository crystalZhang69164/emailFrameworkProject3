<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEmail.aspx.cs" Inherits="emailFrameworkProject3.userEmail" %>

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
        img{
            width: 100px;
        }
        body{
            background-color:wheat;
        }

    </style>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Bird Mail</h1>
            <br />
            <br />
            <br />
            <div class="leftMargin"></div>
            <asp:Button runat="server" Text="Flag" ID="btnFlag" OnClick="btnFlag_Click" />
            <div class="divider"></div>
            <asp:Button runat="server" Text="Create Email" ID="btnCreateEmail" OnClick="btnCreateEmail_Click"/>
            <div class =" divider"></div>
            <asp:Button runat="server" Text="Delete Email" ID="btnDeleteEmail" OnClick="btnDeleteEmail_Click" />
            <div class="divider2"></div>
            <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
            <div class="divider"></div>
            <asp:Button runat="server" Text="Search" ID="btnSearch" OnClick="btnSearch_Click"/>
            <div class="divider2"></div>
            <asp:DropDownList ID="ddlMoveTo" runat="server">
                    <asp:ListItem>Select Folder</asp:ListItem>
                    <asp:ListItem>Inbox</asp:ListItem>
                    <asp:ListItem>Trash</asp:ListItem>
                </asp:DropDownList>
            <div class="divider">
                
            </div>
            <asp:Button runat="server" Text="Move To" ID="btnMove" OnClick="btnMove_Click" />
            <div class="leftMargin"></div>
            <asp:Button ID="btnLogout" runat="server" Text="Log out" OnClick="btnLogout_Click" />


            <asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False">
                <Columns>
                    <asp:ImageField DataImageUrlField="avatar" HeaderText="Image">
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblFolderType" runat="server" Font-Size="18pt" style="z-index: 1; left: 177px; top: 203px; position: absolute; height: 26px; width: 75px" Text="Label" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnViewEmail" runat="server" OnClick="btnViewEmail_Click" Text="View Email" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button runat="server" Text="Inbox" ID="btnInbox" OnClick="btnInbox_Click"></asp:Button>
            <br />
            <br />
            <asp:Button runat="server" Text="Trash" ID="btnTrash" OnClick="btnTrash_Click"></asp:Button>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="gvInbox" runat="server" style="z-index: 1; left: 175px; top: 284px; position: absolute; height: 303px; width: 644px" AutoGenerateColumns="False" OnSelectedIndexChanged="gvInbox_SelectedIndexChanged" >
                <Columns>
                    <asp:TemplateField HeaderText="ChkBox">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SenderEmail" HeaderText="From" SortExpression="SenderEmail" />
                    <asp:BoundField DataField="Subject" HeaderText="Subject" />
                    <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
                    <asp:BoundField DataField="Date" HeaderText="Date Received" SortExpression="Date" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblFrom" runat="server" Text="From: " Visible="False"></asp:Label>
            <asp:TextBox ID="txtFrom" width="300px" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblTo" runat="server" Text="To: " Visible="False"></asp:Label>
            <asp:TextBox ID="txtTo" width="300px" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblSubject" runat="server" Text="Subject: " Visible="False"></asp:Label>
            <asp:TextBox ID="txtSubject" width="300px" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblContent" runat="server" Text="Content" Visible="False"></asp:Label>
            <br />
            <asp:TextBox TextMode="MultiLine" ID="txtContent" Rows="8" Width="500" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" Visible="False" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
