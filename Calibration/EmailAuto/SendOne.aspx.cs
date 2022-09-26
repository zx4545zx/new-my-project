using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Web.UI.WebControls;

namespace Calibration.EmailAuto
{
  public partial class SendOne : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        CreateAutoEmail();
      }
    }

    private void CreateAutoEmail()
    {
      string taskName = "Calibate Send Email Every 1 Month";
      string status = "enable";
      //string status = "disable";

      //TaskDefinition td = TaskService.Instance.NewTask();
      //td.RegistrationInfo.Author = "CalibateAutoEmail";
      //td.RegistrationInfo.Description = "Send email every 1 month";
      //td.Actions.Add(new ExecAction(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe", @"https://localhost:44335/Default.aspx"));
      //Task task = TaskService.Instance.RootFolder.RegisterTaskDefinition(taskName, td);

      TaskService tasksrvc = new TaskService();
      Task task = tasksrvc.FindTask(taskName);
      if (status != "disable")
      {
        task.Enabled = true;
        task.Run();
      }
      else
      {
        task.Enabled = false;
      }
    }
  }
}