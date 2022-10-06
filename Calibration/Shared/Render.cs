using System.Data;

namespace Calibration.Shared
{
  public class Render
  {
    public static string CottonPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td class='text-center'>{data.Rows[i]["code"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='cotton_update.aspx" +
          $"?id={data.Rows[i]["id"]}&code={data.Rows[i]["code"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('cotton.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string ApproverPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          $"<td>{data.Rows[i]["email"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='approver_update.aspx" +
          $"?id={data.Rows[i]["id"]}&name={data.Rows[i]["name"]}&email={data.Rows[i]["email"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('approver.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string DepartmentPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td class='text-center'>{data.Rows[i]["code"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='department_update.aspx" +
          $"?id={data.Rows[i]["id"]}&code={data.Rows[i]["code"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('department.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string FactoryPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td class='text-center'>{data.Rows[i]["code"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='factory_update.aspx" +
          $"?id={data.Rows[i]["id"]}&code={data.Rows[i]["code"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('factory.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string MeterPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td class='text-center'>{data.Rows[i]["code"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='meter_update.aspx" +
          $"?id={data.Rows[i]["id"]}&code={data.Rows[i]["code"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('meter.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string ProductionCompanyPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td class='text-center'>{data.Rows[i]["code"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='production_company_update.aspx" +
          $"?id={data.Rows[i]["id"]}&code={data.Rows[i]["code"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('production_company.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string CalibateUnitPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td class='text-center'>{data.Rows[i]["code"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='calibate_unit_update.aspx" +
          $"?id={data.Rows[i]["id"]}&code={data.Rows[i]["code"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('calibate_unit.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string ObjectivePage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td>{data.Rows[i]["title"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='objective_update.aspx" +
          $"?id={data.Rows[i]["id"]}&title={data.Rows[i]["title"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('objective.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string ISOPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='iso_update.aspx" +
          $"?id={data.Rows[i]["id"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('iso.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string LocationPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td>{data.Rows[i]["name"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='location_update.aspx" +
          $"?id={data.Rows[i]["id"]}&name={data.Rows[i]["name"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('location.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string DataStatusPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
          $"<td>{data.Rows[i]["title"]}</td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='status_data_update.aspx" +
          $"?id={data.Rows[i]["id"]}&name={data.Rows[i]["title"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('status_data.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string NotiPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        RowData += (
          "<tr>" +
          $"<td class='text-center'></td>" +
          "<td>" +
          "<div class='btn-group' role='group'>" +
          $"<a href='notification_update.aspx" +
          $"?id={data.Rows[i]["id"]}&dep_id={data.Rows[i]["dep_id"]}&master={data.Rows[i]["master"]}&" +
          $"master_email={data.Rows[i]["master_email"]}&second={data.Rows[i]["second"]}&" +
          $"second_email={data.Rows[i]["second_email"]}&other_email={data.Rows[i]["other_email"]}'" +
          "class='btn btn-outline-primary'>แก้ไข</a>" +
          "<button type='button' class='btn btn-danger' " +
          $"onclick=\"ConfirmDel('notification_setting.aspx/Delete',{data.Rows[i]["id"]})\">ลบ</button>" +
          "</div>" +
          "</td>" +
          $"<td class='text-center'>{data.Rows[i]["code"]} | {data.Rows[i]["name"]}</td>" +
          $"<td>{data.Rows[i]["master"]}</td>" +
          $"<td>{data.Rows[i]["master_email"]}</td>" +
          $"<td>{data.Rows[i]["second"]}</td>" +
          $"<td>{data.Rows[i]["second_email"]}</td>" +
          $"<td>{data.Rows[i]["other_email"]}</td>" +
          "</tr>"
          );
      }
      return RowData;
    }

    public static string AdministratorPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        (string Status, string Color) = Utils.CheckStatus(data, i);
        string NextRound;

        string DatePlan;
        if (string.IsNullOrEmpty(data.Rows[i]["date_plan"].ToString()))
        {
          DatePlan = "";
          NextRound = "";
        }
        else
        {
          DatePlan = data.Rows[i]["date_plan"].ToString().Split(' ')[0];
          NextRound = Utils.CheckRound(data, i);
        }

        string sql = $@"
        SELECT tr.tool_id AS t_id, tr.objective, c.status, iso.name AS iso_name,
        ct.name AS ct_name, f.name AS f_name,
        d.name AS d_name, m.name AS m_name,
        t.name AS t_name, pc.name AS pc_name ,t.model,
        t.code, tr.rang_error, el.name AS el_name,
        tr.accept_error, t.detail, tr.detail_calibate
        FROM dbo.tool_register tr
        INNER JOIN dbo.certificate c
        ON c.id = tr.certificate_id
        INNER JOIN dbo.tool t
        ON t.id = tr.tool_id
        LEFT OUTER JOIN dbo.iso iso
        ON iso.id = tr.iso_id
        LEFT OUTER JOIN dbo.exam_location el
        ON el.id = tr.exam_location_id
        INNER JOIN dbo.production_company pc
        ON pc.id = tr.produc_company_id
        INNER JOIN dbo.registrar r
        ON r.id = tr.registrar_id
        INNER JOIN dbo.cotton ct
        ON ct.id = r.cotton_id
        INNER JOIN dbo.factory f
        ON f.id = r.factory_id
        INNER JOIN dbo.meter m
        ON m.id = r.metor_id
        INNER JOIN dbo.department d
        ON d.id = r.department_id
        WHERE tr.id = {data.Rows[i]["id"]};
        ";
        DataTable dt = Model.Database.SqlQuery(sql);

        RowData += (
        $@"
            <tr>
            <td></td>
            <td>{data.Rows[i]["register_code"]}</td>
            <td>{data.Rows[i]["code"]}</td>
            <td>{data.Rows[i]["name"]}</td>
            <td>{data.Rows[i]["depCode"]} | {data.Rows[i]["depName"]}</td>
            <td class='text-center'>{data.Rows[i]["tel"]}</td>
            <td>{data.Rows[i]["email"]}</td>
            <td class='{Color}'>{Status}</td>
            <td class='text-center'>{data.Rows[i]["created_at"]}</td>
            <td class='text-center'>{DatePlan}</td>
            <td class='text-center'>{NextRound}</td>
            <td class='text-center'>
              <div class='btn-group' role='group'>
                <a href='tool_plan_update.aspx?id={data.Rows[i]["id"]}' class='btn btn-warning'>
                  <i class='bi bi-pencil-square'></i>&nbsp;แก้ไขแผน
                </a>
                <a href='evaluate.aspx?id={data.Rows[i]["id"]}' class='btn btn-success'>
                  <i class='bi bi-file-earmark-text-fill'></i>&nbsp;ประเมิน
                </a>
                <button type='button' class='btn btn-danger' 
                onclick=""ConfirmDel('administrator.aspx/Delete',{data.Rows[i]["id"]})"">
                  <i class='bi bi-archive-fill'></i>&nbsp;ลบข้อมูล
                </button>
              </div>
            </td>
            <td>
              <a  href='Print/print_pages.aspx?id={data.Rows[i]["id"]}' target=""_blank"" class='btn btn-secondary'>
                <i class='bi bi-printer-fill'></i>&nbsp;PDF
              </a>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">วัตถุประสงค์</th>
                  <th scope=""col"">มาตราฐาน</th>
                  <th scope=""col"">ฝ่ายต้นสังกัด</th>
                  <th scope=""col"">โรงงาน</th>
                  <th scope=""col"">แผนก</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{dt.Rows[0]["objective"]},{dt.Rows[0]["status"]}</td>
                  <td>{dt.Rows[0]["iso_name"]}</td>
                  <td>{dt.Rows[0]["ct_name"]}</td>
                  <td>{dt.Rows[0]["f_name"]}</td>
                  <td>{dt.Rows[0]["d_name"]}</td>
                </tr>
              </tbody>
            </table>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เครื่องมือวัด</th>
                  <th scope=""col"">ชื่อเครื่องมือวัด</th>
                  <th scope=""col"">ผู้ผลิต</th>
                  <th scope=""col"">รุ่น</th>
                  <th scope=""col"">หมายเลขเครื่อง</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{dt.Rows[0]["m_name"]}</td>
                  <td>{dt.Rows[0]["t_name"]}</td>
                  <td>{dt.Rows[0]["pc_name"]}</td>
                  <td>{dt.Rows[0]["model"]}</td>
                  <td>{dt.Rows[0]["code"]}</td>
                </tr>
              </tbody>
            </table>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">ช่วงใช้งาน</th>
                  <th scope=""col"">สถานที่ใช้งาน</th>
                  <th scope=""col"">ค่าผิดพลาดที่ยอมรับได้</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">รายละเอียดจากแผนกสอบเทียบ</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{dt.Rows[0]["rang_error"]}</td>
                  <td>{dt.Rows[0]["el_name"]}</td>
                  <td>{dt.Rows[0]["accept_error"]}</td>
                  <td>{dt.Rows[0]["detail"]}</td>
                  <td>{dt.Rows[0]["detail_calibate"]}</td>
                </tr>
              </tbody>
            </table>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เลขที่</th>
                  <th scope=""col"">ส่งถึง</th>
                  <th scope=""col"">ผู้อนุมัติ (ฝ่าย)</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">หน่วยงาน</th>
                  <th scope=""col"">วันที่แจ้ง</th>
                </tr>
              </thead>
              <tbody>
                {RenderNotiTool(dt.Rows[0]["t_id"].ToString())}
              </tbody>
            </table>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เลขที่</th>
                  <th scope=""col"">ส่งถึง</th>
                  <th scope=""col"">ผู้อนุมัติ (ฝ่าย)</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">หน่วยงาน</th>
                  <th scope=""col"">วันที่แจ้ง</th>
                  <th scope=""col"">หมายเหตุ/การดำเนินการ</th>
                </tr>
              </thead>
              <tbody>
                {RenderNotiDefTool(dt.Rows[0]["t_id"].ToString())}
              </tbody>
            </table>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เลขที่</th>
                  <th scope=""col"">ส่งถึง</th>
                  <th scope=""col"">ผู้อนุมัติ (ฝ่าย)</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">หน่วยงาน</th>
                  <th scope=""col"">วันที่แจ้ง</th>
                  <th scope=""col"">หมายเหตุ/การดำเนินการ</th>
                </tr>
              </thead>
              <tbody>
                {RenderNotiErrTool(dt.Rows[0]["t_id"].ToString())}
              </tbody>
            </table>
            </td>
          </tr>
          "
        );
      }

