using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Web.UI;

namespace Calibration
{
  public partial class Site : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["username"] == null)
      {
        PanelLogIn.Visible = true;
        PanelLogOut.Visible = false;
        SideBar.Visible = false;
      }
      else
      {
        PanelLogIn.Visible = false;
        PanelLogOut.Visible = true;
        SideBar.Visible = true;
        Label1.Text = Session["username"].ToString();
      }
    }

    protected void LogInBtn_Click(object sender, EventArgs e)
    {
      // call user on database for check username and password.
      // use else if foe check.
      if (Username.Value == "admin" && Password.Value == "1234")
      {
        Session["username"] = Username.Value;
        Response.Redirect("administrator.aspx");
      }
      else
      {
        Session.Clear();
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'กรุณาตรวจสอบ Username หรือ Password อีกครั้ง', 'Default.aspx');", true);

      }
    }

    protected void LogOutBtn_Click(object sender, EventArgs e)
    {
      if (Page.IsPostBack)
      {
        Session.Clear();
        Response.Redirect("Default.aspx");
      }
    }
  }
}