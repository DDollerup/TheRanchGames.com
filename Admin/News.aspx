<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Admin_News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Edit News
    </h1>
    <div style="width: 24%; float: left;">
        <p>
            News elements
        </p>
        <table>
            <asp:Repeater ID="rptNews" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-bottom: 1px solid gray;">
                            <%# DataBinder.Eval(Container.DataItem, "NewsTitle") %>
                            <a href='<%# string.Format("News.aspx?NewsID={0}", DataBinder.Eval(Container.DataItem, "NewsID")) %>'>
                                <img src="../Images/Admin/update%2016x16.png" />
                            </a>
                            <a href='<%# string.Format("News.aspx?DNewsID={0}", DataBinder.Eval(Container.DataItem, "NewsID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                                <img src="../Images/Admin/delete_16x16.gif" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td>
                    <a href="News.aspx?NewItem=true">
                        __
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
                    <td>Title
                    </td>
                    <td>
                        <asp:TextBox ID="txbNewsTitle" runat="server" Height="22"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Link To
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSites" runat="server" Height="22" Width="175" OnSelectedIndexChanged="ddlSites_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Team" Value="Team.aspx?TeamMemberID="></asp:ListItem>
                            <asp:ListItem Text="Company" Value="CompaniesIND.aspx?CompanyID="></asp:ListItem>
                            <asp:ListItem Text="Sponsor" Value="Partners.aspx?PartnerID="></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:DropDownList ID="ddlSelected" runat="server" Height="22" Width="175" Visible="false" OnSelectedIndexChanged="ddlSelected_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblLinkTo" Visible="false" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Select Image
                    </td>
                    <td>
                        <asp:FileUpload ID="fupImageURL" runat="server" />
                        <br />
                        <asp:Label ID="lblImageURL" Visible="true" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure you want to update?')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

