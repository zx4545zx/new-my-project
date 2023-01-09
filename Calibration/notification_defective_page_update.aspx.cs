using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Data;
using System.Web.UI;

namespace Calibration
{
  public partial class notification_defective_page_update : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString["id"] == null)
      {
        Response.Redirect("notification_defective_page.aspx");
      }

      if (!IsPostBack)
      {
        DataTable dt = Model.Database.SelectAttributeByID(
          "detail_other,note", "email_notification_defective", Request.QueryString["id"]);

        floatingTextarea2.Value = dt.Rows[0]["detail_other"].ToString();
        Textarea1.Value = dt.Rows[0]["note"].ToString();
      }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      bool cb = Model.Database.UpdateByID(
        "email_notification_defective",
        $"detail_other='{floatingTextarea2.Value}',note='{Textarea1.Value}'",
        Request.QueryString["id"]);

      if (cb)
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", 
          "MessageNoti('success', 'บันทึกข้อมูลสำเร็จ', 'บันทึกข้อมูลเรียบร้อย', 'notification_defective_page.aspx');",
          true);
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript",
          "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'ไม่สามารถบันทึกข้อมูลได้', 'notification_defective_page.aspx');",
          true);
      }
    }
  }
}