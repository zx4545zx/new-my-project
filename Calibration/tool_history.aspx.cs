using System;
using System.Data;
using System.Web.UI;

namespace Calibration
{
  public partial class tool_history : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Panel1.Visible = false;
        Panel2.Visible = false;
        DataTable AllDataStatus = Calibration.Model.Database.SqlQuery(@"
        SELECT tr.id, t.name, tr.code
        FROM dbo.tool t
        INNER JOIN dbo.tool_register tr
        ON tr.tool_id = t.id
        ");
        for (var i = 0; i < AllDataStatus.Rows.Count; i++)
        {
          SelectCode.Items.Insert(i + 1, new System.Web.UI.WebControls.ListItem(
            $"{AllDataStatus.Rows[i]["code"]} | {AllDataStatus.Rows[i]["name"]}",
            $"{AllDataStatus.Rows[i]["id"]}"));
        }
      }
    }

    private void RenderChart(DataTable dt)
    {
      string data = "";
      data += "[";
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        data += "{" +
          $"date: '{dt.Rows[i]["created_at"].ToString().Split(' ')[0]}'," +
          $" error: '{dt.Rows[i]["error"]}'" +
          "},";
      }
      data += "]";

      ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript",
          $"DisplayChart({data})",
          true
          );
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      Panel1.Visible = true;
      Panel2.Visible = true;
      RowData.Text = "";
      GetData();
      GetTool();
    }

    private void GetData()
    {
      string[] my = Picker.Value.Split('-');
      string sql = $@"
      SELECT cr.*
      FROM dbo.calibration_results cr
      INNER JOIN dbo.tool_register_calibration_results trcr
      ON trcr.calibration_results_id = cr.id
      WHERE trcr.tool_register_id = {SelectCode.SelectedValue}
      AND MONTH(created_at) = {my[1]}
      AND YEAR(created_at) = {my[0]}
      ORDER BY cr.created_at ASC;
      ";
      if (flexCheckDefault.Checked)
      {
        sql = $@"
        SELECT cr.*
        FROM dbo.calibration_results cr
        INNER JOIN dbo.tool_register_calibration_results trcr
        ON trcr.calibration_results_id = cr.id
        WHERE trcr.tool_register_id = {SelectCode.SelectedValue}
        AND YEAR(created_at) = {my[0]}
        ORDER BY cr.created_at ASC;
        ";
      }

      DataTable dt = Calibration.Model.Database.SqlQuery(sql);
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        RowData.Text += $@"
        <tr>
        <td width='1%'>#</td>
        <td class='text-center'>{dt.Rows[i]["error"]}</td>
        <td class='text-center'>{dt.Rows[i]["status"]}</td>
        <td class='text-center'>{dt.Rows[i]["created_at"]}</td>
        <td>{dt.Rows[i]["resultant"]}</td>
        <td class='text-center'>{dt.Rows[i]["data_status_id"]}</td>
        <td>{dt.Rows[i]["comment"]}</td>
        <td class='text-center'>{dt.Rows[i]["date_calibrat"]}</td>
        </tr>
        ";
      }
      RenderChart(dt);
    }

    private void GetTool()
    {
      DataTable dt = Calibration.Model.Database.SqlQuery($@"
        SELECT tr.register_code, tr.code, t.name AS tool_name,
        pc.name AS pc_name, t.model, t.code AS tool_no, tr.img_url
        FROM dbo.tool_register tr
        INNER JOIN dbo.tool t
        ON t.id = tr.tool_id
        INNER JOIN dbo.production_company pc
        ON pc.id = tr.produc_company_id
        WHERE tr.id = {SelectCode.SelectedValue};
      ");

      if (dt.Rows.Count > 0)
      {
        if (!string.IsNullOrEmpty(dt.Rows[0]["img_url"].ToString()))
        {
          ImgCover.Attributes["src"] = dt.Rows[0]["img_url"].ToString();
        }
        else
        {
          ImgCover.Attributes["src"] = "Images/default-placeholder.png";
        }
        RegCode.Text = dt.Rows[0]["register_code"].ToString();
        Code.Text = dt.Rows[0]["code"].ToString();
        NameTool.Text = dt.Rows[0]["tool_name"].ToString();
        Company.Text = dt.Rows[0]["pc_name"].ToString();
        Model.Text = dt.Rows[0]["model"].ToString();
        ToolNo.Text = dt.Rows[0]["tool_no"].ToString();
      }
    }
  }
}