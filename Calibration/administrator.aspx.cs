using System;
using System.Data;
using System.Web.Services;

namespace Calibration.administrator
{
  public partial class Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["username"] == null)
      {
        Response.Redirect("Default.aspx");
      }
      if (!IsPostBack)
      {
        TableRowData.Visible = false;
        DataTable AllData = Model.Database.SqlQuery(
          @"
            SELECT t.id, t.register_code, t.code, t.status, r.created_at, r.name, d.code AS depCode, 
            d.name AS depName, r.tel, r.email,FORMAT(p.date_plan, 'yyyy/MM/dd', 'en-us') AS date_plan, p.rang, p.rang_unit
            FROM dbo.tool_register t
            INNER JOIN dbo.registrar r ON t.registrar_id = r.id
            INNER JOIN dbo.calibration_plan p ON t.calibration_plan_id = p.id
            INNER JOIN dbo.department d ON r.department_id = d.id
            ORDER BY t.id DESC;
          "
          );
        TableRowData.Text = Shared.Render.AdministratorPage(AllData);
        TableRowData.Visible = true;
      }
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      int tool_id = Model.Database.SqlReturnID($"SELECT tool_id FROM dbo.tool_register WHERE id = {id};");

      //EmailNoti(tool_id);
      //EmailDefNoti(tool_id);
      //EmailErrNoti(tool_id);
      //EmailAuto(tool_id);
      CalibrateResult(id);

      bool cb1 = Model.Database.SqlQueryExecute($@"
      DELETE FROM dbo.email_noti_tool WHERE tool_id = {tool_id};
      ");
      bool cb2 = Model.Database.SqlQueryExecute($@"
      DELETE FROM dbo.email_noti_def_tool WHERE tool_id = {tool_id};
      ");
      bool cb3 = Model.Database.SqlQueryExecute($@"
      DELETE FROM dbo.email_noti_err_tool WHERE tool_id = {tool_id};
      ");
      bool cb4 = Model.Database.SqlQueryExecute($@"
      DELETE FROM dbo.email_auto_tool WHERE tool_id = {tool_id};
      ");
      bool cb5 = Model.Database.SqlQueryExecute($@"
      DELETE FROM dbo.tool_register_calibration_results WHERE tool_register_id = {id};
      ");

      if (cb1 && cb2 && cb3 && cb4 && cb5)
      {
        DataTable tr = Model.Database.SelectAttributeByID(
          "registrar_id,certificate_id,calibration_plan_id,tool_id", "dbo.tool_register", id);

        bool tr_cb = Model.Database.DeleteByID("dbo.tool_register", id);
        bool r_cb = Model.Database.DeleteByID("dbo.registrar", tr.Rows[0]["registrar_id"].ToString());
        bool c_cb = Model.Database.DeleteByID("dbo.certificate", tr.Rows[0]["certificate_id"].ToString());
        bool cp_cb = Model.Database.DeleteByID("dbo.calibration_plan", tr.Rows[0]["calibration_plan_id"].ToString());
        bool t_cb = Model.Database.DeleteByID("dbo.tool", tr.Rows[0]["tool_id"].ToString());

        if (r_cb && c_cb && cp_cb && t_cb && tr_cb) { return true; }
        else { return false; }
      }
      else
      {
        return false;
      }
    }

    private static void EmailNoti(int tool_id)
    {
      DataTable email_noti_id = Model.Database.SqlQuery(
        $"SELECT email_noti_id FROM dbo.email_noti_tool WHERE tool_id = {tool_id};");

      for (int i = 0; i < email_noti_id.Rows.Count; i++)
      {
        Model.Database.DeleteByID("dbo.email_notification", email_noti_id.Rows[i]["email_noti_id"].ToString());
      }
    }

    private static void EmailDefNoti(int tool_id)
    {
      DataTable email_noti_def_id = Model.Database.SqlQuery(
        $"SELECT email_noti_def_id FROM dbo.email_noti_def_tool WHERE tool_id = {tool_id};");

      for (int i = 0; i < email_noti_def_id.Rows.Count; i++)
      {
        Model.Database.DeleteByID("dbo.email_notification_defective", email_noti_def_id.Rows[i]["email_noti_def_id"].ToString());
      }
    }

    private static void EmailErrNoti(int tool_id)
    {
      DataTable email_noti_err_id = Model.Database.SqlQuery(
        $"SELECT email_noti_err_id FROM dbo.email_noti_err_tool WHERE tool_id = {tool_id};");

      for (int i = 0; i < email_noti_err_id.Rows.Count; i++)
      {
        Model.Database.DeleteByID("dbo.email_notification_error", email_noti_err_id.Rows[i]["email_noti_err_id"].ToString());
      }
    }

    private static void EmailAuto(int tool_id)
    {
      DataTable email_auto_id = Model.Database.SqlQuery(
        $"SELECT email_auto_id FROM dbo.email_auto_tool WHERE tool_id = {tool_id};");

      for (int i = 0; i < email_auto_id.Rows.Count; i++)
      {
        Model.Database.DeleteByID("dbo.email_auto", email_auto_id.Rows[i]["email_auto_id"].ToString());
      }
    }

    private static void CalibrateResult(string id)
    {
      DataTable calibration_results_id = Model.Database.SqlQuery(
        $"SELECT calibration_results_id FROM dbo.tool_register_calibration_results WHERE tool_register_id = {id};");

      for (int i = 0; i < calibration_results_id.Rows.Count; i++)
      {
        Model.Database.DeleteByID("dbo.calibration_results", calibration_results_id.Rows[i]["calibration_results_id"].ToString());
      }
    }
  }
}