using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Facilities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoFactory<Facility> facilityFac = new AutoFactory<Facility>();

        Facility f = facilityFac.GetLatest("FacilityID", AutoFactory<Facility>.OrderBy.ASC);

        imgFacImage1.ImageUrl = string.Format("~/Images/Facilities/{0}", f.ImageOne);
        imgFacImage2.ImageUrl = string.Format("~/Images/Facilities/{0}", f.ImageTwo);
        imgFacImage3.ImageUrl = string.Format("~/Images/Facilities/{0}", f.ImageThree);
        imgFacImage4.ImageUrl = string.Format("~/Images/Facilities/{0}", f.ImageFour);

        litFacText.Text = f.Text;
        litFacAddress.Text = f.Address;
    }
}