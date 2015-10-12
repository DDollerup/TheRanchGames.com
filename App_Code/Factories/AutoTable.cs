using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

public class AutoTable
{
    public List<PropertyInfo> Properties = new List<PropertyInfo>();

    public AutoTable()
    {
        Properties.AddRange(GetType().GetProperties());
    }
}