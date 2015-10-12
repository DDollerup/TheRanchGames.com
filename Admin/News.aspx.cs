using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_News : System.Web.UI.Page
{
    AutoFactory<News> newsFac = new AutoFactory<News>();
    News n;
    protected void Page_Load(object sender, EventArgs e)
    {
        rptNews.DataSource = newsFac.GetAllEntities();
        rptNews.DataBind();

        string query = Request.QueryString["NewsID"];
        if (!string.IsNullOrEmpty(query))
        {
            n = newsFac.GetEntityByID(Convert.ToInt32(query));
            Hide.Attributes["style"] = "visibility: visible;";

            if (!IsPostBack)
            {
                txbNewsTitle.Text = n.NewsTitle;
                lblImageURL.Text = n.ImageURL;
            }
            return;
        }
        query = Request.QueryString["NewItem"];
        if (query == "true")
        {
            Hide.Attributes["style"] = "visibility: visible;";
            return;
        }
        query = Request.QueryString["DNewsID"];
        int id = Convert.ToInt32(query);
        if (id != 0)
        {
            DeleteNews(id);
        }
    }

    protected void ddlSites_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = ddlSites.SelectedItem.Text;
        ddlSelected.Visible = (selectedValue == "Select" ? false : true);
        if (selectedValue != "Select")
        {
            switch (selectedValue)
            {
                case "Team":
                    {
                        AutoFactory<TeamMember> autoFac = new AutoFactory<TeamMember>();
                        ddlSelected.DataTextField = "TeamMemberName";
                        ddlSelected.DataValueField = "TeamMemberID";
                        ddlSelected.DataSource = autoFac.GetAllEntities();
                    }
                    break;
                case "Company":
                    {
                        AutoFactory<Company> autoFac = new AutoFactory<Company>();
                        ddlSelected.DataTextField = "CompanyName";
                        ddlSelected.DataValueField = "CompanyID";
                        ddlSelected.DataSource = autoFac.GetAllEntities();
                    }
                    break;
                case "Sponsor":
                    {
                        AutoFactory<Sponsor> autoFac = new AutoFactory<Sponsor>();
                        ddlSelected.Items.Add(new ListItem("Select", "0"));
                        ddlSelected.DataTextField = "Name";
                        ddlSelected.DataValueField = "SponsorID";
                        ddlSelected.DataSource = autoFac.GetAllEntities();
                    }
                    break;
                default:
                    break;
            }

            ddlSelected.DataBind();
            ddlSelected.Items.Insert(0, new ListItem("Select", "0"));

            lblLinkTo.Text = ddlSites.SelectedValue;
        }
    }

    protected void ddlSelected_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblLinkTo.Text += ddlSelected.SelectedValue;
        lblLinkTo.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["NewsID"]);
        if (id != 0)
        {
            UpdateNews(id);
        }
        else
        {
            SaveNews();
        }
        Response.Redirect("News.aspx");
    }

    private void UpdateNews(int id)
    {
        n.NewsID = id;
        if (ddlSites.SelectedItem.Text != "Select")
        {
            n.LinkTo = lblLinkTo.Text;
        }
        n.NewsTitle = txbNewsTitle.Text;
        if (fupImageURL.HasFile)
        {
            n.ImageURL = fupImageURL.FileName;
            string imagePath = string.Format(@"{0}Images\News\{1}", Server.MapPath("~"), fupImageURL.FileName);
            fupImageURL.SaveAs(imagePath);
        }
        newsFac.Update(n);
    }
    private void SaveNews()
    {
        News newNews = new News();
        newNews.LinkTo = lblLinkTo.Text;
        newNews.NewsTitle = txbNewsTitle.Text;
        if (fupImageURL.HasFile)
        {
            newNews.ImageURL = fupImageURL.FileName;
            string imagePath = string.Format(@"{0}Images\News\{1}", Server.MapPath("~"), fupImageURL.FileName);
            fupImageURL.SaveAs(imagePath);
        }
        newsFac.Add(newNews);
    }
    private void DeleteNews(int id)
    {
        newsFac.Delete(id);
        Response.Redirect("News.aspx");
    }
}