using System;
using System.Data;
using System.Web.UI;

namespace Calibration
{
  public partial class notification_defective_page : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable dt = Model.Database.SqlQuery(@"
          SELECT en.id, en.code, n.second, n.master, en.notifier, 
          en.detail, en.detail_other, en.approved_date, en.status,
          en.note, en.comment, en.solution, en.updated_at
          FROM dbo.email_notification_defective en
          INNER JOIN dbo.notification n ON n.department_id = en.dep_id
          ORDER BY id DESC;
        ");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
          string EditBtn = $@"
          <a href='notification_defective_page_update.aspx?id={dt.Rows[i]["id"]}'
          class='btn btn-sm btn-warning'><i class='bi bi-pencil-square'></i>แก้ไข</a>
          ";
          if (Session["username"] == null) { EditBtn = ""; }

          string status;
          string bg;
          if (int.Parse(dt.Rows[i]["status"].ToString()) == 0)
          { status = "รอแจ้งรับ"; bg = "bg-warning"; }
          else { status = "แจ้งรับแล้ว"; bg = "bg-success text-light"; }

          TableRowData.Text += $@"
          <tr>
          <td width='1%'></td>
          <td class='text-center {bg}'>{status}</td>
          <td>{dt.Rows[i]["code"]}</td>
          <td>{dt.Rows[i]["second"]}</td>
          <td>{dt.Rows[i]["master"]}</td>
          <td>{dt.Rows[i]["notifier"]}</td>
          <td>{dt.Rows[i]["detail"]}</td>
          <td>{dt.Rows[i]["detail_other"]}</td>
          <td>{dt.Rows[i]["note"]}</td>
          <td>{dt.Rows[i]["approved_date"].ToString().Split(' ')[0]}</td>
          <td>
          <div class=""btn-group"" role=""group"" aria-label=""Basic mixed styles example"">
            {EditBtn}
            <a href='Print/prin_notification_page.aspx?id={dt.Rows[i]["id"]}&type=d' 
            target=""_blank"" class=""btn btn-sm btn-secondary"">
            <i class=""bi bi-printer-fill""></i>
            Print</a>
          </div>
          </td>
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
                {RenderTools(dt.Rows[i]["id"].ToString())}
              </tbody>
            </table>
          </td>
          <td>
          <table class='table table-sm table-striped table-bordered nowrap'>
          <thead>
          <tr>
          <th scope=""col"">รายละเอียด</th>
          <th scope=""col"">วิธีแก้ไข</th>
          <th scope=""col"">อัพเดท</th>
          </tr>
          </thead>
          <tbody>
          <tr>
          <td>{dt.Rows[i]["comment"]}</td>
          <td>{dt.Rows[i]["solution"]}</td>
          <td>{dt.Rows[i]["updated_at"].ToString().Split(' ')[0]}</td>
          </tr>
          </tbody>
          </table>
          </td>
          </tr>
        ";
        }
      }
    }

    private string RenderTools(string id)
    {
      string render = "";
      DataTable dt = Model.Database.SqlQuery($@"
      SELECT tr.register_code, tr.code, t.name AS t_name, pc.name, tr.rang_error
      FROM dbo.email_noti_def_tool ent
      INNER JOIN dbo.tool t ON ent.tool_id = t.id
      INNER JOIN dbo.tool_register tr ON ent.tool_id = tr.tool_id
      INNER JOIN dbo.production_company pc ON tr.produc_company_id = pc.id
      WHERE ent.email_noti_def_id = {id};
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
  }
}