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
      SELECT d.code, d.name AS d_name, ea.id AS ea_id, FORMAT(ea.start_date, 'dd/MM/yyyy', 'en-us') AS startDate, ea.*, n.*
      FROM dbo.email_auto ea
      INNER JOIN dbo.department d
      ON ea.dep_id = d.id
      INNER JOIN dbo.notification n
      ON ea.dep_id = n.department_id
      ORDER BY ea.id DESC;
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
          <td>{dt.Rows[i]["code"]} | {dt.Rows[i]["d_name"]}</td>
          <td class='text-center'>{dt.Rows[i]["startDate"]}</td>
          <td class='text-center'>ทุก {dt.Rows[i]["rang_month"]} เดือน</td>
          <td>{dt.Rows[i]["master_email"]},{dt.Rows[i]["second_email"]}</td>
          <td class='text-center {StatusColor(dt.Rows[i]["status"].ToString())}'>
          {StatusCheck(dt.Rows[i]["status"].ToString())}</td>
          <td width=""10%"" class=""text-center"">
            <div class='btn-group' role='group'>
            <a href='email_auto_update.aspx?id={dt.Rows[i]["ea_id"]}' class='btn btn-outline-primary'>แก้ไข</a>
            <button type='button' class='btn btn-danger' " +
            $"onclick=\"ConfirmDel('email_auto.aspx/Delete',{dt.Rows[i]["ea_id"]})\">ลบ</button>" +
            $@"</div>
          </td>
          <td>{RenderTable(dt.Rows[i]["ea_id"].ToString())}</td>
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

    private string RenderTable(string email_auto_id)
    {
      string rowsData = string.Empty;
      string sql = $@"
      SELECT tr.register_code, tr.code,
      t.name, pc.name AS pc_name, t.model
      FROM dbo.email_auto_tool eat
      INNER JOIN dbo.tool t
      ON t.id = eat.tool_id
      INNER JOIN dbo.tool_register tr
      ON tr.tool_id = t.id
      INNER JOIN dbo.production_company pc
      ON pc.id = tr.produc_company_id
      WHERE eat.email_auto_id = {email_auto_id};
      ";
      DataTable dt = Model.Database.SqlQuery(sql);
      rowsData += @"
      <table class=""table table-striped table-bordered nowrap"">
        <thead>
          <tr>
            <th class=""text-center"">เลขที่ใบทะเบียน</th>
            <th class=""text-center"">รหัส</th>
            <th class=""text-center"">ชื่อเครื่องมือ</th>
            <th class=""text-center"">บริษัทผู้ผลิต</th>
            <th class=""text-center"">รุ่น/พิกัด</th>
          </tr>
        </thead>
        <tbody>";
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        rowsData += $@"
            <tr>
              <td class=""text-center"">{dt.Rows[i]["register_code"]}</td>
              <td class=""text-center"">{dt.Rows[i]["code"]}</td>
              <td class=""text-center"">{dt.Rows[i]["name"]}</td>
              <td class=""text-center"">{dt.Rows[i]["pc_name"]}</td>
              <td class=""text-center"">{dt.Rows[i]["model"]}</td>
            </tr>";
      }
      rowsData += @"
        </tbody>
      </table>
      ";

      return rowsData;
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb1 = Model.Database.SqlQueryExecute($"DELETE FROM dbo.email_auto_tool WHERE email_auto_id = {id};");
      bool cb2 = Model.Database.DeleteByID("dbo.email_auto", id);
      if (cb1 && cb2)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}