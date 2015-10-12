using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Sponsor
/// </summary>
public class Sponsor : AutoTable
{
    public int SponsorID { get; set; }
    public string Name { get; set; }
    public string ImageURL { get; set; }
    public string LinkTo { get; set; }
    public string Text { get; set; }
}