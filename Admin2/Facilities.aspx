<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2/Admin.master" AutoEventWireup="true" CodeFile="Facilities.aspx.cs" Inherits="Admin2_Facilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="//tinymce.cachefly.net/4.2/tinymce.min.js"></script>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <table style="width: 100%; border-spacing: 0;">
        <tr>
            <td colspan="2">Edit Facilities</td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgOne" runat="server" Width="300" />
                <br />
                <input type="file" id="fupOne" runat="server" />
            </td>
            <td>
                <asp:Image ID="imgTwo" runat="server" Width="300" />
                <br />
                <input type="file" id="fupTwo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgThree" runat="server" Width="300" />
                <br />
                <input type="file" id="fupThree" runat="server" />
            </td>
            <td>
                <asp:Image ID="imgFour" runat="server" Width="300" />
                <br />
                <input type="file" id="fupFour" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txbFacText" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td colspan="2">
                <asp:TextBox ID="txbAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        tinymce.init({
            mode: "textareas"
        });
        function confirmSave() {
            return confirm("Save?");
        }
    </script>
</asp:Content>

