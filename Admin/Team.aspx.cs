using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_Team : System.Web.UI.Page
{
    AutoFactory<TeamMember> teamFac = new AutoFactory<TeamMember>();
    TeamMember member;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = teamFac.GetAllEntities();
        rptEntities.DataBind();

        int id = Convert.ToInt32(Request.QueryString["ID"]);
        if (id != 0)
        {
            ShowContent.Attributes.Remove("hidden");
            member = teamFac.GetEntityByID(id);
            PopulateFields();

        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            ShowContent.Attributes.Remove("hidden");
            member = new TeamMember();
        }
        else if (Convert.ToInt32(Request.QueryString["DID"]) > 0)
        {
            int deleteID = Convert.ToInt32(Request.QueryString["DID"]);

            teamFac.Delete(deleteID);

            var uri = new Uri(Request.Url.AbsoluteUri);
            string path = uri.GetLeftPart(UriPartial.Path);
            Response.Redirect(path);
        }
    }

    void PopulateFields()
    {
        if (!IsPostBack)
        {
            txbName.Text = member.TeamMemberName;
            imgPortrait.ImageUrl = @"~\Images\Team\" + member.TeamImageURL;
            txbDescription.Text = member.TeamMemberDescription;
            txbContactEmail.Text = member.TeamMemberEmail;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        member.TeamMemberName = txbName.Text;
        if (fupPortrait.PostedFile.ContentLength > 0)
        {
            Uploader uploader = new Uploader();
            member.TeamImageURL = uploader.UploadImage(fupPortrait.PostedFile,
                                                       MapPath("~") + @"Images\Team\",
                                                       250,
                                                       false);
        }
        member.TeamMemberDescription = txbDescription.Text;
        member.TeamMemberEmail = txbContactEmail.Text;

        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {
            teamFac.Update(member);
        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            teamFac.Add(member);
        }


        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}