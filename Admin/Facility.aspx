<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Facility.aspx.cs" Inherits="Admin_Facility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Edit Facility
    </h1>
    <div>
        <table>
            <tr>
                <td>Image One
                </td>
                <td>
                    <asp:FileUpload ID="fupImageOne" runat="server" />
                    <br />
                    Current Image
                    <br />
                    <asp:Image ID="imgOne" runat="server" Height="100" />
                </td>
            </tr>
            <tr>
                <td>Image Two
                </td>
                <td>
                    <asp:FileUpload ID="fupImageTwo" runat="server" />
                    <br />
                    Current Image
                    <br />
                    <asp:Image ID="imgTwo" runat="server" Height="100" />
                </td>
            </tr>
            <tr>
                <td>Image Three
                </td>
                <td>
                    <asp:FileUpload ID="fupImageThree" runat="server" />
                    <br />
                    Current Image
                    <br />
                    <asp:Image ID="imgThree" runat="server" Height="100" />
                </td>
            </tr>
            <tr>
                <td>Image Four
                </td>
                <td>
                    <asp:FileUpload ID="fupImageFour" runat="server" />
                    <br />
                    Current Image
                    <br />
                    <asp:Image ID="imgFour" runat="server" Height="100" />
                </td>
            </tr>
            <tr>
                <td>Facility Description
                </td>
                <td>
                    <asp:TextBox ID="txbDescription" runat="server" Width="500" Height="400" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Facility Address
                </td>
                <td>
                    <asp:TextBox ID="txbAddress" runat="server" Width="500"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

