using DocumentFormat.OpenXml.Office2010.CustomUI;
using System;
using System.Data;
using System.Globalization;

namespace Calibration
{
  public partial class plan : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable data = Model.Database.SqlQuery($@"
          SELECT p.new_code, p.date_plan, p.rang, p.rang_unit, p.status,
          t.name AS t_name, pc.name AS pc_name, t.model, d.name AS dep_name
          FROM dbo.tool_register tr
          INNER JOIN dbo.calibration_plan p
          ON tr.calibration_plan_id = p.id
          INNER JOIN dbo.production_company pc
          ON tr.produc_company_id = pc.id
          INNER JOIN dbo.tool t
          ON tr.tool_id = t.id
		      INNER JOIN dbo.registrar r
          ON tr.registrar_id = r.id
		      INNER JOIN dbo.department d
          ON r.department_id = d.id
          WHERE MONTH(p.date_plan) = MONTH(getdate())
          ORDER BY tr.id DESC;
        ");

        CultureInfo _cultureTHInfo = new CultureInfo("th-TH");
        int days = Shared.DateTimeTH.GetDayInMonth();
        (_, _, string month) = Shared.DateTimeTH.GetMonth();
        string year = Shared.DateTimeTH.GetYear();
        Literal1.Text = $"<th colspan=\"{days}\" class=\"text-center\">ประจำเดือน: {month} ปี: {year}</th>";

        for (int k = 1; k <= days; k++)
        {
          Literal2.Text += $"<th width=\"1%\">{k}</th>";
        }

        for (var i = 0; i < data.Rows.Count; i++)
        {
          string NextRound = Shared.Utils.CheckRound(data, i);

          string strDate = data.Rows[i]["date_plan"].ToString().Split(' ')[0];
          DateTime dateThai = Convert.ToDateTime(strDate, _cultureTHInfo);
          int sd = int.Parse(dateThai.ToString("dd", _cultureTHInfo));
          RowData.Text += $@"
            <tr>
            <td class='text-center'>{i + 1}</td>
            <td>{data.Rows[i]["new_code"]}</td>
            <td>{data.Rows[i]["dep_name"]}</td>
            <td>{data.Rows[i]["t_name"]}</td>
            <td>{data.Rows[i]["pc_name"]}</td>
            <td>{data.Rows[i]["model"]}</td>
          ";
          for (int j = 1; j <= days; j++)
          {
            string val = "";
            string bg = "";
            if (sd == j) { val = "X"; bg = "bg-light"; }
            RowData.Text += $"<td class='text-center {bg}'>{val}</td>";
          }
          RowData.Text += $@"  
            <th class='text-center'>{strDate}</th>
            <th class='text-center'>{NextRound}</th>
            </tr>
          ";
        }
      }
    }
  }
}