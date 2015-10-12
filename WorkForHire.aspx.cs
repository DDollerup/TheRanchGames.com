using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkForHire : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoFactory<Company> companyFac = new AutoFactory<Company>();

        rptLookingForPartner.DataSource = companyFac.GetAllEntities().FindAll(x => x.CompanyAcceptWork == true);
        rptLookingForPartner.DataBind();
    }
}