<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CompaniesOV.aspx.cs" Inherits="CompaniesOV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="SPHeader">
        <h1>COMPANIES OF THE RANCH</h1>
        <p>#LiterallyWho</p>
    </div>

    <asp:Repeater ID="rptCompanies" runat="server">
        <ItemTemplate>
            <div class="CompaniesOVPadding">
                <div class="CompaniesOVWrapper col-lg-3">
                    <a href='<%# string.Format("CompaniesIND.aspx?CompanyID={0}", DataBinder.Eval(Container.DataItem, "CompanyID")) %>'>
                        <div class="CompaniesOVPortrait">
                            <div class="CompaniesOVPortraitImg">
                                <img src='<%# string.Format("./Images/Company/{0}/{1}", DataBinder.Eval(Container.DataItem,"CompanyName"), DataBinder.Eval(Container.DataItem,"CompanyImageURL")) %>' />
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

