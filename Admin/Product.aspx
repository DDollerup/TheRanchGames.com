<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Admin_Product" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%-- Show All Companies --%>
    <table style="width: 100%; border-spacing: 0;">
        <tr>
            <td style="vertical-align: top;" class="auto-style6">
                <asp:Repeater ID="rptEntities" runat="server">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "ProductName") %>
                        <a href='<%# string.Format("Product.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "ProductID")) %>'>
                            <img src="../Images/Admin/update%2016x16.png" />
                        </a>
                        <a href='<%# string.Format("Product.aspx?DID={0}", DataBinder.Eval(Container.DataItem, "ProductID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                            <img src="../Images/Admin/delete_16x16.gif" />
                        </a>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <a href="Product.aspx?NewItem=true">
                    <img src="../Images/Admin/add%2016x16.png" />
                </a>
            </td>
            <td style="width: 85%; vertical-align: top;">
                <div runat="server" id="ShowContent" hidden="hidden">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style2">Product Name:</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txbName" runat="server" Width="496px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Product Logo:<br />
                                (250x250)</td>
                            <td class="auto-style5">
                                <input type="file" id="fupLogo" runat="server" />
                                <br />
                                <asp:Image ID="imgLogo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Product Description:</td>
                            <td>
                                <asp:TextBox ID="txbText" runat="server" Height="83px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Youtube or Image?</td>
                            <td>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList AutoPostBack="true" ID="rblSelect" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSelect_SelectedIndexChanged">
                                            <asp:ListItem>Youtube</asp:ListItem>
                                            <asp:ListItem>Image</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="ShowImage" Visible="false">
                                            <input type="file" id="fupImage" runat="server" />
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="ShowYoutube" Visible="false">
                                            <asp:TextBox ID="txbYoutubeID" runat="server"></asp:TextBox>
                                            (ONLY YOUTUBE VIDEO ID - E.g. www.youtube.com/watch?v=|iCkYw3cRwLo| < that part)
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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

