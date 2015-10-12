<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Ranch Games - Admin</title>
    <link href="../CSS/Main.css" rel="stylesheet" />
    <style>
        #LoginWrapper {
            margin: 0;
            width: 100%;
            height: 100%;
        }

        #LoginHolderWrapper {
            margin-left: auto;
            margin-right: auto;
            width: 600px;
            height: 400px;
            margin-top: 200px;
            background-color: #183171;
        }

        #LoginHeader {
            padding: 15px;
            border-bottom: 1px solid black;
            font-size: 35px;
        }

        #LoginContent {
            padding: 15px;
        }

        .Left20 {
            text-align: center;
            vertical-align: middle;
            line-height: 100px;
            float: left;
            width: 20%;
            height: 100px;
        }

        .Left80 {
            vertical-align: middle;
            line-height: 100px;
            float: left;
            width: 79%;
            height: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="LoginWrapper">
            <div id="LoginHolderWrapper">
                <div id="LoginHeader">
                    Login
                </div>
                <div id="LoginContent">
                    <div class="Left20">
                        Email
                    </div>
                    <div class="Left80">
                        <asp:TextBox ID="txbEmail" runat="server" Width="350px" Height="32px" Font-Size="XX-Large" TabIndex="0"></asp:TextBox>
                    </div>
                    <div class="Left20">
                        Password
                    </div>
                    <div class="Left80">
                        <asp:TextBox ID="txbPassword" runat="server" Width="350px" Height="32px" Font-Size="XX-Large" TabIndex="1" TextMode="Password"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 100%; height: 75px; padding-left: 115px;">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" Height="32px" Width="100px" OnClick="btnLogin_Click" TabIndex="2" />
                    </div>
                    <div style="float: left; width: 100%; height: 75px;">
                        <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
