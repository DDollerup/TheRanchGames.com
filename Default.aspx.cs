using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoFactory<News> newsFac = new AutoFactory<News>();
        AutoFactory<Home> homeFac = new AutoFactory<Home>();
        AutoFactory<Company> companyFac = new AutoFactory<Company>();

        List<News> allNews = newsFac.GetAllEntities();
        rptNewsSlider.DataSource = allNews;
        rptNewsSlider.DataBind();

        Home h = homeFac.GetEntityByID(1);
        litHomeText.Text = h.HomeText;

        List<Company> allCompanies = companyFac.GetAllEntities();
        Random rnd = new Random();
        rptRandom3Companies.DataSource = allCompanies.OrderBy(x => rnd.Next()).Take(3);
        rptRandom3Companies.DataBind();
    }
}