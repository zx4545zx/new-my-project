using System;
using System.Data;

namespace Calibration.Print
{
  public partial class prin_notification_page : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Label11.Text = "F-W-CAL-001/01-08 REV 06";
        TextBox1.Text = "F-W-CAL-001/01-08 REV 06";

        if (Session["username"] == null)
        {
          TextBox1.Enabled = false;
        }

        if (Request.QueryString["id"] == null)
        {
          Response.Redirect("/Default.aspx");
        }

        string tb = string.Empty;
        string tb2 = string.Empty;
        string condition = string.Empty;
        if (Request.QueryString["type"] == "d")
        {
          tb = "dbo.email_notification_defective";
          tb2 = "dbo.email_noti_def_tool";
          condition = "ent.email_noti_def_id";
          Literal2.Text = "ใบรายงานเครื่องมือวัดบกพร่อง";
          Label12.Text = "ใบแจ้งเครื่องมือวัดบกพร่อง";
        } 
        else if (Request.QueryString["type"] == "e")
        {
          tb = "dbo.email_notification_error";
          tb2 = "dbo.email_noti_err_tool";
          condition = "ent.email_noti_err_id";
          Literal2.Text = "<div>ใบรายงานการปฏิบัติงาน</div><div>ที่ไม่สามารถสอบเทียบ</div><div>เครื่องมือวัดได้</div>";
          Label12.Text = "ใบแจ้งไม่สามารถสอบเทียบเครื่องมือวัดได้";
        }
        else
        {
          Response.Redirect("/Default.aspx");
        }

        DataTable dt = Model.Database.SqlQuery($@"
        SELECT enf.id, enf.code, enf.approved_date,
        n.master, n.second, enf.notifier,
        enf.detail, enf.detail_other,
        enf.comment, enf.solution, enf.note
        FROM {tb} enf
        INNER JOIN dbo.notification n
        ON n.department_id = enf.dep_id
        WHERE enf.id = {Request.QueryString["id"]};
        ");

        RenderData(dt, tb2, condition);
      }
    }

    private void RenderData(DataTable dt, string tb, string condition)
    {
      Label1.Text = $"วันที่ : {dt.Rows[0]["approved_date"].ToString().Split(' ')[0]}";
      Label2.Text = $"เลขที่ : {dt.Rows[0]["code"]}";
      Label3.Text = $"ส่งถึง : {dt.Rows[0]["master"]}";
      Label9.Text = $"สำเนา : {dt.Rows[0]["second"]}";
      Label10.Text = $"ชื่อผู้แจ้ง : {dt.Rows[0]["notifier"]} ";
      Label4.Text = $"{dt.Rows[0]["detail"]}";
      Label5.Text = $"{dt.Rows[0]["detail_other"]}";
      Label6.Text = $"{dt.Rows[0]["comment"]}";
      Label7.Text = $"{dt.Rows[0]["solution"]}";
      Label8.Text = $"{dt.Rows[0]["note"]}";

      DataTable dt_tool = Model.Database.SqlQuery($@"
      SELECT tr.register_code, tr.code, t.name AS t_name, pc.name, tr.rang_error
      FROM {tb} ent
      INNER JOIN dbo.tool t ON ent.tool_id = t.id
      INNER JOIN dbo.tool_register tr ON ent.tool_id = tr.tool_id
      INNER JOIN dbo.production_company pc ON tr.produc_company_id = pc.id
      WHERE {condition} = {dt.Rows[0]["id"]};
      
      ");

      for (int i = 0; i < dt_tool.Rows.Count; i++)
      {
        Literal1.Text += $@"
          <tr>
            <td>{dt_tool.Rows[i]["register_code"]}</td>
            <td>{dt_tool.Rows[i]["code"]}</td>
            <td>{dt_tool.Rows[i]["t_name"]}</td>
            <td>{dt_tool.Rows[i]["name"]}</td>
            <td>{dt_tool.Rows[i]["rang_error"]}</td>
          </tr>
        ";
      }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
      Label11.Text = TextBox1.Text;
    }
  }
}