using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class factory : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllFac = Model.Database.SelectAll("dbo.factory");
        TableRowData.Text = Shared.Render.FactoryPage(AllFac);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.factory", id);
      return cb;
    }
  }
}