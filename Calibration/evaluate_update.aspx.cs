using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class evaluate_update : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(Request.QueryString["id"]))
      {
        Response.Redirect("/administrator.aspx");
      }
      if (!IsPostBack)
      {
        DataTable AllDataStatus = Model.Database.SelectAll("dbo.data_status");
        for (var i = 0; i < AllDataStatus.Rows.Count; i++)
        {
          StatusData.Items.Insert(i + 1, new ListItem(
            $"{AllDataStatus.Rows[i]["title"]}",
            $"{AllDataStatus.Rows[i]["id"]}"));
        }
        string id = Request.QueryString["id"];
        GetData(id);
      }
    }

    private void GetData(string id)
    {
      string sql = $@"
      SELECT tr.register_code, tr.code, cr.error, cr.status, 
      cr.created_at AS dateformat, cr.data_status_id, cr.resultant, cr.comment
      FROM dbo.calibration_results cr
      INNER JOIN dbo.tool_register_calibration_results trcr
      ON trcr.calibration_results_id = cr.id
      INNER JOIN dbo.tool_register tr
      ON trcr.tool_register_id = tr.id
      WHERE cr.id = {id};
      ";

      DataTable AllResult = Model.Database.SqlQuery(sql);
      Label1.Text = AllResult.Rows[0]["register_code"].ToString();
      Label2.Text = AllResult.Rows[0]["code"].ToString();
      TextBox1.Text = AllResult.Rows[0]["error"].ToString();
      Status.SelectedValue = AllResult.Rows[0]["status"].ToString();
      DatePlan.Value = ConvertSqlDateToHtml(AllResult.Rows[0]["dateformat"].ToString());
      StatusData.SelectedValue = AllResult.Rows[0]["data_status_id"].ToString();
      TextBox2.Text = AllResult.Rows[0]["resultant"].ToString();
      floatingTextarea2.Value = AllResult.Rows[0]["comment"].ToString();
    }

    private string ConvertSqlDateToHtml(string exDate)
    {
      string[] ex_date = exDate.Split(' ')[0].Split('/');
      return (int.Parse(ex_date[2]) - 543).ToString() + "-"
        + ex_date[1].PadLeft(2, '0') + "-" + ex_date[0].PadLeft(2, '0');
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      string tool_id = Request.QueryString["tool_id"];
      string statement = $@"
      error='{TextBox1.Text}', resultant='{TextBox2.Text}' ,comment='{floatingTextarea2.Value}',
      data_status_id={StatusData.SelectedValue}, created_at=Cast( '{DatePlan.Value}' as DATE), status={Status.SelectedValue}
      ";
      bool cb = Model.Database.UpdateByID("dbo.calibration_results", statement, id);
      DataTable data = Model.Database.SqlQuery(
      $@"
        SELECT p.id, p.date_plan, p.rang, p.rang_unit
        FROM dbo.tool_register r
        INNER JOIN dbo.calibration_plan p
        ON r.calibration_plan_id = p.id
        WHERE r.id = {tool_id};
      "
      );

      if (cb)
      {
        Response.Redirect($"evaluate.aspx?id={tool_id}");
      }
      else
      {
        ErrorMessage.Text = (
          "<div class='alert alert-danger mb-3' role='alert'><b>เกิดข้อผิดพลาด!!! </b> ไม่สามารถแก้ไขข้อมูลได้</div>"
          );
      }
    }
  }
}