<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2/Admin.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Admin2_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <%-- Show All Companies --%>
    <table style="width: 100%; border-spacing: 0;">
        <tr>
            <td style="width: 15%; vertical-align:top;">
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
            <td style="width: 85%; vertical-align:top;">
                <div runat="server" id="ShowCompany" hidden="hidden">
                    
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

