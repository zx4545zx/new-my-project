using System;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI;

namespace Calibration
{
  public partial class cotton : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllCotton = Model.Database.SelectAll("dbo.cotton");
        TableRowData.Text = Shared.Render.CottonPage(AllCotton);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.cotton", id);
      return cb;
    }
  }
}