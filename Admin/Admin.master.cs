using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        else
        {
            User u = Session["user"] as User;
            if (u.UserRole == 1)
            {
                AdminPanel.Visible = true;
            }
            else
            {
                AdminPanel.Visible = false;
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect(@"~\Default.aspx");
    }
}
