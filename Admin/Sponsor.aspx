<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Sponsor.aspx.cs" Inherits="Admin_Sponsor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Edit Sponsors
    </h1>
    <div style="width: 24%; float: left;">
        <p>
            Sponsor elements
        </p>
        <table>
            <asp:Repeater ID="rptEntities" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-bottom: 1px solid gray;">
                            <%# DataBinder.Eval(Container.DataItem, "Name") %>
                            <a href='<%# string.Format("Sponsor.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "SponsorID")) %>'>
                                <img src="../Images/Admin/update%2016x16.png" />
                            </a>
                            <a href='<%# string.Format("Sponsor.aspx?DID={0}", DataBinder.Eval(Container.DataItem, "SponsorID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                                <img src="../Images/Admin/delete_16x16.gif" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td>
                    <a href="Sponsor.aspx?NewItem=true">__
                        <img src="../Images/Admin/add%2016x16.png" />
                        __
                    </a>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 75%; float: left;">
        <div id="Hide" runat="server" style="visibility: hidden;">
            <table>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txbName" runat="server" Width="500"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Logo</td>
                    <td>
                        <asp:FileUpload ID="fupLogo" runat="server" />
                        <br />
                        Current Logo
                        <br />
                        <asp:Image ID="imgLogo" runat="server" Height="100" />
                    </td>
                </tr>
                <tr>
                    <td>Website</td>
                    <td>
                        <asp:TextBox ID="txbWebsite" runat="server" Width="500"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="txbDescription" runat="server" Width="500" Height="300" TextMode="MultiLine"></asp:TextBox></td>
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

