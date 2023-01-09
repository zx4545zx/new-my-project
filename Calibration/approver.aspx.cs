using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class approver : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllApprover = Model.Database.SelectAll("dbo.approver");
        TableRowData.Text = Shared.Render.ApproverPage(AllApprover);
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.approver", id);
      return cb;
    }
  }
}