using Calibration.Model;
using KClass;

namespace Calibration.Shared
{
  public class SendEmail
  {
    public static bool Send(string title, string recipients, string body)
    {
      DBClass db = Database.Connection();
      string sqlString = UseSQLString(title, recipients, body);
      bool response = db.QueryExecuteNonQuery(sqlString);

      return response;
    }

    private static string UseSQLString(string title, string recipients, string body)
    {
      string SqlString = ($@"
        DECLARE @TitleBar VARCHAR(MAX);
        SET @TitleBar = '{title}' 
        EXEC msdb.dbo.sp_send_dbmail 
        @profile_name = 'datafac',
        @recipients = '{recipients}',
        @subject = @TitleBar,
        @body = '{body}',
        @body_format = 'HTML';
        ");
      return SqlString;
    }

  }
}