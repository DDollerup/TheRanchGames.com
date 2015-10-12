using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txbEmail.Text;
        string password = txbPassword.Text;
        AutoFactory<User> userFac = new AutoFactory<User>();
        User u = userFac.GetEntity(string.Format("SELECT * FROM tblUser WHERE fldUserEmail='{0}' AND fldUserPassword='{1}'", email, password));

        if (u == null || u.UserRole == 0)
        {
            lblErrorMessage.Text = "Wrong username or password";
        }
        else
        {
            Session["user"] = u;
            Response.Redirect("Default.aspx");
        }
    }
}