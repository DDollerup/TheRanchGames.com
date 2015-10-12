<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Admin_Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Edit Team Members
    </h1>
    <div style="width: 24%; float: left;">
        <p>
            News elements - Sorted by priority
        </p>
        <table>
            <asp:Repeater ID="rptTeamMember" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-bottom: 1px solid gray;">
                            <%# DataBinder.Eval(Container.DataItem, "TeamMemberName") %>
                            <a href='<%# string.Format("Team.aspx?TeamMemberID={0}", DataBinder.Eval(Container.DataItem, "TeamMemberID")) %>'>
                                <img src="../Images/Admin/update%2016x16.png" />
                            </a>
                            <a href='<%# string.Format("Team.aspx?DTeamMemberID={0}", DataBinder.Eval(Container.DataItem, "TeamMemberID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                                <img src="../Images/Admin/delete_16x16.gif" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td>
                    <a href="Team.aspx?NewItem=true">__
                        <img src="../Images/Admin/add%2016x16.png" />
                        __
                    </a>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 75%; float: left;">
        <div id="Hide" runat="server" style="visibility: hidden;">
            <table style="font-size: 22px; vertical-align: text-top;">
                <tr>
                    <td>Name
                    </td>
                    <td>
                        <asp:TextBox ID="txbName" runat="server" Width="600"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Description
                    </td>
                    <td>
                        <asp:TextBox ID="txbDescription" runat="server" TextMode="MultiLine" Height="500" Width="600"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email
                    </td>
                    <td>
                        <asp:TextBox ID="txbEmail" runat="server" Width="600"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Image
                    </td>
                    <td>
                        <asp:FileUpload ID="fupImageURL" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Member Priority
                    </td>
                    <td>
                        <asp:TextBox ID="txbPriority" runat="server" TextMode="Number"></asp:TextBox>
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

