using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeamMember
/// </summary>
public class TeamMember : AutoTable
{
    public int TeamMemberID { get; set; }
    public string TeamMemberName { get; set; }
    public string TeamMemberDescription { get; set; }
    public string TeamMemberEmail { get; set; }
    public string TeamImageURL { get; set; }
    public int TeamMemberPriority { get; set; }
}