using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class location : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllData = Model.Database.SelectAll("dbo.exam_location");
        TableRowData.Text = Shared.Render.LocationPage(AllData);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.exam_location", id);
      return cb;
    }
  }
}