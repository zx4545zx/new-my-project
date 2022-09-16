﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calibration
{
  public partial class location_update : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        TextBoxName.Text = Request.QueryString["name"];
      }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      string statement = $"name='{TextBoxName.Text}'";
      bool cb = Model.Database.UpdateByID("dbo.exam_location", statement, id);
      if (cb == true)
      {
        Response.Redirect("/location.aspx");
      }
      else
      {
        ErrorMessage.Text = (
          "<div class='alert alert-danger' role='alert'><b>เกิดข้อผิดพลาด!!! </b> ไม่สามารถแก้ไขข้อมูลได้</div>"
          );
      }
    }
  }
}