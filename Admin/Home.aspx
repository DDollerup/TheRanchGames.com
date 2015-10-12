<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Edit Home
    </h1>
    <div>
        <asp:TextBox ID="txbHomeText" runat="server" Width="600px" Height="500px" TextMode="MultiLine">
        </asp:TextBox>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return confirm('Are you sure you want to update?')" />
    </div>

</asp:Content>

