<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Partners.aspx.cs" Inherits="Partners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="SPHeader">
        <h1>SPONSORS OF THE RANCH</h1>
        <p>
            Like, oh my gosh we just LOVE everyone in here<br />
            (haha)
        </p>
    </div>

    <div class="container">
        <div class="row row-centered">
            <asp:Repeater ID="rptSponsors" runat="server">
                <ItemTemplate>
                    <a href='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'>
                        <div class="PartnerWrapper col-md-6">
                            <div class="PartnerLogo">
                                <img src='<%# string.Format("./Images/Sponsor/{0}", DataBinder.Eval(Container.DataItem, "ImageURL")) %>' alt='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
                            </div>
                            <div class="PartnerDescrip">
                                <p>
                                    <%# DataBinder.Eval(Container.DataItem, "Text") %>
                                </p>
                            </div>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

