using System;
using System.Data;
using System.Globalization;

namespace Calibration.Shared
{
  public class Utils
  {
    public static (string, string) CheckStatus(DataTable data, int i)
    {
      string Status;
      string Color;
      if (int.Parse(data.Rows[i]["status"].ToString()) == 1)
      {
        Status = "รออนุมัติ";
        Color = "text-center bg-warning";
      }
      else if (int.Parse(data.Rows[i]["status"].ToString()) == 2)
      {
        Status = "อนุมัติแล้ว";
        Color = "text-center bg-success text-white";
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