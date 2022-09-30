using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class plan : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string sql = $@"
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
          AND YEAR(p.date_plan) = YEAR(getdate())
          ORDER BY tr.id DESC;
        ";
        LoadPlan(sql);
        CallDepartment();
      }
    }

    private void CallDepartment()
    {
      DataTable Alldep = Model.Database.SelectAll("dbo.department");
      for (var i = 0; i < Alldep.Rows.Count; i++)
      {
        SelectCode.Items.Insert(i + 1, new ListItem(
          $"{Alldep.Rows[i]["code"]} | {Alldep.Rows[i]["name"]}", $"{Alldep.Rows[i]["id"]}"));
      }
    }

    private void LoadPlan(string sql)
    {
      DataTable data = Model.Database.SqlQuery(sql);
      int days = Shared.DateTimeTH.GetDayInMonth();
      (_, _, string month) = Shared.DateTimeTH.GetMonth();
      string year = Shared.DateTimeTH.GetYear();
      RenderTable(data, days, month, year);
    }

    private void RenderTable(DataTable data, int days, string month, string year)
    {
      Literal1.Text = "";
      Literal2.Text = "";
      RowData.Text = "";

      CultureInfo _cultureTHInfo = new CultureInfo("th-TH");
      Literal1.Text = $"<th colspan=\"{days}\" class=\"text-center\">" +
        $"ประจำเดือน <span class='text-danger'>{month}</span>" +
        $" ปี <span class='text-danger'>{year}</span></th>";

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

    protected void Submit_ServerClick(object sender, EventArgs e)
    {
      string condition = "";
      if (int.Parse(SelectCode.SelectedValue) != 0)
      {
        condition = $"AND d.id = {SelectCode.SelectedValue}";
      }

      string _year = Picker.Value.Split('-')[0].ToString();
      string _month = Picker.Value.Split('-')[1].ToString();
      string sql = $@"
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
          WHERE MONTH(p.date_plan) = MONTH(Cast( '{_year}-{_month}-01' as date ))
          AND YEAR(p.date_plan) = YEAR(Cast( '{_year}-{_month}-01' as date ))
          {condition}
          ORDER BY tr.id DESC;
        ";

      DataTable data = Model.Database.SqlQuery(sql);
      int days = DateTime.DaysInMonth(int.Parse(_year), int.Parse(_month));

      Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
      DateTime conV = Convert.ToDateTime($"01-{_month}-{int.Parse(_year)+543}");
      string month = conV.ToString("MMMM");
      string year = conV.ToString("yyyy");

      RenderTable(data, days, month, year);

      ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "$('#scrollx').DataTable({scrollX: true});", true);
    }

    protected void export_button_ServerClick(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", @"
          function html_table_to_excel(type)
          {
            let data = document.getElementById('scrollx');
            let file = XLSX.utils.table_to_book(data, { sheet: 'sheet1' });
            XLSX.write(file, { bookType: type, bookSST: true, type: 'base64' });
            XLSX.writeFile(file, 'file.' + type);
          }
          html_table_to_excel('xlsx');
          $('#scrollx').DataTable({scrollX: true});
          ", true);
    }
  }
}