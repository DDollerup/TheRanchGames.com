using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_User : System.Web.UI.Page
{
    AutoFactory<User> userFac = new AutoFactory<User>();
    User user;

    protected void Page_Load(object sender, EventArgs e)
    {
        rptEntities.DataSource = userFac.GetAllEntities();
        rptEntities.DataBind();

        int id = Convert.ToInt32(Request.QueryString["ID"]);
        if (id != 0)
        {
            ShowContent.Attributes.Remove("hidden");
            user = userFac.GetEntityByID(id);
            PopulateDropDownLists();
            PopulateFields();


        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            ShowContent.Attributes.Remove("hidden");
            PopulateDropDownLists();
            user = new User();
        }
        else if (Convert.ToInt32(Request.QueryString["DID"]) > 0)
        {
            int deleteID = Convert.ToInt32(Request.QueryString["DID"]);

            userFac.Delete(deleteID);

            var uri = new Uri(Request.Url.AbsoluteUri);
            string path = uri.GetLeftPart(UriPartial.Path);
            Response.Redirect(path);
        }
    }

    void PopulateDropDownLists()
    {
        if (!IsPostBack)
        {
            AutoFactory<UserRole> roleFac = new AutoFactory<UserRole>();
            ddlUserRole.DataSource = roleFac.GetAllEntities();
            ddlUserRole.DataTextField = "RoleName";
            ddlUserRole.DataValueField = "UserRoleID";
            ddlUserRole.DataBind();
            ddlUserRole.Items.Insert(0, "Select");
            AutoFactory<Company> companyFac = new AutoFactory<Company>();
            ddlAssignedCompany.DataSource = companyFac.GetAllEntities();
            ddlAssignedCompany.DataTextField = "CompanyName";
            ddlAssignedCompany.DataValueField = "CompanyID";
            ddlAssignedCompany.DataBind();
            ddlAssignedCompany.Items.Insert(0, "Select");
        }
    }

    void PopulateFields()
    {
        if (!IsPostBack)
        {
            txbEmail.Text = user.UserEmail;
            txbTempPassword.Text = user.UserPassword;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        user.UserEmail = txbEmail.Text;
        user.UserPassword = txbTempPassword.Text;
        user.UserRole = Convert.ToInt32(ddlUserRole.SelectedValue);
        user.CompanyID = Convert.ToInt32(ddlAssignedCompany.SelectedValue);


        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {
            userFac.Update(user);
        }
        else if (Request.QueryString["NewItem"] == "true")
        {
            userFac.Add(user);
        }


        string currentURL = Request.RawUrl;
        Response.Redirect(currentURL);
    }
}