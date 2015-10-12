<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="ResponsiveSlides/responsiveslides.js"></script>
    <link href="ResponsiveSlides/responsiveslides.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $(".rslides").responsiveSlides({
            });
        })
    </script>

    <title>The Ranch Game Incubator - Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FillWidth">
        <div class="container-fluid NoPadding">
            <div class="col-md-12 NoPadding SliderBackgroundImage">
                <ul class="rslides">
                    <asp:Repeater runat="server" ID="rptNewsSlider">
                        <ItemTemplate>
                            <li>
                                <a href='<%# string.Format("{0}", DataBinder.Eval(Container.DataItem,"LinkTo")) %>'>
                                    <img src='<%# string.Format("../Images/News/{0}", DataBinder.Eval(Container.DataItem, "ImageURL")) %>' class="CenterNewsImage" />
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>

    <div class="FillWidth">
        <div id="TeamWrapper">
            <div class="container">
                <div class="col-md-12">
                    <div id="HomeTextWrapper" class="Center15Padding">
                        <h1>What is The Ranch
                        </h1>
                        <p>
                            <asp:Literal ID="litHomeText" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="FillWidth">
        <div id="PartnerWrapper">
            <div class="container">
                <div class="col-md-12">
                    <div class="Center15Padding">
                        <h1>Companies of The Ranch</h1>
                        <asp:Repeater ID="rptRandom3Companies" runat="server">
                            <ItemTemplate>
                                <div class="CompaniesOVWrapper col-lg-4">
                                    <a href='<%# string.Format("CompaniesIND.aspx?CompanyID={0}", DataBinder.Eval(Container.DataItem,"CompanyID")) %>'>
                                        <div class="CompaniesOVPortrait">
                                            <div class="CompaniesOVPortraitImg">
                                                <img src='<%# string.Format("./Images/Company/{0}/{1}", DataBinder.Eval(Container.DataItem, "CompanyName"), DataBinder.Eval(Container.DataItem,"CompanyImageURL")) %>' />
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

