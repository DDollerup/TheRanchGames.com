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
        teamFac.Update(member);
        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}