using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_Home : System.Web.UI.Page
{
    AutoFactory<Home> homeFac = new AutoFactory<Home>();
  	Home home;
    protected void Page_Load(object sender, EventArgs e)
    {
        home = homeFac.GetEntityByID(1);
      	FillContent();
    }

	void FillContent()
    {
      if(!IsPostBack)
      {
        txbHome.Text = home.HomeText;
      }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        home.HomeText = txbHome.Text;
        homeFac.Update(home);
        Response.Redirect("Home.aspx");
    }
}