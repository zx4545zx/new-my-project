using System;

namespace Calibration
{
  public partial class calibate_unit_new : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string columName = "code, name";
      string value = $"'{TextBoxCode.Text}', '{TextBoxName.Text}'";
      bool cb = Model.Database.Insert("dbo.calibration_unit", columName, value);
      if (cb == true)
      {
        Response.Redirect("/calibate_unit.aspx");
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