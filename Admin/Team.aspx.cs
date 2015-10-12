using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Team : System.Web.UI.Page
{
    AutoFactory<TeamMember> teamFac = new AutoFactory<TeamMember>();
    TeamMember t;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptTeamMember.DataSource = teamFac.GetAllEntities().OrderBy(x => x.TeamMemberPriority);
        rptTeamMember.DataBind();

        string query = Request.QueryString["TeamMemberID"];
        if (!string.IsNullOrEmpty(query))
        {
            t = teamFac.GetEntityByID(Convert.ToInt32(query));
            Hide.Attributes["style"] = "visibility: visible;";

            if (!IsPostBack)
            {
                txbName.Text = t.TeamMemberName;
                txbDescription.Text = t.TeamMemberDescription;
                txbEmail.Text = t.TeamMemberEmail;
                txbPriority.Text = t.TeamMemberPriority.ToString();
            }
            return;
        }
        query = Request.QueryString["NewItem"];
        if (query == "true")
        {
            Hide.Attributes["style"] = "visibility: visible;";
            return;
        }
        query = Request.QueryString["DTeamMemberID"];
        int id = Convert.ToInt32(query);
        if (id != 0)
        {
            Delete(id);
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["TeamMemberID"]);
        if (id != 0)
        {
            Update(id);
        }
        else
        {
            Add();
        }
        Response.Redirect("Team.aspx");
    }

    private void Add()
    {
        TeamMember newTeamMember = new TeamMember();
        newTeamMember.TeamMemberName = txbName.Text;
        newTeamMember.TeamMemberDescription = txbDescription.Text;
        newTeamMember.TeamMemberEmail = txbEmail.Text;
        newTeamMember.TeamMemberPriority = Convert.ToInt32(txbPriority.Text);

        if (fupImageURL.HasFile)
        {
            newTeamMember.TeamImageURL = fupImageURL.FileName;
            string imagePath = string.Format(@"{0}Images\Team\{1}", Server.MapPath("~"), fupImageURL.FileName);
            fupImageURL.SaveAs(imagePath);
        }
        teamFac.Add(newTeamMember);
    }

    private void Update(int id)
    {
        t.TeamMemberID = id;
        t.TeamMemberName = txbName.Text;
        t.TeamMemberDescription = txbDescription.Text;
        t.TeamMemberEmail = txbEmail.Text;
        t.TeamMemberPriority = Convert.ToInt32(txbPriority.Text);

        if (fupImageURL.HasFile)
        {
            t.TeamImageURL = fupImageURL.FileName;
            string imagePath = string.Format(@"{0}Images\Team\{1}", Server.MapPath("~"), fupImageURL.FileName);
            fupImageURL.SaveAs(imagePath);
        }
        teamFac.Update(t);
    }
    private void Delete(int id)
    {
        teamFac.Delete(id);
        Response.Redirect("Team.aspx");
    }

}