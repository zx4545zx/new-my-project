using System;

namespace Calibration
{
  public partial class user_update_password : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      string statement = $"password='{TextBoxNewPassword.Text}'";
      bool cb = Model.Database.UpdateByID("dbo.user_calibate", statement, id);
      if (cb == true)
      {
        Response.Redirect("user.aspx");
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