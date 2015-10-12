using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Sponsor : System.Web.UI.Page
{
    AutoFactory<Sponsor> sponsorFac = new AutoFactory<Sponsor>();
    Sponsor s;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = sponsorFac.GetAllEntities();
        rptEntities.DataBind();

        string query = Request.QueryString["ID"];
        s = sponsorFac.GetEntityByID(Convert.ToInt32(query));

        if (!string.IsNullOrEmpty(query))
        {
            Hide.Attributes["style"] = "visibility: visible;";

            if (!IsPostBack)
            {
                txbName.Text = s.Name;
                imgLogo.ImageUrl = @"~/Images/Sponsor/" + s.ImageURL;
                txbWebsite.Text = s.LinkTo;
                txbDescription.Text = s.Text;
            }
            return;
        }
        query = Request.QueryString["NewItem"];
        if (query == "true")
        {
            Hide.Attributes["style"] = "visibility: visible;";
            return;
        }
        query = Request.QueryString["DID"];
        int id = Convert.ToInt32(query);
        if (id != 0)
        {
            Delete(id);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        if (id != 0)
        {
            Update(id);
        }
        else
        {
            Add();
        }
        Response.Redirect("Sponsor.aspx");
    }

    private void Add()
    {
        Sponsor newSponsor = new Sponsor();

        newSponsor.Name = txbName.Text;
        if (fupLogo.HasFile)
        {
            newSponsor.ImageURL = fupLogo.FileName;
            string imagePath = string.Format(@"{0}Images\Sponsor\{1}", Server.MapPath("~"), fupLogo.FileName);
            fupLogo.SaveAs(imagePath);
        }

        newSponsor.LinkTo = txbWebsite.Text;
        newSponsor.Text = txbDescription.Text;

        sponsorFac.Add(newSponsor);
        Response.Redirect("Sponsor.aspx");
    }
    private void Update(int id)
    {
        s.Name = txbName.Text;
        if (fupLogo.HasFile)
        {
            s.ImageURL = fupLogo.FileName;
            string imagePath = string.Format(@"{0}Images\Sponsor\{1}", Server.MapPath("~"), fupLogo.FileName);
            fupLogo.SaveAs(imagePath);
        }

        s.LinkTo = txbWebsite.Text;
        s.Text = txbDescription.Text;

        sponsorFac.Update(s);
        Response.Redirect("Sponsor.aspx");
    }
    private void Delete(int id)
    {
        sponsorFac.Delete(id);
        Response.Redirect("Sponsor.aspx");
    }


}