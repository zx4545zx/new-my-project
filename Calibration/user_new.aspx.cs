using System;

namespace Calibration
{
  public partial class user_new : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string columName = "username, password, name, email";
      string value = $"'{TextBoxUserName.Text}','{TextBoxPassword.Text}','{TextBoxName.Text}','{TextBoxEmail.Text}'";
      bool cb = Model.Database.Insert("dbo.user_calibate", columName, value);
      if (cb == true)
      {
        Response.Redirect("user.aspx");
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