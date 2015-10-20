using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin2_Facilities : System.Web.UI.Page
{
    AutoFactory<Facility> facilityFac = new AutoFactory<Facility>();
    Facility facility;
    private string facPath = @"~\Images\Facilities\";

    protected void Page_Load(object sender, EventArgs e)
    {
        facility = facilityFac.GetEntityByID(1);
        FillContent();
    }

    protected void FillContent()
    {
        imgOne.ImageUrl = facPath + facility.ImageOne;
        imgTwo.ImageUrl = facPath + facility.ImageTwo;
        imgThree.ImageUrl = facPath + facility.ImageThree;
        imgFour.ImageUrl = facPath + facility.ImageFour;

        txbFacText.Text = facility.Text;
        txbAddress.Text = facility.Address;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Uploader uploader = new Uploader();
        if (fupOne.PostedFile.ContentLength > 0)
        {
            facility.ImageOne = uploader.UploadImage(fupOne.PostedFile,
                                            MapPath("~") + @"Images\Facilities\",
                                            720,
                                            false);
        }

        if (fupTwo.PostedFile.ContentLength > 0)
        {
            facility.ImageTwo = uploader.UploadImage(fupTwo.PostedFile,
                                            MapPath("~") + @"Images\Facilities\",
                                            720,
                                            false);
        }

        if (fupThree.PostedFile.ContentLength > 0)
        {
            facility.ImageThree = uploader.UploadImage(fupThree.PostedFile,
                                            MapPath("~") + @"Images\Facilities\",
                                            720,
                                            false);
        }

        if (fupFour.PostedFile.ContentLength > 0)
        {
            facility.ImageFour = uploader.UploadImage(fupFour.PostedFile,
                                            MapPath("~") + @"Images\Facilities\",
                                            720,
                                            false);
        }

        facility.Text = txbFacText.Text;
        facility.Address = txbAddress.Text;
        facilityFac.Update(facility);
        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}