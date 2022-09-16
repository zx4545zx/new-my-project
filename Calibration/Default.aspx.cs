using ClosedXML.Excel;
using System;
using System.Data;
using System.Web.UI;

namespace Calibration
{
  public partial class Default : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllData = Model.Database.SqlQuery(
          @"
            SELECT t.id, t.register_code, t.code, t.status, r.created_at, r.name, d.code AS depCode, 
            d.name AS depName, r.tel, r.email, p.date_plan, p.rang, p.rang_unit, a.name AS app_name
            FROM dbo.tool_register t
            INNER JOIN dbo.registrar r ON t.registrar_id = r.id
            INNER JOIN dbo.calibration_plan p ON t.calibration_plan_id = p.id
            INNER JOIN dbo.department d ON r.department_id = d.id
            INNER JOIN dbo.approver a ON r.approver_id = a.id
            ORDER BY t.id DESC;
          "
          );
        RowData.Text = Shared.Render.DefaultPage(AllData);
      }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      DataTable table = Model.Database.SelectAll("dbo.tb_user");
      using (XLWorkbook wb = new XLWorkbook())
      {
        wb.Worksheets.Add(table, "Sheet1");
        Shared.Export.Excel(wb, "user");
      }
    }
  }
}