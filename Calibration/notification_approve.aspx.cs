using System;
using System.Data;
using System.Web.Services;

namespace Calibration.ApproverNotification
{
  public partial class notification_approve : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["username"] == null || Session["dep_id"] == null)
      {
                Session.Clear();
                Response.Redirect("approver_login.aspx");
      }

      if (!IsPostBack)
      {
        string dep_id = Session["dep_id"].ToString();
       // if (dep_id == null){ return; }
        string sql = $@"
          SELECT tr.id, tr.register_code, tr.code, 
          FORMAT(r.created_at, 'dd/MM/yyyy', 'en-us') AS created_at,r.name,d.name AS d_name,r.tel,r.email, tr.status
          FROM dbo.tool_register tr
          INNER JOIN dbo.registrar r ON tr.registrar_id = r.id
          INNER JOIN dbo.department d ON r.department_id = d.id
          WHERE tr.status = 1 
          ORDER BY id DESC;
        ";
        // AND r.department_id = {dep_id}
        DataTable AllData = Model.Database.SqlQuery(sql);
        Literal1.Text = Shared.Render.NotiApprovePage(AllData);
      }
    }

    [WebMethod]
    public static bool Approved(string id)
    {
      bool cb = Model.Database.UpdateByID("dbo.tool_register", "status=2", id);
      return cb;
    }
  }
}