using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class production_company : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllData = Model.Database.SelectAll("dbo.production_company");
        TableRowData.Text = Shared.Render.ProductionCompanyPage(AllData);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.production_company", id);
      return cb;
    }
  }
}