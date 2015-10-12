using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product : System.Web.UI.Page
{
    AutoFactory<Company> companyFac = new AutoFactory<Company>();
    AutoFactory<Product> productFac = new AutoFactory<Product>();
    User u;
    Product p;
    Company c;

    protected void Page_Load(object sender, EventArgs e)
    {
        u = Session["user"] as User;
        c = companyFac.GetEntityByID(u.CompanyID);
        lblTitle.Text = "Add Product - " + c.CompanyName;

        rptEntities.DataSource = productFac.GetAllEntities().FindAll(x => x.CompanyID == u.CompanyID);
        rptEntities.DataBind();

        string query = Request.QueryString["ID"];
        p = productFac.GetEntityByID(Convert.ToInt32(query));

        if (!string.IsNullOrEmpty(query))
        {
            Hide.Attributes["style"] = "visibility: visible;";

            if (!IsPostBack)
            {
                txbName.Text = p.ProductName;
                txbDescription.Text = p.ProductDescription;
                txbYoutube.Text = p.ProductVisualRep;
            }
            return;
        }
        query = Request.QueryString["NewItem"];
        if (query == "true")
        {
            Hide.Attributes["style"] = "visibility: visible;";
            return;
        }
        query = Request.QueryString["DID"];
        int id = Convert.ToInt32(query);
        if (id != 0)
        {
            Delete(id);
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = p.ProductID;

        if (id != 0)
        {
            Update(id);
        }
        else
        {
            Add();
        }
        Response.Redirect("Product.aspx");
    }

    private void Add()
    {
        Product newProduct = new Product();
        newProduct.ProductName = txbName.Text;
        newProduct.ProductDescription = txbDescription.Text;
        newProduct.CompanyID = c.CompanyID;

        if (fupLogo.HasFile)
        {
            if (!Directory.Exists(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), newProduct.ProductName)))
            {
                Directory.CreateDirectory(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), newProduct.ProductName));
            }

            fupLogo.SaveAs(string.Format(@"{0}Images\Product\{1}\{2}", MapPath("~"), newProduct.ProductName, fupLogo.FileName));
            newProduct.ProductImageURL = fupLogo.FileName;
        }

        switch (rbtnlImageOrYoutube.SelectedValue)
        {
            case "image":
                {
                    if (fupImage.HasFile)
                    {
                        if (!Directory.Exists(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), c.CompanyName)))
                        {
                            Directory.CreateDirectory(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), newProduct.ProductName));
                        }

                        fupImage.SaveAs(string.Format(@"{0}Images\Product\{1}\{2}", MapPath("~"), newProduct.ProductName, fupImage.FileName));
                        newProduct.ProductVisualRep = string.Format(@"{0}Images\Product\{1}\{2}", MapPath("~"), newProduct.ProductName, fupImage.FileName);
                    }
                }
                break;
            case "youtube":
                newProduct.ProductVisualRep = @"<iframe class='YTPlayer' type='text/html' width='800' height='450' src='" + txbYoutube.Text + "' frameborder='0' seamless='seamless' autohide='1'></iframe>";
                break;
            default:
                break;
        }

        productFac.Add(newProduct);
        Response.Redirect("Product.aspx");
    }

    private void Update(int id)
    {
        p.ProductName = txbName.Text;
        p.ProductDescription = txbDescription.Text;
        p.CompanyID = c.CompanyID;

        if (fupLogo.HasFile)
        {
            if (!Directory.Exists(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), p.ProductName)))
            {
                Directory.CreateDirectory(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), p.ProductName));
            }

            fupLogo.SaveAs(string.Format(@"{0}Images\Product\{1}\{2}", MapPath("~"), p.ProductName, fupLogo.FileName));
            p.ProductImageURL = fupLogo.FileName;
        }

        switch (rbtnlImageOrYoutube.SelectedValue)
        {
            case "image":
                {
                    if (fupImage.HasFile)
                    {
                        if (!Directory.Exists(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), c.CompanyName)))
                        {
                            Directory.CreateDirectory(string.Format(@"{0}Images\Product\{1}\", MapPath("~"), p.ProductName));
                        }

                        fupImage.SaveAs(string.Format(@"{0}Images\Product\{1}\{2}", MapPath("~"), p.ProductName, fupImage.FileName));
                        p.ProductVisualRep = string.Format(@"{0}Images\Product\{1}\{2}", MapPath("~"), p.ProductName, fupImage.FileName);
                    }
                }
                break;
            case "youtube":
                p.ProductVisualRep = @"<iframe class='YTPlayer' type='text/html' width='800' height='450' src='" + txbYoutube.Text + "' frameborder='0' seamless='seamless' autohide='1'></iframe>";
                break;
            default:
                break;
        }

        productFac.Update(p);
        Response.Redirect("Product.aspx");
    }


    private void Delete(int id)
    {
        productFac.Delete(id);
        Response.Redirect("Product.aspx");
    }

    protected void rbtnlImageOrYoutube_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (rbtnlImageOrYoutube.SelectedValue)
        {
            case "image":
                fupImage.Visible = true;
                txbYoutube.Visible = false;
                break;
            case "youtube":
                txbYoutube.Visible = true;
                fupImage.Visible = false;
                break;
            default:
                break;
        }
    }
}