using System;

namespace Calibration
{
  public partial class calibate_unit_update : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        TextBoxCode.Text = Request.QueryString["code"];
        TextBoxName.Text = Request.QueryString["name"];
      }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      string statement = $"code='{TextBoxCode.Text}', name='{TextBoxName.Text}'";
      bool cb = Model.Database.UpdateByID("dbo.calibration_unit", statement, id);
      if (cb == true)
      {
        Response.Redirect("calibate_unit.aspx");
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