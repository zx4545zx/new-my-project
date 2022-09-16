using System;
using System.Data;

namespace Calibration.administrator
{
  public partial class Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllData = Model.Database.SqlQuery(
          @"
            SELECT t.id, t.register_code, t.code, t.status, r.created_at, r.name, d.code AS depCode, 
            d.name AS depName, r.tel, r.email, p.date_plan, p.rang, p.rang_unit
            FROM dbo.tool_register t
            INNER JOIN dbo.registrar r ON t.registrar_id = r.id
            INNER JOIN dbo.calibration_plan p ON t.calibration_plan_id = p.id
            INNER JOIN dbo.department d ON r.department_id = d.id
            ORDER BY t.id DESC;
          "
          );
        TableRowData.Text = Shared.Render.AdministratorPage(AllData);
      }
    }
  }
}