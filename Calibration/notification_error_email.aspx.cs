using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;

namespace Calibration.ApprovePage
{
  public partial class notification_error_email : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["username"] == null)
      {
        Response.Redirect("approver_login.aspx");
      }

      if (!IsPostBack)
      {
        CallData(0);
      }
    }

    private void CallData(int status)
    {
      string dep_id = Session["dep_id"].ToString();
      if (dep_id == null) { return; }
      string sql = $@"
          SELECT enf.id, enf.code, n.master, n.second, enf.notifier,
          enf.detail, enf.detail_other, FORMAT(enf.approved_date , 'dd/MM/yyyy', 'en-us') AS approved_date
          FROM dbo.email_notification_error enf
          INNER JOIN dbo.notification n
          ON n.department_id = enf.dep_id
          WHERE enf.status = {status} AND enf.dep_id = {dep_id}
          ORDER BY id DESC;
        ";
      DataTable AllData = Model.Database.SqlQuery(sql);
      TableRowData.Text = "";
      TableRowData.Text = RenderData(AllData);
      ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "$('#example').DataTable({responsive: true});", true);
    }

    private string RenderData(DataTable dt)
    {
      string rows = string.Empty;
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        string EditBtn = $@"
          <button id=""Approve"" type=""button"" class=""btn btn-sm btn-success""
            onclick=""Approved('notification_error_email.aspx/Approved',{dt.Rows[i]["id"]})"">
            <i class=""bi bi-check-circle-fill""></i>
            แจ้งรับ
          </button>
          ";

        rows += $@"
        <tr>
        <td></td>
        <td class=""text-center text-nowrap"">{EditBtn}</td>
        <td class=""text-center text-nowrap"">{dt.Rows[i]["code"]}</td>
        <td class=""text-center text-nowrap"">{dt.Rows[i]["master"]}</td>
        <td class=""text-center text-nowrap"">{dt.Rows[i]["second"]}</td>
        <td class=""text-center text-nowrap"">{dt.Rows[i]["notifier"]}</td>
        <td class=""text-center text-nowrap"">{dt.Rows[i]["detail"]}</td>
        <td class=""text-center text-nowrap"">{dt.Rows[i]["detail_other"]}</td>
        <td class=""text-center text-nowrap"">{dt.Rows[i]["approved_date"]}</td>
        <td>
          <table class='table table-sm table-striped table-bordered nowrap'>
            <thead>
              <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">รหัสลงทะเบียน</th>
                <th scope=""col"">รหัส</th>
                <th scope=""col"">เครื่องมือ</th>
                <th scope=""col"">ผู้ผลิต</th>
                <th scope=""col"">ช่วงใช้งาน</th>
              </tr>
            </thead>
            <tbody>
              {RenderTool(dt.Rows[i]["id"].ToString())}
            </tbody>
          </table>
        </td>
        </tr>
        ";
      }
      return rows;
    }

    private string RenderTool(string id)
    {
      string render = "";
      DataTable dt = Model.Database.SqlQuery($@"
      SELECT tr.register_code, tr.code, t.name AS t_name, pc.name, tr.rang_error
      FROM dbo.email_noti_err_tool ent
      INNER JOIN dbo.tool t ON ent.tool_id = t.id
      INNER JOIN dbo.tool_register tr ON ent.tool_id = tr.tool_id
      INNER JOIN dbo.production_company pc ON tr.produc_company_id = pc.id
      WHERE ent.email_noti_err_id = {id};
      ");

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        render += $@"
          <tr>
            <th scope=""row"">{i + 1}</th>
            <td>{dt.Rows[i]["register_code"]}</td>
            <td>{dt.Rows[i]["code"]}</td>
            <td>{dt.Rows[i]["t_name"]}</td>
            <td>{dt.Rows[i]["name"]}</td>
            <td>{dt.Rows[i]["rang_error"]}</td>
          </tr>
        ";
      }
      return render;
    }

    [WebMethod]
    public static bool Approved(string data)
    {
      string id = data.Split(',')[0];
      string comment = data.Split(',')[1];
      string solution = data.Split(',')[2];

      bool cb = Model.Database.UpdateByID("dbo.email_notification_error",
        $"status=1,updated_at=getdate(),comment='{comment}',solution='{solution}'", id);
      return cb;
    }
  }
}