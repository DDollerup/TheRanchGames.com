using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_News : System.Web.UI.Page
{
    AutoFactory<News> newsFac = new AutoFactory<News>();
    News news;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = newsFac.GetAllEntities();
        rptEntities.DataBind();

        int id = Convert.ToInt32(Request.QueryString["ID"]);
        if (id != 0)
        {
            ShowContent.Attributes.Remove("hidden");
            news = newsFac.GetEntityByID(id);
            PopulateFields();
        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            ShowContent.Attributes.Remove("hidden");
            news = new News();
        }
        else if (Convert.ToInt32(Request.QueryString["DID"]) > 0)
        {
            int deleteID = Convert.ToInt32(Request.QueryString["DID"]);

            newsFac.Delete(deleteID);

            var uri = new Uri(Request.Url.AbsoluteUri);
            string path = uri.GetLeftPart(UriPartial.Path);
            Response.Redirect(path);
        }
    }

    void PopulateFields()
    {
        if (!IsPostBack)
        {
            txbTitle.Text = news.NewsTitle;
            imgImage.ImageUrl = @"~\Images\Sponsor\" + news.ImageURL;
            txbLinkTo.Text = news.LinkTo;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        news.NewsTitle = txbTitle.Text;
        if (fupImage.PostedFile.ContentLength > 0)
        {
            news.ImageURL = new Uploader().UploadImage(fupImage.PostedFile,
                                                       MapPath("~") + @"Images\News\",
                                                       0,
                                                       false);

        }
        news.LinkTo = txbLinkTo.Text;

        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {
            newsFac.Update(news);
        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            newsFac.Add(news);
        }

        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}