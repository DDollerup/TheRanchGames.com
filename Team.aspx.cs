using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Team : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoFactory<TeamMember> teamFac = new AutoFactory<TeamMember>();

        rptTeam.DataSource = teamFac.GetAllEntities();
        rptTeam.DataBind();
    }
}