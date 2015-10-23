<%@ Page Title="Edit Home" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin2_Home" validateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="//tinymce.cachefly.net/4.2/tinymce.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <h1>Edit home text</h1>
    <asp:TextBox ID="txbHome" runat="server" Height="83px" TextMode="MultiLine" Width="500px"></asp:TextBox>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="saveText(); return confirmSave();" OnClick="btnSave_Click" />

    <script>
        tinymce.init({
            mode: "textareas"
        });
        function confirmSave() {
            return confirm("Save?");
        }

    </script>
</asp:Content>

