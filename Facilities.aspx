<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Facilities.aspx.cs" Inherits="Facilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="SPHeader">
        <h1>THE RANCH FACILITIES</h1>
        <p>Look at all the neat stuff we have!</p>
    </div>

    <div class="row-centered">
        <div class="FacilitiesImages col-md-5 col-centered">
            <asp:Image ID="imgFacImage1" runat="server" Width="" />
        </div>

        <div class="FacilitiesImages col-md-5 col-centered">
            <asp:Image ID="imgFacImage2" runat="server" />
        </div>
    </div>

    <div class="row-centered">
        <div class="FacilitiesImages col-md-5 col-centered">
            <asp:Image ID="imgFacImage3" runat="server" />
        </div>

        <div class="FacilitiesImages col-md-5 col-centered">
            <asp:Image ID="imgFacImage4" runat="server" />
        </div>
    </div>


    <div id="FacilitiesDescrip">
        <h1>Where the magic happens
        </h1>
        <p>
            <asp:Literal ID="litFacText" runat="server"></asp:Literal>
        </p>
        <h1>Find Us here</h1>
        <h2>
            <asp:Literal ID="litFacAddress" runat="server"></asp:Literal>
        </h2>
<%--        <div id="FacilitiesMap">
            <img src="http://fillmurray.com/1000/600" />
        </div>--%>
    </div>





</asp:Content>

