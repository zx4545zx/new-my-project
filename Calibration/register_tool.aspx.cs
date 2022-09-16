using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class register_tool : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        CallDataAndRender();
        CallISO();
      }
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

    private void CallDataAndRender()
    {
      // cotton
      DataTable Allcot = Model.Database.SelectAll("dbo.cotton");
      for (var i = 0; i < Allcot.Rows.Count; i++)
      {
        Cotton.Items.Insert(i + 1, new ListItem(
          $"{Allcot.Rows[i]["code"]} | {Allcot.Rows[i]["name"]}", $"{Allcot.Rows[i]["id"]}"));
      }

      // factory
      DataTable Allfac = Model.Database.SelectAll("dbo.factory");
      for (var i = 0; i < Allfac.Rows.Count; i++)
      {
        Factory.Items.Insert(i + 1, new ListItem(
          $"{Allfac.Rows[i]["code"]} | {Allfac.Rows[i]["name"]}", $"{Allfac.Rows[i]["id"]}"));
      }

      // department
      DataTable Alldep = Model.Database.SelectAll("dbo.department");
      for (var i = 0; i < Alldep.Rows.Count; i++)
      {
        Department.Items.Insert(i + 1, new ListItem(
          $"{Alldep.Rows[i]["code"]} | {Alldep.Rows[i]["name"]}", $"{Alldep.Rows[i]["id"]}"));
      }

      // meter
      DataTable Allmet = Model.Database.SelectAll("dbo.meter");
      for (var i = 0; i < Allmet.Rows.Count; i++)
      {
        Meter.Items.Insert(i + 1, new ListItem(
          $"{Allmet.Rows[i]["code"]} | {Allmet.Rows[i]["name"]}", $"{Allmet.Rows[i]["id"]}"));
      }

      // Approver
      DataTable Allappr = Model.Database.SelectAll("dbo.approver");
      for (var i = 0; i < Allappr.Rows.Count; i++)
      {
        Approver.Items.Insert(i + 1, new ListItem($"{Allappr.Rows[i]["name"]}", $"{Allappr.Rows[i]["id"]}"));
      }

      // pcompany
      DataTable Allpcom = Model.Database.SelectAll("dbo.production_company");
      for (var i = 0; i < Allpcom.Rows.Count; i++)
      {
        PCompany.Items.Insert(i + 1,
          new ListItem($"{Allpcom.Rows[i]["name"]}", $"{Allpcom.Rows[i]["id"]}"));
      }

      // unit
      DataTable AllUnit = Model.Database.SelectAll("dbo.calibration_unit");
      for (var i = 0; i < AllUnit.Rows.Count; i++)
      {
        Unit1.Items.Insert(i + 1, new ListItem($"{AllUnit.Rows[i]["name"]}", $"{AllUnit.Rows[i]["name"]}"));
        Unit2.Items.Insert(i + 1, new ListItem($"{AllUnit.Rows[i]["name"]}", $"{AllUnit.Rows[i]["name"]}"));
      }
    }

    private string RegCode()
    {
      DataTable regCode = Model.Database.SelectAttributeByCondition(
        "register_code", "dbo.tool_register", $"register_code LIKE '%{Shared.DateTimeTH.GetYear()}%'");
      int nextCount = regCode.Rows.Count + 1;
      string register_code = Shared.DateTimeTH.GetYear() + "/" + nextCount.ToString().PadLeft(6, '0');
      return register_code;
    }

    private string StartUpLoad()
    {
      if (FileUpload1.HasFile)
      {
        string folderPath = "~/ImageStorage/";
        string imgName = FileUpload1.PostedFile.FileName;
        FileUpload1.SaveAs(Server.MapPath(folderPath + imgName));
        return folderPath + imgName;
      }
      else
      {
        return "";
      }
    }

    private string GetCodeForReg(string cotton, string factory, string meter, string dep)
    {
      DataTable cotton_code = Model.Database.SelectAttributeByID("code", "dbo.cotton", cotton);
      DataTable factory_code = Model.Database.SelectAttributeByID("code", "dbo.factory", factory);
      DataTable meter_code = Model.Database.SelectAttributeByID("code", "dbo.meter", meter);
      DataTable dep_code = Model.Database.SelectAttributeByID("code", "dbo.department", dep);

      int rankNumber = 0;
      DataTable last_registrar = Model.Database.SqlQuery("SELECT TOP 1 code FROM dbo.tool_register ORDER BY ID DESC;");

      if (last_registrar.Rows.Count > 0)
      {
        string[] rank = last_registrar.Rows[0]["code"].ToString().Split('/');
        rankNumber = int.Parse(rank[1]) + 1;
      }
      else
      {
        rankNumber++;
      }

      if (cotton_code.Rows.Count > 0 &&
          factory_code.Rows.Count > 0 &&
          meter_code.Rows.Count > 0 &&
          dep_code.Rows.Count > 0)
      {
        string tool_reg_code = $"{cotton_code.Rows[0]["code"]}" +
          $"{factory_code.Rows[0]["code"]}" +
          $"{meter_code.Rows[0]["code"]}" +
          $"{dep_code.Rows[0]["code"]}" +
          $"/{rankNumber}";
        return tool_reg_code;
      }
      else
      {
        return "";
      }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      string Name = name.Value;
      string PhoneNumber = tel.Value;
      string Email = email.Value;
      string CottonValue = Cotton.SelectedValue;
      string FactoryValue = Factory.SelectedValue;
      string MeterValue = Meter.SelectedValue;
      string DepartmentValue = Department.SelectedValue;
      string ApproverValue = Approver.SelectedValue;
      string ObjecttiveValue = CheckBoxValue();
      int Certificate = int.Parse(RedioValue());
      string Tool = ntool.Value;
      string iso_id = Iso.SelectedValue;
      string Company = PCompany.SelectedValue;
      string ModelType = model.Value;
      string ToolNumber = notool.Value;
      string Location = location.Value;
      string Rang = unitRang.Value + Unit1.SelectedValue;
      string Accept_Error = unitError.Value + Unit2.SelectedValue;
      string Detail = floatingTextarea2.Value;
      string ImgUrl = StartUpLoad();
      string code = GetCodeForReg(CottonValue, FactoryValue, MeterValue, DepartmentValue);

      int registrar_id = Model.Database.InsertReturnID(
        "dbo.registrar",
        "name, tel, email, cotton_id, factory_id, metor_id, department_id, approver_id",
        $"'{Name}','{PhoneNumber}','{Email}',{CottonValue},{FactoryValue},{MeterValue},{DepartmentValue},{ApproverValue}"
        );

      int certificate_id = Model.Database.InsertReturnID(
        "dbo.certificate",
        "status",
        $"{Certificate}"
        );

      int tool_id = Model.Database.InsertReturnID(
        "dbo.tool",
        "name,model,code,detail",
        $"'{Tool}','{ModelType}','{ToolNumber}','{Detail}'"
        );

      int plan_id = Model.Database.InsertReturnID(
        "dbo.calibration_plan",
        "status",
        $"{0}"
        );

      bool tool_reg_response = Model.Database.Insert(
       "dbo.tool_register",
       "register_code, code, status, location, objective, accept_error, rang_error, img_url, " +
       "produc_company_id, tool_id, certificate_id, registrar_id, calibration_plan_id, iso_id",
       $"'{RegCode()}','{code}',{1},'{Location}','{ObjecttiveValue}','{Accept_Error}','{Rang}','{ImgUrl}'," +
       $"{Company},{tool_id},{certificate_id},{registrar_id},{plan_id},{iso_id}"
       );

      if (tool_reg_response)
      {
        DataTable Appr = Model.Database.SelectAttributeByID("email,name", "dbo.approver", Approver.SelectedValue);
        string title = "อนุมัติการขึ้นทะเบียนเครื่องมือใหม่";
        string recipients = Appr.Rows[0]["email"].ToString();
        string body = $@"
          <h2>เรียน {Appr.Rows[0]["name"]}</h2>
          <h3>เรื่อง อนุมัติการขึ้นทะเบียนเครื่องมือใหม่</h3>
          <p>โดย ฝ่ายสอบเทียบ</p>
          <p>แผนก สอบเทียบ</p>
          <br>
          <h4>รายละเอียด มีดังนี้</h4>
          <p>ชื่อเครื่องมือ : {ntool.Value}</p>
          <p>รุ่น : {model.Value}</p>
          <p>หมายเลขเครื่อง : {notool.Value}</p>
          <p>บริษัทที่ผลิต : {PCompany.SelectedItem}</p>
          <p>สถานที่ใช้งาน : {location.Value}</p>
          <p>ช่วงใช้งาน : {unitRang.Value}</p>
          <p>ค่าความผิดพลาดที่รับได้ : {unitError.Value}</p>
          <p>รายละเอียด : {floatingTextarea2.Value}</p>
          <br>
          <a href='#'>อนุมัติขึ้นทะเบียนเครื่องมือใหม่</a>
          <br>
          <h5>จึงเรียนมาเพื่อทราบ</h5>
        ";

        bool cb = Shared.SendEmail.Send(title, recipients, body);
        Console.WriteLine(cb);

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