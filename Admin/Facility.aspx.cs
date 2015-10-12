using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Facility : System.Web.UI.Page
{
    AutoFactory<Facility> facilityFac = new AutoFactory<Facility>();
    Facility f;

    protected void Page_Load(object sender, EventArgs e)
    {
        f = facilityFac.GetEntityByID(1);
        if (!IsPostBack)
        {
            imgOne.ImageUrl = string.Format(@"~\Images\Facilities\{0}", f.ImageOne);
            imgTwo.ImageUrl = string.Format(@"~\Images\Facilities\{0}", f.ImageTwo);
            imgThree.ImageUrl = string.Format(@"~\Images\Facilities\{0}", f.ImageThree);
            imgFour.ImageUrl = string.Format(@"~\Images\Facilities\{0}", f.ImageFour);
            txbDescription.Text = f.Text;
            txbAddress.Text = f.Address;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (fupImageOne.HasFile)
        {
            f.ImageOne = fupImageOne.FileName;
            fupImageOne.SaveAs(string.Format(@"{0}Images\Facilities\{1}", Server.MapPath("~"), fupImageOne.FileName));
        }
        if (fupImageTwo.HasFile)
        {
            f.ImageTwo = fupImageTwo.FileName;
            fupImageTwo.SaveAs(string.Format(@"{0}Images\Facilities\{1}", Server.MapPath("~"), fupImageTwo.FileName));
        }
        if (fupImageThree.HasFile)
        {
            f.ImageThree = fupImageThree.FileName;
            fupImageThree.SaveAs(string.Format(@"{0}Images\Facilities\{1}", Server.MapPath("~"), fupImageThree.FileName));
        }
        if (fupImageFour.HasFile)
        {
            f.ImageFour = fupImageFour.FileName;
            fupImageFour.SaveAs(string.Format(@"{0}Images\Facilities\{1}", Server.MapPath("~"), fupImageFour.FileName));
        }

        f.Text = txbDescription.Text;
        f.Address = txbAddress.Text;

        facilityFac.Update(f);
        Response.Redirect("Facility.aspx");
    }
}