using System;
using System.Data;

namespace Calibration.Print
{
  public partial class print_pages : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if (Request.QueryString["id"] == null)
        {
          Response.Redirect("/Default.aspx");
        }

        DataTable dt = Model.Database.SqlQuery($@"
        SELECT r.created_at, tr.register_code,
        r.name AS r_name, d.name AS d_name, d.code AS d_code,
        c.name AS c_name, r.tel, tr.objective,
        cc.status, iso.name AS iso_name, t.name AS t_name,
        tr.code, pc.name AS pc_name, t.model,
        t.code AS t_code, tr.rang_error, tr.location,
        tr.accept_error, t.detail, tr.detail_calibate
        FROM dbo.tool_register tr
        INNER JOIN dbo.registrar r
        ON r.id = tr.registrar_id
        INNER JOIN dbo.tool t
        ON t.id = tr.tool_id
        LEFT OUTER JOIN dbo.iso iso
        ON iso.id = tr.iso_id
        LEFT OUTER JOIN dbo.exam_location el
        ON el.id = tr.exam_location_id
        INNER JOIN dbo.department d
        ON d.id = r.department_id
        INNER JOIN dbo.cotton c
        ON c.id = r.cotton_id
        INNER JOIN dbo.certificate cc
        ON cc.id = tr.certificate_id
        INNER JOIN dbo.production_company pc
        ON pc.id = tr.produc_company_id
        WHERE tr.id = {Request.QueryString["id"]};
        ");

        RenderData(dt);
      }
    }

    private void RenderData(DataTable dt)
    {
      Label1.Text = $"วันที่ : {dt.Rows[0]["created_at"].ToString().Split(' ')[0]}";
      Label2.Text = $"เลขที่ : {dt.Rows[0]["register_code"]}";
      Label3.Text = $"ชื่อผู้ขอ : {dt.Rows[0]["r_name"]}";
      Label4.Text = $"แผนก : {dt.Rows[0]["d_name"]}";
      Label12.Text = $"Code : {dt.Rows[0]["d_code"]}";
      Label13.Text = $"ฝ่าย : {dt.Rows[0]["c_name"]}";
      Label14.Text = $"หมายเลขโทรศัพท์ : {dt.Rows[0]["tel"]}";
      Label5.Text = $"{dt.Rows[0]["objective"]}, {Status2Str(dt.Rows[0]["status"].ToString())}, {dt.Rows[0]["iso_name"]}";
      Label6.Text = $"ชื่อเครื่องมือวัด : {dt.Rows[0]["t_name"]}";
      Label15.Text = $"รหัส : (หน่วยงานสอบเทียบกำหนดให้) {dt.Rows[0]["code"]}";
      Label7.Text = $"ผู้ผลิต : {dt.Rows[0]["pc_name"]}";
      Label16.Text = $"รุ่น : {dt.Rows[0]["model"]}";
      Label8.Text = $"หมายเลขเครื่อง : {dt.Rows[0]["t_code"]}";
      Label17.Text = $"ช่วงใช้งาน : {dt.Rows[0]["rang_error"]}";
      Label9.Text = $"สถานที่ใช้งาน : {dt.Rows[0]["location"]}";
      Label18.Text = $"ค่าผิดพลาดที่ยอมรับได้ : {dt.Rows[0]["accept_error"]}";
      Label10.Text = $"{dt.Rows[0]["detail"]}";
      Label11.Text = $"{dt.Rows[0]["detail_calibate"]}";
    }

    private string Status2Str(string status)
    {
      if (int.Parse(status) == 0)
      {
        return "ไม่มีใบ Certificate";
      }
      else
      {
        return "มีใบ Certificate";
      }
    }
  }
}