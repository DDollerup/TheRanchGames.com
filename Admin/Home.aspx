<%@ Page Title="Edit Home" Language="C#" MasterPageFile="~/Admin2/Admin.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin2_Home" validateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <h1>Edit home text</h1>
    <textarea id="input" name="input">
        <asp:Label ID="lblGet" runat="server" Text=""></asp:Label>
    </textarea>
    <div hidden="hidden">
        <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    </div>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="saveText(); return confirmSave();" OnClick="btnSave_Click" />

    <script>
        $(document).ready(function () {
            $('#input').cleditor();
            $('#input').text(($('#Content_lblText').val()));
        })

        function saveText() {
            $('#Content_lblText').text(($('#input').val()));
            $.post("home.aspx?action=save", { txt: $('#Content_lblText').text() }, function (data) { });
        }

        function confirmSave() {
            return confirm("Save?");
        }

    </script>
</asp:Content>

