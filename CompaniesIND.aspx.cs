using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompaniesIND : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int companyID = Convert.ToInt32(Request.QueryString["CompanyID"]);
        if (companyID < 1)
        {
            Response.Redirect("ErrorSite.aspx");
            return;
        }

        AutoFactory<Company> companyFac = new AutoFactory<Company>();
        Company c = companyFac.GetEntityByID(companyID);
        CompaniesINDHeader.Style.Add("background-image", string.Format("./Images/Company/{0}/{1}", c.CompanyName, c.CompanyImageBannerURL));
        imgCompanyImageURL.ImageUrl = string.Format("./Images/Company/{0}/{1}", c.CompanyName, c.CompanyImageURL);
        lblCompanyName.Text = c.CompanyName;
        lblCompanyDescription.Text = c.CompanyDescription.Replace("\n", "<br />");

        AutoFactory<Product> productFac = new AutoFactory<Product>();
        List<Product> companyProducts = new List<Product>(productFac.GetAllEntities().FindAll(x => x.CompanyID == c.CompanyID));
        rptOurProducts.DataSource = companyProducts;
        rptOurProducts.DataBind();

    }
}