using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class department : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllDep = Model.Database.SelectAll("dbo.department");
        TableRowData.Text = Shared.Render.DepartmentPage(AllDep);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.department", id);
      return cb;
    }
  }
}