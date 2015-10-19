using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for FileUpload
/// </summary>
public class FileUploadHelper
{
    public enum UploadTo { Company, Product }

    public static string UploadFile(FileUpload uploader, string path, out string fileName)
    {
        fileName = "";
        if (uploader.HasFile)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += @"\" + uploader.FileName;
            uploader.SaveAs(path);
            fileName = uploader.FileName;
            //uploader.SaveAs(string.Format(@"{0}Images\{1}\{2}\{3}", MapPath("~"), newCompany.CompanyName, fupCompanyLogo.FileName));
        }
    }
}