<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="emailFrameworkProject3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <style>
        img{
            height:50px;
            width: 50px;
        }
        body{
            background-color:wheat;
        }
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
    </style>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 id="lblHeader">Create Email</h1>
        <div>
            <asp:Label runat="server">Name: </asp:Label>
            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" Font-Bold="True" Font-Size="16pt">Address</asp:Label>
            <br />
            <br />
            <asp:Label runat="server">Street: </asp:Label>
            <asp:TextBox runat="server" ID="txtStreet"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">City: </asp:Label>
            <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">State: </asp:Label>
            <asp:TextBox runat="server" ID="txtState"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Zip Code: </asp:Label>
            <asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Phone Number: </asp:Label>
            <asp:TextBox runat="server" ID="txtPhoneNumber"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Email Username: </asp:Label>
            <asp:TextBox runat="server" ID="txtEmailUsername"></asp:TextBox>
            <asp:Label runat="server">@gmail.com</asp:Label>
            <br />
            <br />
            <asp:Label runat="server">Password: </asp:Label>
            <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Contact Email: </asp:Label>
            <asp:TextBox runat="server" ID="txtContactEmail"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">Select an Account Type </asp:Label>
            <asp:DropDownList runat="server" ID="ddlType">
                <asp:ListItem>Select Account Type</asp:ListItem>
                <asp:ListItem>User</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:RadioButton ID="radioImage" runat="server" GroupName="image" value="pic/blueAndGoldMacaw.jpeg" height="50px" Width="50px" /><img src="pic/blueAndGoldMacaw.jpeg" />
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="image" value="pic/budgie.jpeg" height="50px" Width="50px" /><img src="pic/budgie.jpeg" />
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="image" value="pic/cardinal.jpeg" height="50px" Width="50px" /><img src="pic/cardinal.jpeg" />
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="image" value="pic/cockatiel.jpeg" height="50px" Width="50px" /><img src="pic/cockatiel.jpeg" />
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="image" value="pic/hyacinthMacaw.jpeg" height="50px" Width="50px" /><img src="pic/hyacinthMacaw.jpeg" />
            <br />
            <asp:RadioButton ID="RadioButton5" runat="server" GroupName="image" value="pic/javaSparrow.jpeg" height="50px" Width="50px" /><img src="pic/javaSparrow.jpeg" />
            <asp:RadioButton ID="RadioButton6" runat="server" GroupName="image" value="pic/orangeBird.jpeg" height="50px" Width="50px" /><img src="pic/orangeBird.jpeg" />
            <asp:RadioButton ID="RadioButton7" runat="server" GroupName="image" value="pic/pigeon.jpeg" height="50px" Width="50px" /><img src="pic/pigeon.jpeg" />
            <asp:RadioButton ID="RadioButton8" runat="server" GroupName="image" value="pic/scarletMacaw.jpeg" height="50px" Width="50px" /><img src="pic/scarletMacaw.jpeg" />
            <asp:RadioButton ID="RadioButton9" runat="server" GroupName="image" value="pic/toucan.jpeg" height="50px" Width="50px" /><img src="pic/toucan.jpeg" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <div class="divider2"></div>
            <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
            <br />
            <br />

            
            
        </div>
    </form>
</body>
</html>
