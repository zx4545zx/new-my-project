using System;
using System.Data;
using System.Web.UI;

namespace Calibration
{
  public partial class tool_history : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      RenderChart("1038");
    }

    private void RenderChart(string tr_id)
    {
      DataTable dt = Model.Database.SqlQuery($@"
        SELECT cr.error, cr.created_at, trcr.tool_register_id
        FROM dbo.calibration_results cr
        INNER JOIN dbo.tool_register_calibration_results trcr
        ON cr.id = trcr.calibration_results_id
        WHERE trcr.tool_register_id = {tr_id}
        ORDER BY cr.created_at ASC;;
      ");

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
  }
}