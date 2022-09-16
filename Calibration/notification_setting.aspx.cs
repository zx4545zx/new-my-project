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
  public partial class notification_setting : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllNoti = Model.Database.SelectInnerJoin(
          "*, dbo.department.id AS dep_id, dbo.department.code, dbo.department.name",
          "dbo.notification", "dbo.department",
          "dbo.notification.department_id=dbo.department.id"
          );
        TableRowData.Text = Shared.Render.NotiPage(AllNoti);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.notification", id);
      return cb;
    }
  }
}