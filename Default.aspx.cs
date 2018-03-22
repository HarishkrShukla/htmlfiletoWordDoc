using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Net.Http.Headers;
using System.Text;
using System.Data;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindValue();
    }
    private void BindValue()
    {
        Document doc = new Document();
        string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DocTemp.html");
        HtmlString final = new HtmlString(doc.BindValue(fileName));
        GetDocumentofHtml(final, "test.doc");
    }
    private void GetDocumentofHtml(HtmlString RadEditor1, string fileName)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/msword";
        string strFileName = fileName; //"GenerateDocumentfgfgfg" + ".doc";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
        StringBuilder strHTMLContent = new StringBuilder();
        strHTMLContent.Append((RadEditor1));
        ////RadEditor1.Content is HTML Text I m taking it from editor.
        HttpContext.Current.Response.Write(strHTMLContent);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
    }

}