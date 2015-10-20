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

    protected void Page_Load(object sender, EventArgs e)
    {
        facility = facilityFac.GetEntityByID(1);

        FillContent();
    }

    protected void FillContent()
    {
        imgOne.ImageUrl = @"~\Images\Facilities\" + facility.ImageOne;
        imgTwo.ImageUrl = @"~\Images\Facilities\" + facility.ImageTwo;
        imgThree.ImageUrl = @"~\Images\Facilities\" + facility.ImageThree;
        imgFour.ImageUrl = @"~\Images\Facilities\" + facility.ImageFour;

        txbFacText.Text = facility.Text;
        txbAddress.Text = facility.Address;
    }
}