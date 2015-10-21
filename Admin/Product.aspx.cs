using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product : System.Web.UI.Page
{
    AutoFactory<Product> productFac = new AutoFactory<Product>();
    Product product;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = productFac.GetAllEntities();
        rptEntities.DataBind();

        int id = Convert.ToInt32(Request.QueryString["ID"]);
        if (id != 0)
        {
            ShowContent.Attributes.Remove("hidden");
            product = productFac.GetEntityByID(id);
            PopulateFields();

        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            ShowContent.Attributes.Remove("hidden");
            product = new Product();
        }
        else if (Convert.ToInt32(Request.QueryString["DID"]) > 0)
        {
            int deleteID = Convert.ToInt32(Request.QueryString["DID"]);

            productFac.Delete(deleteID);

            var uri = new Uri(Request.Url.AbsoluteUri);
            string path = uri.GetLeftPart(UriPartial.Path);
            Response.Redirect(path);
        }
    }

    void PopulateFields()
    {
        if (!IsPostBack)
        {
            txbName.Text = product.ProductName;
            imgLogo.ImageUrl = @"~/Images/Product/" + product.ProductName + @"/" + product.ProductImageURL;
            txbText.Text = product.ProductDescription;

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        product.ProductName = txbName.Text;
        product.ProductDescription = txbText.Text;
        if (fupLogo.PostedFile.ContentLength > 0)
        {

            product.ProductImageURL = new Uploader().UploadImage(fupLogo.PostedFile,
                                                                 MapPath("~") + @"Images\Product\" + product.ProductName + @"\",
                                                                 250,
                                                                 false);
        }

        switch (rblSelect.SelectedValue)
        {
            case "Image":
                if (fupImage.PostedFile.ContentLength > 0)
                {
                    string path = MapPath("~") + @"Images\Product\" + product.ProductName + @"\";
                    string image = "<img width='800' height='450' src='" + path +
                new Uploader().UploadImage(fupImage.PostedFile,
                                           path,
                                           800,
                                           false) +
                "' />";
                    product.ProductVisualRep = image;
                }
                break;
            case "Youtube":
                string youtubeLink = "<iframe class='YTPlayer' type='text / html' width='800' height='450'" +
                        "src='https://www.youtube.com/embed/" + txbYoutubeID.Text + "'" +
                        "frameborder='0' seamless='seamless' autohide='1' ></ iframe >";
                product.ProductVisualRep = youtubeLink;
                break;
            default:
                break;
        }

        product.CompanyID = (Session["user"] as User).CompanyID;

        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {
            productFac.Update(product);
        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            productFac.Add(product);
        }


        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }

    protected void rblSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = (sender as RadioButtonList).SelectedValue;

        switch (selectedValue)
        {
            case "Image":
                ShowImage.Visible = true;
                ShowYoutube.Visible = false;
                break;
            case "Youtube":
                ShowImage.Visible = false;
                ShowYoutube.Visible = true;
                break;
            default:
                break;
        }
    }
}