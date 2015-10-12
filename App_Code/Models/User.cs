using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User : AutoTable
{
    public int UserID { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public int UserRole { get; set; }
    public int CompanyID { get; set; }
}