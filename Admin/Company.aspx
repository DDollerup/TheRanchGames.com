<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Admin_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Edit Companies
    </h1>
    <div style="width: 24%; float: left;">
        <p>
            Company elements
        </p>
        <table>
            <asp:Repeater ID="rptEntities" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-bottom: 1px solid gray;">
                            <%# DataBinder.Eval(Container.DataItem, "CompanyName") %>
                            <a href='<%# string.Format("Company.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "CompanyID")) %>'>
                                <img src="../Images/Admin/update%2016x16.png" />
                            </a>
                            <a href='<%# string.Format("Company.aspx?DID={0}", DataBinder.Eval(Container.DataItem, "CompanyID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                                <img src="../Images/Admin/delete_16x16.gif" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td>
                    <a href="Company.aspx?NewItem=true">__
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
                <asp:ScriptManager ID="smUpdater" runat="server"></asp:ScriptManager>

                <tr>
                    <td>Accept Work
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpCheckbox" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="cbxAcceptWork" runat="server" OnCheckedChanged="cbxAcceptWork_CheckedChanged" AutoPostBack="true" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>Sales Pitch
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpSalesPitch" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txbSalesPitch" runat="server" Width="500" Height="300" TextMode="MultiLine"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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

