using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompaniesOV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoFactory<Company> companyFac = new AutoFactory<Company>();

        List<Company> allCompanies = companyFac.GetAllEntities();

        rptCompanies.DataSource = allCompanies;
        rptCompanies.DataBind();
    }
}