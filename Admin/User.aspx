<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Admin_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 186px;
        }

        .auto-style2 {
            width: 186px;
            height: 25px;
        }

        .auto-style3 {
            height: 25px;
        }

        .auto-style6 {
            width: 23%;
        }
    </style>
    <script src="//tinymce.cachefly.net/4.2/tinymce.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <%-- Show All Companies --%>
    <table style="width: 100%; border-spacing: 0;">
        <tr>
            <td style="vertical-align: top;" class="auto-style6">
                <asp:Repeater ID="rptEntities" runat="server">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "UserEmail") %>
                        <a href='<%# string.Format("User.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "UserID")) %>'>
                            <img src="../Images/Admin/update%2016x16.png" />
                        </a>
                        <a href='<%# string.Format("User.aspx?DID={0}", DataBinder.Eval(Container.DataItem, "UserID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                            <img src="../Images/Admin/delete_16x16.gif" />
                        </a>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <a href="User.aspx?NewItem=true">
                    <img src="../Images/Admin/add%2016x16.png" />
                </a>
            </td>
            <td style="width: 85%; vertical-align: top;">
                <div runat="server" id="ShowContent" hidden="hidden">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style2">User Email:</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txbEmail" runat="server" Width="496px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Password:</td>
                            <td>
                                <asp:TextBox ID="txbTempPassword" runat="server" Width="496px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">User Role:</td>
                            <td>
                                <asp:DropDownList ID="ddlUserRole" runat="server" Width="496px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Assigned Company:</td>
                            <td>
                                <asp:DropDownList ID="ddlAssignedCompany" runat="server" Width="496px">
                                </asp:DropDownList>
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

