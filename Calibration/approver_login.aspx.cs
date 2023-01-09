using System;
using System.Data;
using System.Web.UI;

namespace Calibration
{
  public partial class approver_login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      string sql = $@"
      SELECT a.*, d.id as dep_id
      FROM dbo.approver a
      inner join dbo.registrar r
      on r.approver_id = a.id
      inner join dbo.department d
      on d.id = r.department_id
      WHERE a.email = '{floatingInput.Value}'
      AND a.password = '{floatingPassword.Value}';
      ";
      DataTable dt = Model.Database.SqlQuery(sql);

      if (dt.Rows.Count > 0)
      {
        Session["username"] = dt.Rows[0]["name"];
        Session["role"] = dt.Rows[0]["id"];
        Session["dep_id"] = dt.Rows[0]["dep_id"];
        Response.Redirect("notification_approve.aspx");
      }
      else
      {
        Session.Clear();
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'กรุณาตรวจสอบ Email หรือ Password อีกครั้ง');", true);

      }
    }
  }
}