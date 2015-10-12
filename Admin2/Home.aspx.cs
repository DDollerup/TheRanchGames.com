using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_Home : System.Web.UI.Page
{
    AutoFactory<Home> homeFac = new AutoFactory<Home>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Home currentHome = homeFac.GetEntityByID(1);
        lblGet.Text = currentHome.HomeText;


        if (Request.QueryString["action"] == "save")
        {
            Session["lblText"] = Request.Form["txt"].ToString();
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        Home newHome = new Home();
        newHome.HomeID = 1;
        newHome.HomeText = Session["lblText"].ToString();
        homeFac.Update(newHome);
        Response.Redirect("Home.aspx");
    }
}