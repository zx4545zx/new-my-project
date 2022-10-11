using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class tool_plan_update : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(Request.QueryString["id"]))
      {
        Response.Redirect("/administrator.aspx");
      }

      if (!IsPostBack)
      {
        CallISO();
        CallLocation();
        CallCompany();

        CallToolRegister();
      }
    }

    private DataTable QueryData()
    {
      DataTable AllData = Model.Database.SqlQuery($@"
        SELECT tr.*, r.name, r.email, r.tel, c.status AS c_status, c.code AS c_code,
        c.expiration_date, t.name AS t_name, t.model, t.code AS t_code, t.detail,
        p.rang, p.rang_unit, p.date_plan
        FROM dbo.tool_register tr
        INNER JOIN dbo.registrar r
        ON tr.registrar_id = r.id
        INNER JOIN dbo.certificate c
        ON tr.certificate_id = c.id
        INNER JOIN dbo.tool t
        ON tr.tool_id = t.id
        INNER JOIN dbo.calibration_plan p
        ON tr.calibration_plan_id = p.id
        WHERE tr.id = {Request.QueryString["id"]};
      ");
      return AllData;
    }

    private void CallISO()
    {
      DataTable AllISO = Model.Database.SelectAll("dbo.iso");
      for (var i = 0; i < AllISO.Rows.Count; i++)
      {
        Iso.Items.Insert(i + 1, new ListItem(
          $"{AllISO.Rows[i]["name"]}",
          $"{AllISO.Rows[i]["id"]}"));
      }
    }

    private void CallLocation()
    {
      DataTable AllLocation = Model.Database.SelectAll("dbo.exam_location");
      for (var i = 0; i < AllLocation.Rows.Count; i++)
      {
        LocationCali.Items.Insert(i + 1, new ListItem(
          $"{AllLocation.Rows[i]["name"]}",
          $"{AllLocation.Rows[i]["id"]}"));
      }
    }

    private void CallCompany()
    {
      DataTable AllCompany = Model.Database.SelectAll("dbo.production_company");
      for (var i = 0; i < AllCompany.Rows.Count; i++)
      {
        PCompany.Items.Insert(i + 1, new ListItem(
          $"{AllCompany.Rows[i]["code"]} | {AllCompany.Rows[i]["name"]}",
          $"{AllCompany.Rows[i]["id"]}"));
      }
    }

    private void CallToolRegister()
    {
      DataTable AllData = QueryData();

      imgViewFile.ImageUrl = ImgCheck(AllData.Rows[0]["img_url"].ToString());
      Label1.Text = AllData.Rows[0]["register_code"].ToString();
      Label2.Text = AllData.Rows[0]["code"].ToString();
      Text1.Value = AllData.Rows[0]["name"].ToString();
      email1.Value = AllData.Rows[0]["email"].ToString();
      tel1.Value = AllData.Rows[0]["tel"].ToString();
      ObjectiveCheck(AllData.Rows[0]["objective"].ToString());
      CertificateCheck(AllData.Rows[0]["c_status"].ToString());
      ntool.Value = AllData.Rows[0]["t_name"].ToString();
      PCompany.SelectedValue = AllData.Rows[0]["produc_company_id"].ToString();
      Text2.Value = AllData.Rows[0]["model"].ToString();
      Text3.Value = AllData.Rows[0]["t_code"].ToString();
      location.Value = AllData.Rows[0]["location"].ToString();
      unitRang.Value = AllData.Rows[0]["rang_error"].ToString();
      unitError.Value = AllData.Rows[0]["accept_error"].ToString();
      floatingTextarea2.Value = AllData.Rows[0]["detail"].ToString();
      Iso.SelectedValue = AllData.Rows[0]["iso_id"].ToString();
      LocationCali.SelectedValue = AllData.Rows[0]["exam_location_id"].ToString();
      NoCer.Value = AllData.Rows[0]["c_code"].ToString();
      if (string.IsNullOrEmpty(AllData.Rows[0]["expiration_date"].ToString()))
      {
        DateOut.Value = "";
      }
      else
      {
        DateOut.Value = ConvertSqlDateToHtml(AllData.Rows[0]["expiration_date"].ToString());
      }
      if (string.IsNullOrEmpty(AllData.Rows[0]["date_plan"].ToString()))
      {
        Date1.Value = "";
      }
      else
      {
        Date1.Value = ConvertSqlDateToHtml(AllData.Rows[0]["date_plan"].ToString());
      }
      RoundNumber.Value = AllData.Rows[0]["rang"].ToString();
      RoundUnit.SelectedValue = AllData.Rows[0]["rang_unit"].ToString();
    }

    private string ConvertSqlDateToHtml(string exDate)
    {
      string[] ex_date = exDate.Split(' ')[0].Split('/');
      return (int.Parse(ex_date[2]) - 543).ToString() + "-"
        + ex_date[1].PadLeft(2, '0') + "-" + ex_date[0].PadLeft(2, '0');
    }

    private void ObjectiveCheck(string str)
    {
      if (str.Contains("ขึ้นทะเบียนใหม่ ISO"))
      {
        chiso.Checked = true;
      }
      if (str.Contains("สอบเทียบภายใน"))
      {
        chin.Checked = true;
      }
      if (str.Contains("สอบเทียบภายนอก"))
      {
        chout.Checked = true;
      }
    }

    private void CertificateCheck(string str)
    {
      if (int.Parse(str) == 1)
      {
        flexRadioDefault1.Checked = true;
      }
      else
      {
        flexRadioDefault2.Checked = true;
      }
    }

    private string ImgCheck(string str)
    {
      // https://i.pinimg.com/736x/87/1d/93/871d93996e84672a4d64ff6c0d4f749c.jpg
      // https://i.pinimg.com/564x/c1/0b/94/c10b949b3a6c8c5c4ac82182022b22f1.jpg
      if (string.IsNullOrEmpty(str))
      {
        return "~/Images/default-placeholder.png";
      }
      else
      {
        return str;
      }

    }

    protected void Save_Click(object sender, EventArgs e)
    {
      DataTable AllData = QueryData();

      bool r = Save_Registrar(AllData);
      bool c = Save_Certificate(AllData);
      bool t = Save_Tool(AllData);
      bool p = Save_Plan(AllData);
      bool tr = Save_Tool_Register(AllData);

      if (r && c && t && p && tr)
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('success', 'บันทึกข้อมูลสำเร็จ', 'บันทึกข้อมูลเรียบร้อย', 'administrator.aspx');", true);
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, GetType(),
          "MyScript", "MessageNoti('error', 'เกิดข้อผิดพลาด!!!', 'ไม่สามารถบันทึกข้อมูลได้', 'administrator.aspx');", true);
      }
    }

    private string RedioValue()
    {
      if (flexRadioDefault1.Checked == true)
      {
        return flexRadioDefault1.Value;
      }
      else if (flexRadioDefault2.Checked == true)
      {
        return flexRadioDefault2.Value;
      }
      else
      {
        return "0";
      }
    }

    private string CheckBoxValue()
    {
      var objective = new List<string>();
      if (chiso.Checked == true)
      {
        objective.Add(chiso.Value);
      }

      if (chin.Checked == true)
      {
        objective.Add(chin.Value);
      }

      if (chout.Checked == true)
      {
        objective.Add(chout.Value);
      }

      if (objective.Count > 0)
      {
        return String.Join(",", objective.ToArray());
      }

      return "";
    }

    private bool Save_Registrar(DataTable AllData)
    {
      string registrar_sql = $@"
       UPDATE dbo.registrar
       SET name='{Text1.Value}',email='{email1.Value}',tel='{tel1.Value}'
       WHERE id={AllData.Rows[0]["registrar_id"]};
      ";

      bool cb = Model.Database.SqlQueryExecute(registrar_sql);
      return cb;
    }

    private bool Save_Certificate(DataTable AllData)
    {
      string ex_date = "";
      if (DateOut.Value != "")
      {
        ex_date = $",expiration_date=DATEADD(year, 0, '{DateOut.Value}')";
      }
      string certificate_sql = $@"
       UPDATE dbo.certificate
       SET status={RedioValue()},code='{NoCer.Value}'{ex_date}
       WHERE id={AllData.Rows[0]["certificate_id"]};
      ";

      bool cb = Model.Database.SqlQueryExecute(certificate_sql);
      return cb;
    }

    private bool Save_Tool(DataTable AllData)
    {
      string tool_sql = $@"
       UPDATE dbo.tool
       SET name='{ntool.Value}',model='{Text2.Value}',code='{Text3.Value}',detail='{floatingTextarea2.Value}'
       WHERE id={AllData.Rows[0]["tool_id"]};
      ";

      bool cb = Model.Database.SqlQueryExecute(tool_sql);
      return cb;
    }

    private bool Save_Plan(DataTable AllData)
    {
      string calibration_plan_sql = $@"
       UPDATE dbo.calibration_plan
       SET new_code='{Label2.Text}',rang={RoundNumber.Value},rang_unit='{RoundUnit.SelectedValue}',
        date_plan=Cast('{Date1.Value}' as date),status=1
       WHERE id={AllData.Rows[0]["calibration_plan_id"]};
      ";

      bool cb = Model.Database.SqlQueryExecute(calibration_plan_sql);
      return cb;
    }

    private bool Save_Tool_Register(DataTable AllData)
    {
      string tool_register_sql = $@"
       UPDATE dbo.tool_register
       SET location='{location.Value}', accept_error='{unitError.Value}', rang_error='{unitRang.Value}', 
        detail_calibate='{Textarea1.Value}', produc_company_id={PCompany.SelectedValue}, 
        iso_id={Iso.SelectedValue}, exam_location_id={LocationCali.SelectedValue}, 
        objective='{CheckBoxValue()}'
       WHERE id={AllData.Rows[0]["id"]};
      ";

      bool cb = Model.Database.SqlQueryExecute(tool_register_sql);
      return cb;
    }
  }
}