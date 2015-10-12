using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Facilities
/// </summary>
public class Facility : AutoTable
{
    public int FacilityID { get; set; }
    public string ImageOne { get; set; }
    public string ImageTwo { get; set; }
    public string ImageThree { get; set; }
    public string ImageFour { get; set; }
    public string Text { get; set; }
    public string Address { get; set; }
}