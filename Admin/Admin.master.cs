using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    User user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        user = Session["user"] as User;
        Session["user"] = user; // Refresh Session
        AutoFactory<Company> companyFac = new AutoFactory<Company>();
        Company assignedCompany = companyFac.GetEntityByID(user.CompanyID);
        lblUser.Text = string.Format("Welcome {0} - Rights as {1}", user.UserEmail, (user.UserRole == 1 ? "Admin" : "Moderator for " + assignedCompany.CompanyName));
        phAdmin.Visible = (user.UserRole == 1);
        phUser.Visible = (user.UserRole == 2);

        if (phUser.Visible)
        {
            lbtnCompany.Text = assignedCompany.CompanyName;
            lbtnCompany.PostBackUrl = "ShowCompany.aspx?ID=" + user.CompanyID;
        }
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("../default.aspx");
    }
}
