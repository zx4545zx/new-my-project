using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class calibate_unit : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable All = Model.Database.SelectAll("dbo.calibration_unit");
        TableRowData.Text = Shared.Render.CalibateUnitPage(All);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.calibration_unit", id);
      return cb;
    }
  }
}