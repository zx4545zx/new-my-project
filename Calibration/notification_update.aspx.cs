using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class notification_update : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable Alldep = Model.Database.SelectAll("dbo.department");
        for (var i = 0; i < Alldep.Rows.Count; i++)
        {
          DropList.Items.Insert(i + 1, new ListItem(
            $"{Alldep.Rows[i]["code"]} | {Alldep.Rows[i]["name"]}", $"{Alldep.Rows[i]["id"]}"));
        }

        DropList.SelectedValue = Request.QueryString["dep_id"];
        name.Value = Request.QueryString["master"];
        email.Value = Request.QueryString["master_email"];
        sname.Value = Request.QueryString["second"];
        semail.Value = Request.QueryString["second_email"];
        floatingTextarea2.Value = Request.QueryString["other_email"];
      }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      string statement = $"master='{name.Value}', master_email='{email.Value}', second='{sname.Value}', " +
        $"second_email='{semail.Value}', other_email='{floatingTextarea2.Value}', department_id={DropList.SelectedValue}";

      bool cb = Model.Database.UpdateByID("dbo.notification", statement, id);
      if (cb == true)
      {
        Response.Redirect("notification_setting.aspx");
      }
      else
      {
        ErrorMessage.Text = (
          "<div class='alert alert-danger' role='alert'><b>เกิดข้อผิดพลาด!!! </b> ไม่สามารถแก้ไขข้อมูลได้</div>"
          );
      }
    }
  }
}