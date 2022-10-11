using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class iso_new : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string columName = "name";
      string value = $"'{TextBoxName.Text}'";
      bool cb = Model.Database.Insert("dbo.iso", columName, value);
      if (cb == true)
      {
        Response.Redirect("iso.aspx");
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