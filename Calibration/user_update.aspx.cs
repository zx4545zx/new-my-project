using System;

namespace Calibration
{
  public partial class user_update : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        TextBoxUserName.Text = Request.QueryString["username"];
        TextBoxName.Text = Request.QueryString["name"];
        TextBoxEmail.Text = Request.QueryString["email"];
      }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      string statement = $"username='{TextBoxUserName.Text}', name='{TextBoxName.Text}', email='{TextBoxEmail.Text}'";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
      Response.Redirect($"user_update_password.aspx?id={Request.QueryString["id"]}");
    }
  }
}