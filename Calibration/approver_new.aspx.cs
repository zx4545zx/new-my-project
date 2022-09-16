using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class approver_new : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string columName = "name, email";
      string value = $"'{TextBoxName.Text}', '{TextBoxEmail.Text}'";
      bool cb = Model.Database.Insert("dbo.approver", columName, value);
      if (cb == true)
      {
        Response.Redirect("/approver.aspx");
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