      return RowData;
    }

    public static string DefaultPage(DataTable data)
    {
      string RowData = string.Empty;
      for (var i = 0; i < data.Rows.Count; i++)
      {
        (string Status, _) = Utils.CheckStatus(data, i);

        string sql = $@"
        SELECT tr.tool_id AS t_id, tr.objective, c.status, iso.name AS iso_name,
        ct.name AS ct_name, f.name AS f_name,
        d.name AS d_name, m.name AS m_name,
        t.name AS t_name, pc.name AS pc_name ,t.model,
        t.code, tr.rang_error, el.name AS el_name,
        tr.accept_error, t.detail, tr.detail_calibate
        FROM dbo.tool_register tr
        INNER JOIN dbo.certificate c
        ON c.id = tr.certificate_id
        INNER JOIN dbo.tool t
        ON t.id = tr.tool_id
        LEFT OUTER JOIN dbo.iso iso
        ON iso.id = tr.iso_id
        LEFT OUTER JOIN dbo.exam_location el
        ON el.id = tr.exam_location_id
        INNER JOIN dbo.production_company pc
        ON pc.id = tr.produc_company_id
        INNER JOIN dbo.registrar r
        ON r.id = tr.registrar_id
        INNER JOIN dbo.cotton ct
        ON ct.id = r.cotton_id
        INNER JOIN dbo.factory f
        ON f.id = r.factory_id
        INNER JOIN dbo.meter m
        ON m.id = r.metor_id
        INNER JOIN dbo.department d
        ON d.id = r.department_id
        WHERE tr.id = {data.Rows[i]["id"]};
        ";
        DataTable dt = Model.Database.SqlQuery(sql);

        RowData += ($@"
          <tr>
            <td></td>
            <td class='text-center'>{data.Rows[i]["register_code"]}</td>
            <td class='text-center'>{data.Rows[i]["code"]}</td>
            <td class='text-center'>{data.Rows[i]["created_at"]}</td>
            <td>{data.Rows[i]["name"]}</td>
            <td>{data.Rows[i]["depName"]}</td>
            <td class='text-center'>{data.Rows[i]["tel"]}</td>
            <td>{data.Rows[i]["email"]}</td>
            <td class='text-center'>{data.Rows[i]["date_plan"].ToString().Split(' ')[0]}</td>
            <td class='text-center'>{Status}</td>
            <td>{data.Rows[i]["app_name"]}</td>
            <td class='text-center'>
            <a href='Print/print_pages.aspx?id={data.Rows[i]["id"]}' target=""_blank"" class=""btn btn-sm btn-secondary"">
              <i class=""bi bi-printer-fill""></i>
              &nbsp; PDF
            </a>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">วัตถุประสงค์</th>
                  <th scope=""col"">มาตราฐาน</th>
                  <th scope=""col"">ฝ่ายต้นสังกัด</th>
                  <th scope=""col"">โรงงาน</th>
                  <th scope=""col"">แผนก</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{dt.Rows[0]["objective"]},{dt.Rows[0]["status"]}</td>
                  <td>{dt.Rows[0]["iso_name"]}</td>
                  <td>{dt.Rows[0]["ct_name"]}</td>
                  <td>{dt.Rows[0]["f_name"]}</td>
                  <td>{dt.Rows[0]["d_name"]}</td>
                </tr>
              </tbody>
            </table>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เครื่องมือวัด</th>
                  <th scope=""col"">ชื่อเครื่องมือวัด</th>
                  <th scope=""col"">ผู้ผลิต</th>
                  <th scope=""col"">รุ่น</th>
                  <th scope=""col"">หมายเลขเครื่อง</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{dt.Rows[0]["m_name"]}</td>
                  <td>{dt.Rows[0]["t_name"]}</td>
                  <td>{dt.Rows[0]["pc_name"]}</td>
                  <td>{dt.Rows[0]["model"]}</td>
                  <td>{dt.Rows[0]["code"]}</td>
                </tr>
              </tbody>
            </table>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">ช่วงใช้งาน</th>
                  <th scope=""col"">สถานที่ใช้งาน</th>
                  <th scope=""col"">ค่าผิดพลาดที่ยอมรับได้</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">รายละเอียดจากแผนกสอบเทียบ</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{dt.Rows[0]["rang_error"]}</td>
                  <td>{dt.Rows[0]["el_name"]}</td>
                  <td>{dt.Rows[0]["accept_error"]}</td>
                  <td>{dt.Rows[0]["detail"]}</td>
                  <td>{dt.Rows[0]["detail_calibate"]}</td>
                </tr>
              </tbody>
            </table>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เลขที่</th>
                  <th scope=""col"">ส่งถึง</th>
                  <th scope=""col"">ผู้อนุมัติ (ฝ่าย)</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">หน่วยงาน</th>
                  <th scope=""col"">วันที่แจ้ง</th>
                </tr>
              </thead>
              <tbody>
                {RenderNotiTool(dt.Rows[0]["t_id"].ToString())}
              </tbody>
            </table>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เลขที่</th>
                  <th scope=""col"">ส่งถึง</th>
                  <th scope=""col"">ผู้อนุมัติ (ฝ่าย)</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">หน่วยงาน</th>
                  <th scope=""col"">วันที่แจ้ง</th>
                  <th scope=""col"">หมายเหตุ/การดำเนินการ</th>
                </tr>
              </thead>
              <tbody>
                {RenderNotiDefTool(dt.Rows[0]["t_id"].ToString())}
              </tbody>
            </table>
            </td>
            <td>
            <table class=""table table-sm table-striped table-bordered"">
              <thead>
                <tr>
                  <th scope=""col"">เลขที่</th>
                  <th scope=""col"">ส่งถึง</th>
                  <th scope=""col"">ผู้อนุมัติ (ฝ่าย)</th>
                  <th scope=""col"">รายละเอียด</th>
                  <th scope=""col"">หน่วยงาน</th>
                  <th scope=""col"">วันที่แจ้ง</th>
                  <th scope=""col"">หมายเหตุ/การดำเนินการ</th>
                </tr>
              </thead>
              <tbody>
                {RenderNotiErrTool(dt.Rows[0]["t_id"].ToString())}
              </tbody>
            </table>
            </td>
          </tr>
        ");
      }
      return RowData;
    }

    public static string NotiApprovePage(DataTable data)
    {
      string RowData = string.Empty;
      for (int i = 0; i < data.Rows.Count; i++)
      {
        (string status, _) = Utils.CheckStatus(data, i);
        RowData += $@"
          <tr>
            <td>{data.Rows[i]["register_code"]}</td>
            <td>{data.Rows[i]["code"]}</td>
            <td>{data.Rows[i]["created_at"].ToString().Split(' ')[0]}</td>
            <td>{data.Rows[i]["name"]}</td>
            <td>{data.Rows[i]["d_name"]}</td>
            <td>{data.Rows[i]["tel"]}</td>
            <td>{data.Rows[i]["email"]}</td>
            <td>{status}</td>
            <td>
              <button id=""Approve"" type=""button"" class=""btn btn-sm btn-success""
                onclick=""Approved('notification_approve.aspx/Approved',{data.Rows[i]["id"]})"">
                <i class=""bi bi-check-circle-fill""></i>
                อนุมัติ
              </button>
            </td>
          </tr>
        ";
      }
      return RowData;
    }

    private static string RenderNotiTool(string id)
    {
      string RowsData = string.Empty;
      string sql = $@"
      SELECT enf.code, n.master, n.second, 
      enf.detail, d.name, enf.approved_date
      FROM dbo.email_noti_tool ent
      INNER JOIN dbo.email_notification enf
      ON enf.id = ent.email_noti_id
      INNER JOIN dbo.notification n
      ON n.department_id = enf.dep_id
      INNER JOIN dbo.department d
      ON d.id = enf.dep_id
      WHERE ent.tool_id = {id};
      ";
      DataTable dt = Model.Database.SqlQuery(sql);

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        RowsData += $@"
        <tr>
        <td>{dt.Rows[i]["code"]}</td>
        <td>{dt.Rows[i]["master"]}</td>
        <td>{dt.Rows[i]["second"]}</td>
        <td>{dt.Rows[i]["detail"]}</td>
        <td>{dt.Rows[i]["name"]}</td>
        <td>{dt.Rows[i]["approved_date"].ToString().Split(' ')[0]}</td>
        </tr>
        ";
      }

      return RowsData;

    }

