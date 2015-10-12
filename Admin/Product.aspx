<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Admin_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    </h1>
    <div style="width: 24%; float: left;">
        <p>
            Product elements
        </p>
        <table>
            <asp:Repeater ID="rptEntities" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-bottom: 1px solid gray;">
                            <%# DataBinder.Eval(Container.DataItem, "ProductName") %>
                            <a href='<%# string.Format("Product.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "ProductID")) %>'>
                                <img src="../Images/Admin/update%2016x16.png" />
                            </a>
                            <a href='<%# string.Format("Product.aspx?DID={0}", DataBinder.Eval(Container.DataItem, "ProductID")) %>' onclick="return confirm('Are you sure you want to delete?')">
                                <img src="../Images/Admin/delete_16x16.gif" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td>
                    <a href="Product.aspx?NewItem=true">__
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
                    <td>Product Name</td>
                    <td>
                        <asp:TextBox ID="txbName" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Product Description</td>
                    <td>
                        <asp:TextBox ID="txbDescription" runat="server" Width="500" Height="300" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Product Logo</td>
                    <td>
                        <asp:FileUpload ID="fupLogo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Product Visual Rep</td>
                    <td style="width: 500px;">
                        <asp:ScriptManager ID="smUpdater" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="udpRadioButtonList" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rbtnlImageOrYoutube" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnlImageOrYoutube_SelectedIndexChanged">
                                    <asp:ListItem Selected="False" Text="Image" Value="image"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="YouTube" Value="youtube"></asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <asp:FileUpload ID="fupImage" runat="server" Visible="false" />
                                <asp:TextBox ID="txbYoutube" runat="server" Visible="false" Width="500"></asp:TextBox>
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

