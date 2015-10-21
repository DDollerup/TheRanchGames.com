using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin2_Company : System.Web.UI.Page
{
    AutoFactory<Company> companyFac = new AutoFactory<Company>();
    Company comp;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = companyFac.GetAllEntities();
        rptEntities.DataBind();

        int id = Convert.ToInt32(Request.QueryString["ID"]);
        if (id != 0)
        {
            ShowCompany.Attributes.Remove("hidden");
            comp = companyFac.GetEntityByID(id);
            PopulateFields();
        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            ShowCompany.Attributes.Remove("hidden");
            comp = new Company();
        }
        else if (Convert.ToInt32(Request.QueryString["DID"]) > 0)
        {
            int deleteID = Convert.ToInt32(Request.QueryString["DID"]);

            companyFac.Delete(deleteID);

            var uri = new Uri(Request.Url.AbsoluteUri);
            string path = uri.GetLeftPart(UriPartial.Path);
            Response.Redirect(path);
        }
    }

    private void PopulateFields()
    {
        if (!IsPostBack)
        {
            txbName.Text = comp.CompanyName;
            lblCurrentLogo.Text = comp.CompanyImageURL;
            lblCurrentBanner.Text = comp.CompanyImageBannerURL;
            txbCompanyText.Text = comp.CompanyDescription;
            chbAcceptWork.Checked = comp.CompanyAcceptWork;
            txbSalesPitch.Text = comp.CompanySalesPitch;
            txbWebsite.Text = comp.CompanyWebsite;
            txbContactEmail.Text = comp.CompanyContactEmail;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Uploader uploader = new Uploader();

        comp.CompanyName = txbName.Text;
        if (fupLogo.PostedFile.ContentLength > 0)
        {
            comp.CompanyImageURL = uploader.UploadImage(fupLogo.PostedFile,
                                                        MapPath("~") + @"Images\Company\" +
                                                        comp.CompanyName + @"\",
                                                        250,
                                                        false);
        }
        if (fupBanner.PostedFile.ContentLength > 0)
        {
            comp.CompanyImageBannerURL = uploader.UploadImage(fupBanner.PostedFile,
                                                        MapPath("~") + @"Images\Company\" +
                                                        comp.CompanyName + @"\",
                                                        2000,
                                                        false);
        }
        comp.CompanyDescription = txbCompanyText.Text;
        comp.CompanyAcceptWork = chbAcceptWork.Checked;
        comp.CompanySalesPitch = txbSalesPitch.Text;
        comp.CompanyWebsite = txbWebsite.Text;
        comp.CompanyContactEmail = txbContactEmail.Text;

        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {
            companyFac.Update(comp);

        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            companyFac.Add(comp);
        }



        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}