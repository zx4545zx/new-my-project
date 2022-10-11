using System;

namespace Calibration
{
  public partial class iso_update : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        TextBoxName.Text = Request.QueryString["name"];
      }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      string statement = $"name='{TextBoxName.Text}'";
      bool cb = Model.Database.UpdateByID("dbo.iso", statement, id);
      if (cb == true)
      {
        Response.Redirect("iso.aspx");
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