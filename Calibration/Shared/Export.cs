using ClosedXML.Excel;
using System.IO;
using System.Web;

namespace Calibration.Shared
{
  public class Export
  {
    public static void Excel(XLWorkbook wb, string FileName = "Export")
    {
      HttpContext.Current.Response.Clear();
      HttpContext.Current.Response.Buffer = true;
      HttpContext.Current.Response.Charset = "";
      HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      HttpContext.Current.Response.AddHeader("content-disposition", $"attachment;filename={FileName}.xlsx");
      Save(wb);
    }

    private static void Save(XLWorkbook wb)
    {
      using (MemoryStream MyMemoryStream = new MemoryStream())
      {
        wb.SaveAs(MyMemoryStream);
        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
      }
    }
  }
}