using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Data;
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
        Panel1.Visible = false;
        Panel2.Visible = false;
      }
      else
      {
        if (Session["role"] != null)
        {
          Panel2.Visible = true;
          Panel3.Visible = false;
        } 
        else
        {
          Panel2.Visible = false;
          Panel3.Visible = true;
        }


        if (Session["username"].ToString() == "admin")
        {
          Panel1.Visible = true;
        }
        else
        {
          Panel1.Visible = false;
        }

        PanelLogIn.Visible = false;
        PanelLogOut.Visible = true;
        SideBar.Visible = true;
        Label1.Text = Session["username"].ToString();
      }
    }

    protected void LogInBtn_Click(object sender, EventArgs e)
    {
      string sql = $@"
        SELECT *
        FROM dbo.user_calibate
        WHERE username = '{Username.Value}'
        AND password = '{Password.Value}';
      ";
      DataTable dt = Model.Database.SqlQuery(sql);

      if (Username.Value == "admin" && Password.Value == "1234")
      {
        Session["username"] = Username.Value;
        Response.Redirect("administrator.aspx");
      }
      else if (dt.Rows.Count > 0)
      {
        Session["username"] = dt.Rows[0]["name"];
        Response.Redirect("administrator.aspx");
      }
      else
      {
        Session.Clear();
        ScriptManager.RegisterStartupScript(this, GetType(),"MyScript", "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'กรุณาตรวจสอบ Username หรือ Password อีกครั้ง', 'Default.aspx');", true);

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