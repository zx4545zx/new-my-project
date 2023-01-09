using System;

namespace Calibration
{
  public partial class production_company_new : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string columName = "code, name";
      string value = $"'{TextBoxCode.Text}', '{TextBoxName.Text}'";
      bool cb = Model.Database.Insert("dbo.production_company", columName, value);
      if (cb == true)
      {
        Response.Redirect("production_company.aspx");
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