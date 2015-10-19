using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            Session["Company"] = (comp = companyFac.GetEntityByID(id));
            PopulateFields();

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
        this.comp = Session["Company"] as Company;
        comp.CompanyName = txbName.Text;
        comp.CompanyImageURL = (FileUploadHelper.UploadFile(fupLogo, MapPath("~"),
                                FileUploadHelper.UploadTo.Company) == "NoFile" ? comp.CompanyImageURL : "asd");
        comp.CompanyDescription = txbCompanyText.Text;
        comp.CompanyAcceptWork = chbAcceptWork.Checked;
        comp.CompanySalesPitch = txbSalesPitch.Text;
        comp.CompanyWebsite = txbWebsite.Text;
        comp.CompanyContactEmail = txbContactEmail.Text;
        companyFac.Update(comp);
        Session["Company"] = null;
    }
}