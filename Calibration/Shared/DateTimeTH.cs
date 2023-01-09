using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Calibration.Shared
{
  public class DateTimeTH
  {
    public static (string, string, string) GetDay(int count = 0)
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
      DateTime today = DateTime.Now.Date;
      string number = today.AddDays(count).ToString("dd");
      string abb = today.AddDays(count).ToString("ddd");
      string full = today.AddDays(count).ToString("dddd");

      return (number, abb, full);
    }

    public static (string, string, string) GetMonth(int count = 0)
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
      DateTime today = DateTime.Now.Date;
      string number = today.AddMonths(count).ToString("MM");
      string abb = today.AddMonths(count).ToString("MMM");
      string full = today.AddMonths(count).ToString("MMMM");

      return (number, abb, full);
    }

    public static string GetYear(int count = 0)
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
      DateTime today = DateTime.Now.Date;
      string toyear = today.AddYears(count).ToString("yyyy");

      return toyear;
    }

    public static int GetDayInMonth()
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
      int currentYear = DateTime.Now.Year;
      int currentMonth = DateTime.Now.Month;
      int days = DateTime.DaysInMonth(currentYear, currentMonth);

      return days;
    }
  }
}