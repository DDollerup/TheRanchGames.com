using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_Sponsor : System.Web.UI.Page
{
    AutoFactory<Sponsor> sponsorFac = new AutoFactory<Sponsor>();
    Sponsor sponsor;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = sponsorFac.GetAllEntities();
        rptEntities.DataBind();

        int id = Convert.ToInt32(Request.QueryString["ID"]);
        if (id != 0)
        {
            ShowContent.Attributes.Remove("hidden");
            sponsor = sponsorFac.GetEntityByID(id);
            PopulateFields();

        }
    }

    void PopulateFields()
    {
        if (!IsPostBack)
        {
            txbName.Text = sponsor.Name;
            imgLogo.ImageUrl = @"~\Images\Sponsor\" + sponsor.ImageURL;
            txbText.Text = sponsor.Text;
            txbLinkTo.Text = sponsor.LinkTo;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}