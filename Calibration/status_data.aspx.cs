using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class status_data : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllData = Model.Database.SelectAll("dbo.data_status");
        TableRowData.Text = Shared.Render.DataStatusPage(AllData);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.data_status", id);
      return cb;
    }
  }
}