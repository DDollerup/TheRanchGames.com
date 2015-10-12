<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ShowCompany.aspx.cs" Inherits="Admin_ShowCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 75%; float: left;">
        <div id="Hide" runat="server" style="visibility: hidden;">
            <table>
                <tr>
                    <td>Company Name
                    </td>
                    <td>
                        <asp:TextBox ID="txbCompanyName" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Company Logo
                    </td>
                    <td>
                        <asp:FileUpload ID="fupCompanyLogo" runat="server" />
                        <br />
                        Current Logo
                        <br />
                        <asp:Image ID="imgLogo" runat="server" Width="200" />
                    </td>
                </tr>
                <tr>
                    <td>Company Banner
                    </td>
                    <td>
                        <asp:FileUpload ID="fupCompanyBanner" runat="server" />
                        <br />
                        Current Banner
                        <br />
                        <asp:Image ID="imgBanner" runat="server" Width="200" />
                    </td>
                </tr>
                <tr>
                    <td>Description
                    </td>
                    <td>
                        <asp:TextBox ID="txbDescription" runat="server" Width="500" Height="300" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Contact
                    </td>
                    <td>
                        <asp:TextBox ID="txbContact" runat="server" Width="500" Height="300" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Website
                    </td>
                    <td>
                        <asp:TextBox ID="txbWebsite" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Contact Email
                    </td>
                    <td>
                        <asp:TextBox ID="txbEmail" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Accept Work
                    </td>
                    <td>
                        <asp:CheckBox ID="cbxAcceptWork" runat="server" OnCheckedChanged="cbxAcceptWork_CheckedChanged" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td>Sales Pitch
                    </td>
                    <td>
                        <asp:TextBox ID="txbSalesPitch" runat="server" Width="500" Height="300" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

