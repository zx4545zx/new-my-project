using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class notification_new : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable Alldep = Model.Database.SqlQuery(@"
          SELECT d.*
          FROM dbo.department d
          LEFT JOIN dbo.notification n
          ON n.department_id = d.id
          WHERE n.department_id IS NULL;
        ");
        for (var i = 0; i < Alldep.Rows.Count; i++)
        {
          DropList.Items.Insert(i + 1, new ListItem(
            $"{Alldep.Rows[i]["code"]} | {Alldep.Rows[i]["name"]}", $"{Alldep.Rows[i]["id"]}"));
        }
      }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      string columName = "master, master_email, second, second_email, other_email, department_id";
      string value = $"'{name.Value}', '{email.Value}', '{sname.Value}', '{semail.Value}', " +
        $"'{floatingTextarea2.Value}', '{DropList.SelectedValue}'";

      bool cb = Model.Database.Insert("dbo.notification", columName, value);
      if (cb == true)
      {
        Response.Redirect("notification_setting.aspx");
      }
      else
      {
        ErrorMessage.Text = (
          "<div class='alert alert-danger' role='alert'><b>เกิดข้อผิดพลาด!!! </b> ไม่สามารถเพิ่มข้อมูลได้</div>"
          );
      }
    }
  }
}