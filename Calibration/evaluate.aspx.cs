using Calibration.Shared;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class evaluate : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(Request.QueryString["id"]))
      {
        Response.Redirect("administrator.aspx");
      }

      if (!IsPostBack)
      {
        if (Session["username"] != null)
        {
          TextBox2.Text = Session["username"].ToString();
        }
        DataTable AllData = Model.Database.SqlQuery(
          $@"
            SELECT r.register_code, r.code, FORMAT(CAST(p.date_plan AS DATE),'dd-MM-yyyy') AS date_plan, p.rang, p.rang_unit
            FROM dbo.tool_register r
            INNER JOIN dbo.calibration_plan p
            ON r.calibration_plan_id = p.id
            WHERE r.id = {Request.QueryString["id"]};
          "
          );
        Label1.Text = AllData.Rows[0]["register_code"].ToString();
        Label2.Text = AllData.Rows[0]["code"].ToString();
        if (string.IsNullOrEmpty(AllData.Rows[0]["date_plan"].ToString()))
        {
          Label3.Text = $"<a href='tool_plan_update.aspx?id={Request.QueryString["id"]}'>กรุณาลงแผน</a>";
          Label3.CssClass = "btn btn-sm btn-danger";
          Button2.Enabled = false;
        }
        else
        {
          Label3.Text = AllData.Rows[0]["date_plan"].ToString();
          Label3.CssClass = "btn btn-sm btn-outline-danger disabled";
          Button2.Enabled = true;
        }

        DataTable AllDataStatus = Model.Database.SelectAll("dbo.data_status");
        for (var i = 0; i < AllDataStatus.Rows.Count; i++)
        {
          StatusData.Items.Insert(i + 1, new ListItem(
            $"{AllDataStatus.Rows[i]["title"]}",
            $"{AllDataStatus.Rows[i]["id"]}"));
        }

        DataTable AllResult = Model.Database.SqlQuery($@"
          SELECT tc.*, cr.*, ds.title
          FROM dbo.tool_register_calibration_results tc
          INNER JOIN dbo.calibration_results cr ON tc.calibration_results_id = cr.id
          INNER JOIN dbo.data_status ds ON cr.data_status_id = ds.id
          WHERE tc.tool_register_id = {Request.QueryString["id"]}
          ORDER BY cr.id DESC;
        ");
        for (var i = 0; i < AllResult.Rows.Count; i++)
        {
          string status;
          if (int.Parse(AllResult.Rows[i]["status"].ToString()) == 1)
          {
            status = "ผ่าน";
          }
          else if (int.Parse(AllResult.Rows[i]["status"].ToString()) == 2)
          {
            status = "ไม่ผ่าน";
          }
          else
          {
            status = "-";
          }

          RowData.Text += $@"
            <tr>
              <td scope='row'></td>
              <td scope='row' class='text-center'>{AllResult.Rows[i]["error"]}</td>
              <td scope='row' class='text-center'>{status}</td>
              <td scope='row' class='text-center'>
              {AllResult.Rows[i]["created_at"].ToString().Split(' ')[0]}</td>
              <td scope='row'>{AllResult.Rows[i]["resultant"]}</td>
              <td scope='row' class='text-center'>{AllResult.Rows[i]["title"]}</td>
              <td scope='row'>{AllResult.Rows[i]["comment"]}</td>
              <td scope='row' class='text-center'>
              {AllResult.Rows[i]["date_calibrat"].ToString().Split(' ')[0]}</td>
              <td scope='row' class='text-center'>
              <a href='evaluate_update.aspx?id={AllResult.Rows[i]["id"]}&tool_id={Request.QueryString["id"]}'
              class='btn btn-sm btn-warning'>
              <i class='bi bi-pencil-square'></i>&nbsp;แก้ไข
              </a>
              </td>
            </tr>
          ";
        }
      }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      int returning_ID = Model.Database.InsertReturnID(
        "dbo.calibration_results",
        "error,status,created_at,data_status_id,resultant,comment,round_date",
        $"'{TextBox1.Text}',{Status.SelectedValue},Cast( '{DatePlan.Value}' as DATE)," +
        $"{StatusData.SelectedValue},'{TextBox2.Text}','{floatingTextarea2.Value}','{Label3.Text}'"
        );

      if (returning_ID > 0)
      {
        bool cb1 = Model.Database.Insert(
          "dbo.tool_register_calibration_results",
          "calibration_results_id, tool_register_id",
          $"{returning_ID}, {Request.QueryString["id"]}");

        DataTable data = Model.Database.SqlQuery(
          $@"
            SELECT p.id, p.date_plan, p.rang, p.rang_unit
            FROM dbo.tool_register r
            INNER JOIN dbo.calibration_plan p
            ON r.calibration_plan_id = p.id
            WHERE r.id = {Request.QueryString["id"]};
          "
          );
        DateTime conv_dt = DateTime.Parse(DatePlan.Value);
        int count = int.Parse(data.Rows[0]["rang"].ToString());
        string NextRound = CheckNextRound(data, conv_dt, count);

        bool cb2 = Model.Database.UpdateByID(
          "dbo.calibration_plan",
          $"date_plan=Cast( '{NextRound}' as date)",
          data.Rows[0]["id"].ToString()
          );

        if (cb1 && cb2)
        {
          Response.Redirect($"evaluate.aspx?id={Request.QueryString["id"]}");
        }
        else
        {
          ScriptManager.RegisterStartupScript(this, GetType(),
            "MyScript", $"MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'ไม่สามารถบันทึกข้อมูลได้'," +
            $" '{"/evaluate.aspx?id=" + Request.QueryString["id"]}');", true);
        }
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", $"MessageNoti('success', 'เกิดข้อผิดพลาด!!!', 'ไม่สามารถบันทึกข้อมูลได้'," +
          $" '{"/evaluate.aspx?id=" + Request.QueryString["id"]}');", true);
      }
    }

    private string CheckNextRound(DataTable data, DateTime conv_dt, int count)
    {
      string NextRound;
      if (data.Rows[0]["rang_unit"].ToString() == "d")
      {
        NextRound = conv_dt.AddDays(count).ToString("yyyy/MM/dd");
      }
      else if (data.Rows[0]["rang_unit"].ToString() == "w")
      {
        NextRound = conv_dt.AddDays(count * 7).ToString("yyyy/MM/dd");
      }
      else if (data.Rows[0]["rang_unit"].ToString() == "m")
      {
        NextRound = conv_dt.AddMonths(count).ToString("yyyy/MM/dd");
      }
      else if (data.Rows[0]["rang_unit"].ToString() == "y")
      {
        NextRound = conv_dt.AddYears(count).ToString("yyyy/MM/dd");
      }
      else
      {
        NextRound = data.Rows[0]["date_plan"].ToString().Split(' ')[0];
      }

      return NextRound;
    }
  }
}