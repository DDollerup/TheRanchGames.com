using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Company : System.Web.UI.Page
{
    AutoFactory<Company> companyFac = new AutoFactory<Company>();
    Company c;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = companyFac.GetAllEntities();
        rptEntities.DataBind();

        string query = Request.QueryString["ID"];
        c = companyFac.GetEntityByID(Convert.ToInt32(query));

        if (!string.IsNullOrEmpty(query))
        {
            Hide.Attributes["style"] = "visibility: visible;";

            if (!IsPostBack)
            {
                txbCompanyName.Text = c.CompanyName;
                imgLogo.ImageUrl = string.Format(@"~/Images/Company/{0}/{1}", c.CompanyName, c.CompanyImageURL);
                imgBanner.ImageUrl = string.Format(@"~/Images/Company/{0}/{1}", c.CompanyName, c.CompanyImageBannerURL);
                txbDescription.Text = c.CompanyDescription;
                txbWebsite.Text = c.CompanyWebsite;
                txbEmail.Text = c.CompanyContactEmail;
                cbxAcceptWork.Checked = c.CompanyAcceptWork;
                txbSalesPitch.Text = c.CompanySalesPitch;
                txbSalesPitch.Visible = (cbxAcceptWork.Checked ? true : false);
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
        cbxAcceptWork.Checked = true;
        txbSalesPitch.Visible = true;
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
        Response.Redirect("Company.aspx");
    }

    private void Add()
    {
        Company newCompany = new Company();

        newCompany.CompanyName = txbCompanyName.Text;
        newCompany.CompanyDescription = txbDescription.Text;
        newCompany.CompanyWebsite = txbWebsite.Text;
        newCompany.CompanyContactEmail = txbEmail.Text;
        newCompany.CompanyAcceptWork = cbxAcceptWork.Checked;
        newCompany.CompanySalesPitch = txbSalesPitch.Text;

        if (fupCompanyLogo.HasFile)
        {
            newCompany.CompanyImageURL = fupCompanyLogo.FileName;

            if (!Directory.Exists(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), newCompany.CompanyName)))
            {
                Directory.CreateDirectory(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), newCompany.CompanyName));
            }

            fupCompanyLogo.SaveAs(string.Format(@"{0}Images\Company\{1}\{2}", MapPath("~"), newCompany.CompanyName, fupCompanyLogo.FileName));
        }
        if (fupCompanyBanner.HasFile)
        {
            newCompany.CompanyImageBannerURL = fupCompanyBanner.FileName;

            if (!Directory.Exists(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), newCompany.CompanyName)))
            {
                Directory.CreateDirectory(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), newCompany.CompanyName));
            }

            fupCompanyBanner.SaveAs(string.Format(@"{0}Images\Company\{1}\{2}", MapPath("~"), newCompany.CompanyName, fupCompanyBanner.FileName));
        }

        companyFac.Add(newCompany);
        Response.Redirect("Company.aspx");
    }
    private void Update(int id)
    {
        c.CompanyName = txbCompanyName.Text;
        if (fupCompanyLogo.HasFile)
        {
            c.CompanyImageURL = fupCompanyLogo.FileName;

            if (!Directory.Exists(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), c.CompanyName)))
            {
                Directory.CreateDirectory(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), c.CompanyName));
            }

            fupCompanyLogo.SaveAs(string.Format(@"{0}Images\Company\{1}\{2}", MapPath("~"), c.CompanyName, fupCompanyLogo.FileName));
        }
        if (fupCompanyBanner.HasFile)
        {
            c.CompanyImageBannerURL = fupCompanyBanner.FileName;

            if (!Directory.Exists(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), c.CompanyName)))
            {
                Directory.CreateDirectory(string.Format(@"{0}Images\Company\{1}\", MapPath("~"), c.CompanyName));
            }

            fupCompanyBanner.SaveAs(string.Format(@"{0}Images\Company\{1}\{2}", MapPath("~"), c.CompanyName, fupCompanyBanner.FileName));
        }

        c.CompanyDescription = txbDescription.Text;
        c.CompanyWebsite = txbWebsite.Text;
        c.CompanyContactEmail = txbEmail.Text;
        c.CompanyAcceptWork = cbxAcceptWork.Checked;
        c.CompanySalesPitch = txbSalesPitch.Text;

        companyFac.Update(c);
        Response.Redirect("Company.aspx");
    }
    private void Delete(int id)
    {
        companyFac.Delete(id);
        Response.Redirect("Company.aspx");
    }

    protected void cbxAcceptWork_CheckedChanged(object sender, EventArgs e)
    {
        txbSalesPitch.Visible = cbxAcceptWork.Checked;
    }
}