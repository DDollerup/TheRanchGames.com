<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="SPHeader">
        <h1>MEET THE TEAM</h1>
        <p>Our Magical Overlords</p>
        Here at the Ranch we try and keep a tight ship to make sure our enviroment stays competetive.<br />
        Therefore we need our team to be the best of the best, sadly they were all taken so we're stuck with these goofballs.
    </div>

    <asp:Repeater ID="rptTeam" runat="server">
        <ItemTemplate>
            <div class="TeamWrapper col-lg-3">
                <div class="TeamPortrait">
                    <img src='<%# string.Format("./Images/Team/{0}",DataBinder.Eval(Container.DataItem,"TeamImageURL")) %>' />
                </div>
                <h1><%#DataBinder.Eval(Container.DataItem,"TeamMemberName")%></h1>
                <%#DataBinder.Eval(Container.DataItem,"TeamMemberDescription")%>
                <%#DataBinder.Eval(Container.DataItem,"TeamMemberEmail")%>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

