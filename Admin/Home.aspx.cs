using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Home : System.Web.UI.Page
{
    AutoFactory<Home> homeFac = new AutoFactory<Home>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Home currentHome = homeFac.GetEntityByID(1);
            txbHomeText.Text = currentHome.HomeText;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Home newHome = new Home();
        newHome.HomeID = 1;
        newHome.HomeText = txbHomeText.Text;
        homeFac.Update(newHome);
    }
}