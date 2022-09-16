using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class iso : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllCotton = Model.Database.SelectAll("dbo.iso");
        TableRowData.Text = Shared.Render.ISOPage(AllCotton);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.iso", id);
      return cb;
    }
  }
}