using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class send_notification_completed : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["username"] == null)
      {
        Response.Redirect("Default.aspx");
      }

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

    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
      string ls = ""; // define
      RowData.Text = "";
      string SelectData = Request.Form["listtoolselect"];
      if (!string.IsNullOrEmpty(SelectData))
      {
        string[] ListSelect = SelectData.Split(',');
        for (int i = 0; i < ListSelect.Length; i++)
        {
          string[] Data = ListSelect[i].Split('|');
          ls += Data[0]; // get tools id
          RowData.Text += $"<tr>";
          for (int j = 0; j < Data.Length; j++)
          {
            RowData.Text += $@"
            <td>{Data[j]}</td>
          ";
          }
          RowData.Text += "</tr>";
        }
      }
      Session["tool_id"] = ls; // set session tool id
    }

    protected void Department_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (int.Parse(Department.SelectedValue) > 0)
      {
        SetDataOnTextBox();
        SetDataOnToolSelect();
        Text3.Value = Session["username"].ToString();
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
        Text1.Value = NotiData.Rows[0]["second"].ToString();
        email1.Value = NotiData.Rows[0]["second_email"].ToString();
        HiddenField1.Value = NotiData.Rows[0]["other_email"].ToString();
      }
      else
      {
        master.Value = "ไม่มีข้อมูล";
        email.Value = "ไม่มีข้อมูล";
        Text1.Value = "ไม่มีข้อมูล";
        email1.Value = "ไม่มีข้อมูล";
      }
    }

    private void SetDataOnToolSelect()
    {
      LiteralList.Text = "";
      DataTable DepCode = Model.Database.SelectAttributeByID("code", "dbo.department", Department.SelectedValue);
      DataTable SelectTools = Model.Database.SqlQuery($@"
        SELECT t.id AS tool_id, r.register_code, r.code, t.name AS tool_name, p.name AS company_name, r.rang_error, c.date_plan
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
        string Value = $"{SelectTools.Rows[i]["tool_id"]} |" +
          $" {SelectTools.Rows[i]["register_code"]} |" +
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

    private void SendEmail()
    {
      string otherEmail = "";
      if (!string.IsNullOrEmpty(HiddenField1.Value))
      {
        otherEmail = $",{HiddenField1.Value}";
      }
      string title = $"{flexDefault1.Value}";
      string recipients = $"{email.Value},{email1.Value}{otherEmail}";
      string body = EmailBody(email.Value, email1.Value, otherEmail);

      bool cb = Shared.SendEmail.Send(title, recipients, body);
      cb = true; //////////////////////////////////////////////////////////////////////////////
      if (cb)
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('success', 'ส่งข้อมูลเรียบร้อย', 'ส่งข้อมูลเรียบร้อย', 'administrator.aspx');", true);
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'ไม่สามารถส่งข้อมูลได้', 'administrator.aspx');", true);
      }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      if (Session["tool_id"] != null)
      {
        Session.Remove("tool_id");
      }
      SendEmail();
    }

    private string CheckBoxValue()
    {
      var result = new List<string>();
      if (flexDefault1.Checked == true)
      {
        result.Add(flexDefault1.Value);
      }

      if (flexDefault2.Checked == true)
      {
        result.Add(floatingTextarea2.Value);
      }

      if (result.Count > 0)
      {
        return string.Join(",", result.ToArray());
      }

      return "";
    }

    private string EmailBody(string email, string email1, string otheremail)
    {
      string body = $@"
          <p>แจ้งเตือนการสอบเทียบเครื่องมือวัดเสร็จสิ้น</p>
          <br>
          <p>ถึง:{email}</p>
          <p>สำเนาเรียน:{email1}{otheremail}</p>
          <p>เรื่อง:แจ้งเตือนการสอบเทียบเครื่องมือวัดเสร็จสิ้น</p>
          <p>จาก:แผนกสอบเทียบ</p>
          <br>
          <p>{CheckBoxValue()}</p>
          <br>
          <p>
          <table border=""2"">
          <thead>
          <tr>
          <th>#</th>
          <th>เลขที่ใบลงทะเบียน</th>
          <th>รหัสเครื่องมือ</th>
          <th>ชื่อเครื่องมือ</th>
          <th>ยี่ห้อ</th>
          <th>ช่วงการใช้งาน</th>
          <th>วันที่สอบเทียบ</th>
          </tr>
          </thead>
          <tbody>
          {RowData.Text}
          </tbody>
          </table>
          </p>
          <br>
        ";
      return body;
    }
  }
}