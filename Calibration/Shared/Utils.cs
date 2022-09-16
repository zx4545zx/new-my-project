using System;
using System.Data;
using System.Globalization;

namespace Calibration.Shared
{
  public class Utils
  {
    public static string CheckRound(DataTable data, int i)
    {
      if (string.IsNullOrEmpty(data.Rows[i]["date_plan"].ToString()))
      {
        return "";
      }
      CultureInfo _cultureTHInfo = new CultureInfo("th-TH");
      string strDate = data.Rows[i]["date_plan"].ToString().Split(' ')[0];
      DateTime dateThai = Convert.ToDateTime(strDate, _cultureTHInfo);
      int count = int.Parse(data.Rows[i]["rang"].ToString());

      string NextRound;
      if (data.Rows[i]["rang_unit"].ToString() == "d")
      {
        NextRound = dateThai.AddDays(count).ToString("dd/MM/yyyy", _cultureTHInfo);
      }
      else if (data.Rows[i]["rang_unit"].ToString() == "w")
      {
        NextRound = dateThai.AddDays(count * 7).ToString("dd/MM/yyyy", _cultureTHInfo);
      }
      else if (data.Rows[i]["rang_unit"].ToString() == "m")
      {
        NextRound = dateThai.AddMonths(count).ToString("dd/MM/yyyy", _cultureTHInfo);
      }
      else if (data.Rows[i]["rang_unit"].ToString() == "y")
      {
        NextRound = dateThai.AddYears(count).ToString("dd/MM/yyyy", _cultureTHInfo);
      }
      else
      {
        NextRound = "";
      }

      return NextRound;
    }

    public static (string, string) CheckStatus(DataTable data, int i)
    {
      string Status;
      string Color;
      if (int.Parse(data.Rows[i]["status"].ToString()) == 1)
      {
        Status = "ขึ้นทะเบียนใหม่";
        Color = "text-center bg-primary text-white";
      }
      else if (int.Parse(data.Rows[i]["status"].ToString()) == 2)
      {
        Status = "รออนุมัติ (ขึ้นทะเบียนใหม่)";
        Color = "text-center bg-info";
      }
      else if (int.Parse(data.Rows[i]["status"].ToString()) == 3)
      {
        Status = "อนุมัติแล้ว (ขึ้นทะเบียนใหม่)";
        Color = "text-center bg-success text-white";
      }
      else if (int.Parse(data.Rows[i]["status"].ToString()) == 4)
      {
        Status = "แจ้งบกพร่อง";
        Color = "text-center bg-info";
      }
      else if (int.Parse(data.Rows[i]["status"].ToString()) == 5)
      {
        Status = "แจ้งกลับแล้ว (บกพร่อง)";
        Color = "text-center bg-warning";
      }
      else
      {
        Status = "ปิดใช้งาน";
        Color = "text-center bg-secondary";
      }

      return (Status, Color);
    }
  }
}