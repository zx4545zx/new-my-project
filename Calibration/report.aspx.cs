using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class report : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DisplayRegisTools();
        DisplayDefTools();
        DisplayErrTools();
      }
    }

    private void DisplayRegisTools()
    {
      string sql = $@"
        SELECT DISTINCT
        d.code, d.name as d_name, t.name,
        COUNT(*) as count_tools
        FROM dbo.tool_register tr
        INNER JOIN dbo.tool t
        ON t.id = tr.tool_id
        INNER JOIN dbo.registrar r
        ON r.id = tr.registrar_id
        INNER JOIN dbo.department d
        ON d.id = r.department_id
        GROUP  BY t.name, d.name, d.code
        ORDER BY d.code ASC;
        ";
      DataTable dt = Model.Database.SqlQuery(sql);

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        TableRowData.Text += $@"
          <tr>
            <td class=""text-center"">{dt.Rows[i]["code"]}</td>
            <td class=""text-center"">{dt.Rows[i]["d_name"]}</td>
            <td class=""text-center"">{dt.Rows[i]["name"]}</td>
            <td class=""text-center"">{dt.Rows[i]["count_tools"]}</td>
          </tr>
        ";
      }
    }

    private void DisplayDefTools()
    {
      string sql = $@"
        SELECT DISTINCT 
        endf.code, d.code as d_code, d.name,
        COUNT(endt.tool_id) as count_tools
        FROM dbo.email_notification_defective endf
        LEFT OUTER JOIN dbo.email_noti_def_tool endt
        ON endf.id = endt.email_noti_def_id
        INNER JOIN dbo.department d
        ON d.id = endf.dep_id
        GROUP BY endf.code, d.code, d.name;
        ";
      DataTable dt = Model.Database.SqlQuery(sql);

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        Literal1.Text += $@"
          <tr>
            <td class=""text-center"">{dt.Rows[i]["code"]}</td>
            <td class=""text-center"">{dt.Rows[i]["d_code"]}</td>
            <td class=""text-center"">{dt.Rows[i]["name"]}</td>
            <td class=""text-center"">{dt.Rows[i]["count_tools"]}</td>
          </tr>
        ";
      }
    }

    private void DisplayErrTools()
    {
      string sql = $@"
        SELECT DISTINCT 
        endf.code, d.code AS d_code, d.name,
        COUNT(endt.tool_id) as count_tools
        FROM dbo.email_notification_error endf
        LEFT OUTER JOIN dbo.email_noti_err_tool endt
        ON endf.id = endt.email_noti_err_id
        INNER JOIN dbo.department d
        ON d.id = endf.dep_id
        GROUP BY endf.code, d.code, d.name;
        ";
      DataTable dt = Model.Database.SqlQuery(sql);

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        Literal2.Text += $@"
          <tr>
            <td class=""text-center"">{dt.Rows[i]["code"]}</td>
            <td class=""text-center"">{dt.Rows[i]["d_code"]}</td>
            <td class=""text-center"">{dt.Rows[i]["name"]}</td>
            <td class=""text-center"">{dt.Rows[i]["count_tools"]}</td>
          </tr>
        ";
      }
    }

    protected void export_button_ServerClick(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", @"
          function html_table_to_excel(type)
          {
            let data = document.getElementById('regPage');
            let file = XLSX.utils.table_to_book(data, { sheet: 'sheet1' });
            XLSX.write(file, { bookType: type, bookSST: true, type: 'base64' });
            XLSX.writeFile(file, 'file.' + type);
          }
          html_table_to_excel('xlsx');
          ", true);
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", @"
          function html_table_to_excel(type)
          {
            let data = document.getElementById('defPage');
            let file = XLSX.utils.table_to_book(data, { sheet: 'sheet1' });
            XLSX.write(file, { bookType: type, bookSST: true, type: 'base64' });
            XLSX.writeFile(file, 'file.' + type);
          }
          html_table_to_excel('xlsx');
          ", true);
    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", @"
          function html_table_to_excel(type)
          {
            let data = document.getElementById('errPage');
            let file = XLSX.utils.table_to_book(data, { sheet: 'sheet1' });
            XLSX.write(file, { bookType: type, bookSST: true, type: 'base64' });
            XLSX.writeFile(file, 'file.' + type);
          }
          html_table_to_excel('xlsx');
          ", true);
    }
  }
}