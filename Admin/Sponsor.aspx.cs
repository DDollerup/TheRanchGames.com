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
        else if (Request.QueryString["NewItem"] == "true")
        {
            ShowContent.Attributes.Remove("hidden");
            sponsor = new Sponsor();
        }
        else if (Convert.ToInt32(Request.QueryString["DID"]) > 0)
        {
            int deleteID = Convert.ToInt32(Request.QueryString["DID"]);

            sponsorFac.Delete(deleteID);

            var uri = new Uri(Request.Url.AbsoluteUri);
            string path = uri.GetLeftPart(UriPartial.Path);
            Response.Redirect(path);
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
        sponsor.Name = txbName.Text;
        if (fupLogo.PostedFile.ContentLength > 0)
        {
            Uploader uploader = new Uploader();
            sponsor.ImageURL = uploader.UploadImage(fupLogo.PostedFile,
                                                   MapPath("~") + @"Images\Sponsor\",
                                                   0,
                                                   false);
        }
        sponsor.Text = txbText.Text;
        sponsor.LinkTo = txbLinkTo.Text;

        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {
            sponsorFac.Update(sponsor);

        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            sponsorFac.Add(sponsor);
        }

        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}