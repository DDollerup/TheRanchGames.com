using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_Company : System.Web.UI.Page
{
    AutoFactory<Company> companyFac = new AutoFactory<Company>();
    Company c;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = companyFac.GetAllEntities();
        rptEntities.DataBind();

        int id = Convert.ToInt32(Request.QueryString["ID"]);

        if (id != 0)
        {
            ShowCompany.Attributes.Remove("hidden");
        }
    }
}