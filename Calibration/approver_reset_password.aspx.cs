using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class approver_reset_password : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string id = Session["role"].ToString();
      string statement = $"password='{TextBoxNewPassword.Text}'";
      bool cb = Model.Database.UpdateByID("dbo.approver", statement, id);
      if (cb == true)
      {
        ErrorMessage.Text = (
          "<div class=\"alert alert-success\" role=\"alert\"> บันทึกรหัสผ่านเรียบร้อยแล้ว </div>"
          );
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