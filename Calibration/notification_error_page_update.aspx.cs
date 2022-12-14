using System;
using System.Data;
using System.Web.UI;

namespace Calibration
{
  public partial class notification_error_page_update : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString["id"] == null)
      {
        Response.Redirect("notification_error_page.aspx");
      }

      if (!IsPostBack)
      {
        DataTable dt = Model.Database.SelectAttributeByID(
          "detail_other,note", "email_notification_error", Request.QueryString["id"]);

        floatingTextarea2.Value = dt.Rows[0]["detail_other"].ToString();
        Textarea1.Value = dt.Rows[0]["note"].ToString();
      }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      bool cb = Model.Database.UpdateByID(
        "email_notification_error",
        $"detail_other='{floatingTextarea2.Value}',note='{Textarea1.Value}'",
        Request.QueryString["id"]);

      if (cb)
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript",
          "MessageNoti('success', 'บันทึกข้อมูลสำเร็จ', 'บันทึกข้อมูลเรียบร้อย', 'notification_error_page.aspx');",
          true);
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript",
          "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'ไม่สามารถบันทึกข้อมูลได้', 'notification_error_page.aspx');",
          true);
      }
    }
  }
}