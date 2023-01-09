using System;
using System.Data;
using System.Web.Services;

namespace Calibration
{
  public partial class user : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable AllUser = Model.Database.SelectAll("dbo.user_calibate");
        TableRowData.Text = RenderPage(AllUser);
      }
    }

    private string RenderPage(DataTable AllUser)
    {
      string DataRows = string.Empty;
      for (int i = 0; i < AllUser.Rows.Count; i++)
      {
        DataRows += $@"
          <tr>
            <td class=""text-center"">{AllUser.Rows[i]["id"]}</td>
            <td>{AllUser.Rows[i]["username"]}</td>
            <td>{AllUser.Rows[i]["name"]}</td>
            <td>{AllUser.Rows[i]["email"]}</td>
            <td class=""text-center"">
            <div class='btn-group' role='group'>
            <a href='user_update.aspx?id={AllUser.Rows[i]["id"]}&username={AllUser.Rows[i]["username"]}&name={AllUser.Rows[i]["name"]}&email={AllUser.Rows[i]["email"]}' class='btn btn-outline-primary'>แก้ไข</a>
            <button type='button' class='btn btn-danger'onclick=""ConfirmDel('user.aspx/Delete',{AllUser.Rows[i]["id"]})"">ลบ</button>
            </div>
            </td>
          </tr>
        ";
      }

      return DataRows;
    }

    [WebMethod]
    public static bool Delete(string id)
    {
      bool cb = Model.Database.DeleteByID("dbo.user_calibate", id);
      return cb;
    }
  }
}