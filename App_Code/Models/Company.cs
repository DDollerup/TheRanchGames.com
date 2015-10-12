using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Company
/// </summary>
public class Company : AutoTable
{
    public int CompanyID { get; set; }
    public string CompanyName { get; set; }
    public string CompanyImageURL { get; set; }
    public string CompanyImageBannerURL { get; set; }
    public string CompanyDescription { get; set; }
    public bool CompanyAcceptWork { get; set; }
    public string CompanySalesPitch { get; set; }
    public string CompanyWebsite { get; set; }
    public string CompanyContactEmail { get; set; }
}