    private static string RenderNotiDefTool(string id)
    {
      string RowsData = string.Empty;
      string sql = $@"
      SELECT enf.code, n.master, n.second, 
      enf.detail, d.name, enf.approved_date, enf.note
      FROM dbo.email_noti_def_tool ent
      INNER JOIN dbo.email_notification_defective enf
      ON enf.id = ent.email_noti_def_id
      INNER JOIN dbo.notification n
      ON n.department_id = enf.dep_id
      INNER JOIN dbo.department d
      ON d.id = enf.dep_id
      WHERE ent.tool_id = {id};
      ";
      DataTable dt = Model.Database.SqlQuery(sql);

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        RowsData += $@"
        <tr>
        <td>{dt.Rows[i]["code"]}</td>
        <td>{dt.Rows[i]["master"]}</td>
        <td>{dt.Rows[i]["second"]}</td>
        <td>{dt.Rows[i]["detail"]}</td>
        <td>{dt.Rows[i]["name"]}</td>
        <td>{dt.Rows[i]["approved_date"].ToString().Split(' ')[0]}</td>
        <td>{dt.Rows[i]["note"]}</td>
        </tr>
        ";
      }

      return RowsData;

    }

    private static string RenderNotiErrTool(string id)
    {
      string RowsData = string.Empty;
      string sql = $@"
      SELECT enf.code, n.master, n.second, 
      enf.detail, d.name, enf.approved_date, enf.note
      FROM dbo.email_noti_err_tool ent
      INNER JOIN dbo.email_notification_error enf
      ON enf.id = ent.email_noti_err_id
      INNER JOIN dbo.notification n
      ON n.department_id = enf.dep_id
      INNER JOIN dbo.department d
      ON d.id = enf.dep_id
      WHERE ent.tool_id = {id};
      ";
      DataTable dt = Model.Database.SqlQuery(sql);

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        RowsData += $@"
        <tr>
        <td>{dt.Rows[i]["code"]}</td>
        <td>{dt.Rows[i]["master"]}</td>
        <td>{dt.Rows[i]["second"]}</td>
        <td>{dt.Rows[i]["detail"]}</td>
        <td>{dt.Rows[i]["name"]}</td>
        <td>{dt.Rows[i]["approved_date"].ToString().Split(' ')[0]}</td>
        <td>{dt.Rows[i]["note"]}</td>
        </tr>
        ";
      }

      return RowsData;

    }
  }
}