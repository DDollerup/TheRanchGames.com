using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for News
/// </summary>
public class News : AutoTable
{
    public int NewsID { get; set; }
    public string ImageURL { get; set; }
    public string LinkTo { get; set; }
    public string NewsTitle { get; set; }
}