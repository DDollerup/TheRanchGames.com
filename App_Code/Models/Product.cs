using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product : AutoTable
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductImageURL { get; set; }
    public string ProductVisualRep { get; set; }
    public int CompanyID { get; set; }
    public bool UseImage { get; set; }
}