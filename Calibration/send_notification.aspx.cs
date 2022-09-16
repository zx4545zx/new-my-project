using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class send_notification : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable Alldep = Model.Database.SqlQuery(@"
          SELECT d.code, d.name, n.*
          FROM dbo.department d
          INNER JOIN dbo.notification n
          ON n.department_id = d.id;
        ");
        for (var i = 0; i < Alldep.Rows.Count; i++)
        {
          Department.Items.Insert(i + 1, new ListItem(
            $"{Alldep.Rows[i]["code"]} | {Alldep.Rows[i]["name"]} | " +
            $"{Alldep.Rows[i]["master"]} | {Alldep.Rows[i]["master_email"]} | " +
            $"{Alldep.Rows[i]["second"]} | {Alldep.Rows[i]["second_email"]} | " +
            $"{Alldep.Rows[i]["other_email"]}",
            $"{Alldep.Rows[i]["department_id"]}"));
        }
      }
    }

    protected void Department_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (int.Parse(Department.SelectedValue) > 0)
      {
        SetDataOnTextBox();
        SetDataOnToolSelect();
      }
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
      RowData.Text = "";
      string SelectData = Request.Form["listtoolselect"];
      if (!string.IsNullOrEmpty(SelectData))
      {
        string[] ListSelect = SelectData.Split(',');
        for (int i = 0; i < ListSelect.Length; i++)
        {
          string[] Data = ListSelect[i].Split('|');
          RowData.Text += "<tr>";
          for (int j = 0; j < Data.Length; j++)
          {
            RowData.Text += $@"
            <td>{Data[j]}</td>
          ";
          }
          RowData.Text += "</tr>";
        }
      }
    }

    private void SetDataOnTextBox()
    {
      DataTable NotiData = Model.Database.SelectByCondition(
          "dbo.notification", $"department_id={Department.SelectedValue}");

      if (NotiData.Rows.Count > 0)
      {
        Button2.Attributes["DepId"] = Department.SelectedValue;
        master.Value = NotiData.Rows[0]["master"].ToString();
        email.Value = NotiData.Rows[0]["master_email"].ToString();
        second.Value = NotiData.Rows[0]["second"].ToString();
        email1.Value = NotiData.Rows[0]["second_email"].ToString();
        HiddenField1.Value = NotiData.Rows[0]["other_email"].ToString();
      }
      else
      {
        master.Value = "ไม่มีข้อมูล";
        email.Value = "ไม่มีข้อมูล";
        second.Value = "ไม่มีข้อมูล";
        email1.Value = "ไม่มีข้อมูล";
      }
    }

    private void SetDataOnToolSelect()
    {
      LiteralList.Text = "";
      DataTable DepCode = Model.Database.SelectAttributeByID("code", "dbo.department", Department.SelectedValue);
      DataTable SelectTools = Model.Database.SqlQuery($@"
        SELECT r.register_code, r.code, t.name AS tool_name, p.name AS company_name, r.rang_error, c.date_plan
        FROM dbo.tool_register r
        INNER JOIN dbo.tool t
        ON r.tool_id = t.id
        INNER JOIN dbo.production_company p
        ON r.produc_company_id = p.id
        INNER JOIN dbo.calibration_plan c
        ON r.calibration_plan_id = c.id
        WHERE r.code LIKE '%{DepCode.Rows[0]["code"]}%';
      ");

      for (int i = 0; i < SelectTools.Rows.Count; i++)
      {
        string Value = $"{SelectTools.Rows[i]["register_code"]} |" +
          $" {SelectTools.Rows[i]["code"]} | {SelectTools.Rows[i]["tool_name"]} |" +
          $" {SelectTools.Rows[i]["company_name"]} | {SelectTools.Rows[i]["rang_error"]} |" +
          $" {SelectTools.Rows[i]["date_plan"]}";

        LiteralList.Text += $@"
          <li class='list-twocol'>
            <input class='form-check-input' type='checkbox' name='listtoolselect'
              value='{Value}'/>{Value}
          </li>
        ";
      }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      string dep_id = Button2.Attributes["DepId"];
      string otherEmail = "";
      if (!string.IsNullOrEmpty(HiddenField1.Value))
      {
        otherEmail = $",{HiddenField1.Value}";
      }
      string title = $"{flexDefault1.Value}";
      string recipients = $"{email.Value},{email1.Value}{otherEmail}";
      string body = $@"
          <h2>เรียน {master.Value}</h2>
          <h3>เรื่อง {flexDefault1.Value}</h3>
          <p>โดย ฝ่ายสอบเทียบ</p>
          <p>แผนก สอบเทียบ</p>
          <br>
          <h4>รายละเอียด มีดังนี้</h4>
          <p>...</p>
          <br>
          <a href='/ApprovePage/notification_approve.aspx?dep_id={dep_id}'>อนุมัติ</a>
          <br>
          <h5>จึงเรียนมาเพื่อทราบ</h5>
        ";

      bool cb = Shared.SendEmail.Send(title, recipients, body);
      if (cb)
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('success', 'บันทึกข้อมูลสำเร็จ', 'บันทึกข้อมูลการลงทะเบียนเครื่องมือเรียบร้อย', '/Default.aspx');", true);
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'ไม่สามารถบันทึกข้อมูลการลงทะเบียนเครื่องมือได้', '/Default.aspx');", true);
      }
    }
  }
}