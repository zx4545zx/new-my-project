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
          $"<td class='text-center'>{data.Rows[i]["id"]}</td>" +
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

        RowData += (
        $@"
            <tr>
            <td></td>
            <td>{data.Rows[i]["register_code"]}</td>
            <td>{data.Rows[i]["code"]}</td>
            <td>{data.Rows[i]["name"]}</td>
            <td>{data.Rows[i]["depCode"]} | {data.Rows[i]["depName"]}</td>
            <td>{data.Rows[i]["tel"]}</td>
            <td>{data.Rows[i]["email"]}</td>
            <td class='{Color}'>{Status}</td>
            <td class='text-center'>{DatePlan}</td>
            <td class='text-center'>{NextRound}</td>
            <td class='text-center'>{data.Rows[i]["created_at"]}</td>
            <td class='text-center'>
              <a href='/tool_details.aspx?id={data.Rows[i]["id"]}' class='btn btn-info'>
                <i class='bi bi-info-circle'></i>&nbsp;รายละเอียด
              </a>
            </td>
            <td class='text-center'>
              <div class='btn-group' role='group'>
                <a href='/tool_plan_update.aspx?id={data.Rows[i]["id"]}' class='btn btn-warning'>
                  <i class='bi bi-pencil-square'></i>&nbsp;แก้ไขแผน
                </a>
                <a href='/evaluate.aspx?id={data.Rows[i]["id"]}' class='btn btn-success'>
                  <i class='bi bi-file-earmark-text-fill'></i>&nbsp;ประเมิน
                </a>
                <button type='button' class='btn btn-danger'>
                  <i class='bi bi-archive-fill'></i>&nbsp;ลบข้อมูล
                </button>
              </div>
            </td>
            <td>
              <a  href='#' class='btn btn-secondary'>
                <i class='bi bi-printer-fill'></i>&nbsp;PDF
              </a>
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

        RowData += ($@"
          <tr>
            <td></td>
            <td>{data.Rows[i]["register_code"]}</td>
            <td>{data.Rows[i]["code"]}</td>
            <td>{data.Rows[i]["created_at"]}</td>
            <td>{data.Rows[i]["name"]}</td>
            <td>{data.Rows[i]["depName"]}</td>
            <td class='text-center'>{data.Rows[i]["tel"]}</td>
            <td>{data.Rows[i]["email"]}</td>
            <td class='text-center'>{data.Rows[i]["date_plan"].ToString().Split(' ')[0]}</td>
            <td>{Status}</td>
            <td>{data.Rows[i]["app_name"]}</td>
            <td>
              <div class=""btn-group"" role=""group"" aria-label=""Basic example"">
                <button type=""button"" class=""btn btn-outline-primary"">รายละเอียด</button>
                <button type=""button"" class=""btn btn-secondary"">
                  <i class=""bi bi-printer-fill""></i>
                  &nbsp; PDF
                </button>
              </div>
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
  }
}