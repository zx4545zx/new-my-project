﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class email_auto_add : System.Web.UI.Page
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

    protected void Button2_Click(object sender, EventArgs e)
    {
      int id = Model.Database.InsertReturnID("dbo.email_auto",
        "status,detail,notifier,dep_id,rang_month,start_date",
        $"{DropDownList1.SelectedValue},'{CheckBoxValue()}','{Text3.Value}',{Department.SelectedValue}," +
        $"{Round.Value},Cast('{Date1.Value}' AS DATE)");

      string[] arrData = Session["tool_id"].ToString().Split(' ');
      for (int i = 0; i < arrData.Length; i++)
      {
        Model.Database.Insert("email_auto_tool", "tool_id,email_auto_id", $"{arrData[i]},{id}");
      }
      Session.Remove("tool_id");
      Response.Redirect("email_auto.aspx");
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
  }
}