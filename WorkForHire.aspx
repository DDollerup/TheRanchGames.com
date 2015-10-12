<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="WorkForHire.aspx.cs" Inherits="WorkForHire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div id="SPHeader">
        <h1>COLLABORATION OPPORTUNITIES WITH THE RANCH</h1>
        <p>"Git 'er dun"</p>
    </div>

    <div class="container-fluid">
        <asp:Repeater ID="rptLookingForPartner" runat="server">
            <ItemTemplate>
                <div class="LFPContentWrapper row row-centered">
                    <a href='<%# string.Format("CompaniesIND.aspx?CompanyID={0}", DataBinder.Eval(Container.DataItem,"CompanyID")) %>'>
                        <div class="LFPContent col-lg-9">

                            <div class="LFPPortrait">
                                <img src='<%# string.Format("./Images/Company/{0}/{1}", DataBinder.Eval(Container.DataItem, "CompanyName"), DataBinder.Eval(Container.DataItem, "CompanyImageURL")) %>' />
                            </div>
                            <div class="LFPCompanyname">
                                <h1 class="NoPadding"><%# DataBinder.Eval(Container.DataItem,"CompanyName") %></h1>
                            </div>
                            <div class="LFPPitch">
                                <p>
                                    <%# DataBinder.Eval(Container.DataItem, "CompanySalesPitch") %>
                                </p>
                            </div>
                        </div>
                    </a>
                    <div class="LFPSocMediaWrap row NoPadding">
                        <!-- WEBSITE -->
                        <a href='<%# DataBinder.Eval(Container.DataItem, "CompanyWebsite") %>'>
                            <div class="LFPSocMedia">
                                <img src="Images/Layout/LFPSocMedia_web_small.png" />
                            </div>
                        </a>
                        <!-- CompanyEmail -->
                        <a href='<%# string.Format("mailto:{0}?Subject=Looking%20for%20Partner", DataBinder.Eval(Container.DataItem, "CompanyContactEmail")) %>' target="_top">
                            <div class="LFPSocMedia">
                                <img src="Images/Layout/LFPSocMedia_mail_small.png" />
                            </div>
                        </a>
                    </div>
                    <div class="LFPContentBorder"></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>

