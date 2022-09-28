using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;

namespace Calibration
{
  public partial class email_auto : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string sql = @"
      SELECT d.code, d.name AS d_name, tr.code AS tr_code, t.name, 
      pc.name AS pc_name, t.model, n.*, ea.start_date,
      ea.rang_month, ea.status, ea.id AS ea_id
      FROM dbo.email_auto ea
      INNER JOIN dbo.department d
      ON d.id = ea.dep_id
      INNER JOIN dbo.tool_register tr
      ON tr.tool_id = ea.tool_id
      INNER JOIN dbo.tool t
      ON t.id = ea.tool_id
      INNER JOIN dbo.production_company pc
      ON pc.id = tr.produc_company_id
      INNER JOIN dbo.notification n
      ON n.department_id = ea.dep_id
      ";
      DataTable dt = Model.Database.SqlQuery(sql);
      RenderRowData(dt);
    }

    private void RenderRowData(DataTable dt)
    {
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        TableRowData.Text += $@"
        <tr>
          <td width=""1%""></td>
          <td class=""text-center"">{dt.Rows[i]["code"]} | {dt.Rows[i]["d_name"]}</td>
          <td class=""text-center"">{dt.Rows[i]["tr_code"]}</td>
          <td class=""text-center"">{dt.Rows[i]["name"]}</td>
          <td class=""text-center"">{dt.Rows[i]["pc_name"]}</td>
          <td class=""text-center"">{dt.Rows[i]["model"]}</td>
          <td class=""text-center"">{dt.Rows[i]["start_date"].ToString().Split(' ')[0]}</td>
          <td class=""text-center"">ทุก {dt.Rows[i]["rang_month"]} เดือน</td>
          <td class=""text-center {StatusColor(dt.Rows[i]["status"].ToString())}"">
          {StatusCheck(dt.Rows[i]["status"].ToString())}
          </td>
          <td class=""text-center"">
          {dt.Rows[i]["master_email"]},
          {dt.Rows[i]["second_email"]}
          </td>
          <td width=""10%"" class=""text-center"">
          <div class='btn-group' role='group'>
          <a href='#?id={dt.Rows[i]["ea_id"]}' class='btn btn-outline-primary'>แก้ไข</a>
          <button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('email_auto.aspx/Delete',{dt.Rows[i]["ea_id"]})\">ลบ</button>" +
          @"</div>
          </td>
        </tr>
        ";
      }
    }

    private string StatusCheck(string status)
    {
      if (status == "1")
      {
        return "เปิดใช้งาน";
      }
      else
      {
        return "ปิดใช้งาน";
      }
    }

    private string StatusColor(string status)
    {
      if (status == "1")
      {
        return "bg-success text-light";
      }
      return "bg-danger text-light";
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.email_auto", id);
      return cb;
    }
  }
}