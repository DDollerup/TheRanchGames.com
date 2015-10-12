using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partners : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoFactory<Sponsor> spnFac = new AutoFactory<Sponsor>();

        rptSponsors.DataSource = spnFac.GetAllEntities();
        rptSponsors.DataBind();
    }
}