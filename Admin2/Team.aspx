<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2/Admin.master" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Admin2_Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 186px;
        }

        .auto-style2 {
            width: 186px;
            height: 26px;
        }

        .auto-style3 {
            height: 26px;
        }

        .auto-style4 {
            width: 186px;
            height: 42px;
        }

        .auto-style5 {
            height: 42px;
        }

        .auto-style6 {
            width: 23%;
        }
    </style>
    <script src="//tinymce.cachefly.net/4.2/tinymce.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <%-- Show All Team Members --%>
    <table style="width: 100%; border-spacing: 0;">
        <tr>
            <td style="vertical-align: top;" class="auto-style6">
                <asp:Repeater ID="rptEntities" runat="server">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "TeamMemberName") %>
                        <a href='<%# string.Format("Team.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "TeamMemberID")) %>'>
                            <img src="../Images/Admin/update%2016x16.png" />
                        </a>
                        <a href='<%# string.Format("Team.aspx?DID={0}", DataBinder.Eval(Container.DataItem, "TeamMemberID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                            <img src="../Images/Admin/delete_16x16.gif" />
                        </a>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td style="width: 85%; vertical-align: top;">
                <div runat="server" id="ShowCompany" hidden="hidden">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style2">Name</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txbName" runat="server" Width="496px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Portrait:<br />
                                (250x250)</td>
                            <td class="auto-style5">Portrait will be scaled on with to match 250 px
                                <br />
                                <input type="file" id="fupLogo" runat="server" />
                                <br />
                                Current Portrait:
                                <asp:Label ID="lblCurrentLogo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Description:</td>
                            <td>
                                <asp:TextBox ID="txbCompanyText" runat="server" Height="83px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Email:</td>
                            <td>
                                <asp:TextBox ID="txbContactEmail" runat="server" Width="499px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="tinymce.triggerSave(false,true)" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
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

