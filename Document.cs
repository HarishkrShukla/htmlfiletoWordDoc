using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Document
/// </summary>
public class Document
{
    string documentTemp = string.Empty;
    string logo = "https://xceedance.workline.hr/imgs/sub_logol.gif";
    public Document()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string BindValue(string htmlFilename)
    {
        DataSet dataSet = GetDataValue();
        string documentTemp1 = ReadHtmlFile(htmlFilename);
        documentTemp1 = this.ReplaceFromString(documentTemp1, dataSet);
        return documentTemp1;
    }
    private DataSet GetDataValue()
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection("Server=DESKTOP-SCKJSQT\\HARISH;Initial Catalog=Authenticationdb;Persist Security Info=False;User ID=sa;Password=xceedance@123; MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
        SqlCommand com = new SqlCommand("Select * from tblDocument; Select * from tblUser", con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(com);
        da.Fill(ds);
        return ds;
    }
    public string ReadHtmlFile(string path)
    {
        string[] documentTemplate = File.ReadAllLines(path);
        foreach (string item in documentTemplate)
        {
            documentTemp += item;
        }
        return documentTemp;
    }

    private string ReplaceFromString(string documentTemplate, DataSet dataSet)
    {
        if (dataSet.Tables.Count > 0)
        {
            string documentTemp1 = documentTemplate.Replace("{0}", dataSet.Tables[0].Rows[0]["Title"].ToString())
                .Replace("{1}", logo)
                 .Replace("{2}", dataSet.Tables[0].Rows[0]["Title"].ToString())
                 .Replace("{3}", dataSet.Tables[0].Rows[0]["BodyDescription"].ToString())
                 .Replace("{4}", dataSet.Tables[1].Rows[0]["UserName"].ToString())
                 .Replace("{5}", dataSet.Tables[1].Rows[0]["UserPassword"].ToString())
                 .Replace("{6}", dataSet.Tables[0].Rows[0]["BodyDescription"].ToString());
            documentTemplate = documentTemp1;
        }
        return documentTemplate;
    }


}