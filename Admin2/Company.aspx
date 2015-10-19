<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin2/Admin.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Admin2_Company" %>

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
    </style>
    <script src="//tinymce.cachefly.net/4.2/tinymce.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <%-- Show All Companies --%>
    <table style="width: 100%; border-spacing: 0;">
        <tr>
            <td style="width: 15%; vertical-align: top;">
                <asp:Repeater ID="rptEntities" runat="server">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "CompanyName") %>
                        <a href='<%# string.Format("Company.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "CompanyID")) %>'>
                            <img src="../Images/Admin/update%2016x16.png" />
                        </a>
                        <a href='<%# string.Format("Company.aspx?DID={0}", DataBinder.Eval(Container.DataItem, "CompanyID")) %>' onclick="return confirm('Are you sure you want to delete?')">
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
                            <td class="auto-style2">Company Name:</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txbName" runat="server" Width="496px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Company Logo:<br />
                                (250x250)</td>
                            <td class="auto-style5">
                                <asp:FileUpload ID="fupLogo" runat="server" Width="503px" />
                                <br />
                                <asp:Label ID="lblCurrentLogo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Company Banner:<br />
                                (2000x300)</td>
                            <td>
                                <asp:FileUpload ID="fupBanner" runat="server" Width="505px" />
                                <br />
                                <asp:Label ID="lblCurrentBanner" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Company Description:</td>
                            <td>
                                <asp:TextBox ID="txbCompanyText" runat="server" Height="83px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Accepting Work:</td>
                            <td>
                                <asp:CheckBox ID="chbAcceptWork" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Sales Pitch:</td>
                            <td>
                                <asp:TextBox ID="txbSalesPitch" runat="server" Height="83px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Company Website:</td>
                            <td>
                                <asp:TextBox ID="txbWebsite" runat="server" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Contact Email:</td>
                            <td>
                                <asp:TextBox ID="txbContactEmail" runat="server" Width="499px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="tinymce.triggerSave(false,true)" OnClick="btnSave_Click"/>
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
        function confirmSave()
        {
            return confirm("Save?");
        }
    </script>
</asp:Content>

