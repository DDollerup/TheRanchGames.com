<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CompaniesIND.aspx.cs" Inherits="CompaniesIND" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="CompaniesINDHeader" runat="server">
        <div class="CompHeadEmptySpace"></div>
        <div id="CompaniesINDLogo">
            <asp:Image ID="imgCompanyImageURL" runat="server" />
        </div>
    </div>

    <div id="CompaniesINDAbout">
        <h1>
            <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label></h1>
        <h2>Who we are and what we do</h2>
        <div class="CompHeadEmptySpace"></div>
        <p>
            <asp:Label ID="lblCompanyDescription" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <div class="CompaniesINDProductContentBg">
        <asp:Repeater ID="rptOurProducts" runat="server">
            <HeaderTemplate>
                <div class="CompaniesINDProductContentHead">
                    <h1>Our Products</h1>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="CompaniesINDProductContentWrap">
                    <div class="CompaniesINDProductionBorder"></div>
                    <div class="CompProEmptySpace">
                        <div class="CompaniesINDProductGameTitle">
                            <%# DataBinder.Eval(Container.DataItem, "ProductName") %>
                        </div>
                    </div>
                    <div class="CompaniesINDProductDescript">
                        <div class="CompaniesINDProductGameLogo">
                            <img src='<%# string.Format("./Images/Product/{0}/{1}", DataBinder.Eval(Container.DataItem, "ProductName"), DataBinder.Eval(Container.DataItem, "ProductImageURL")) %>' />
                        </div>
                            <%# DataBinder.Eval(Container.DataItem, "ProductDescription") %>
                        <div class="YTPlayerAspectFix">
                            <%# DataBinder.Eval(Container.DataItem, "ProductVisualRep") %>
                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>

