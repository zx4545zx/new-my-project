<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prin_notification_page.aspx.cs" Inherits="Calibration.Print.prin_notification_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>

  <!-- bootstrap@5.2.0 -->
  <link href="../Content/bootstrap@5.2.0/bootstrap.min.css" rel="stylesheet" />
  <link href="../Content/bootstrap@5.2.0/bootstrap.min.css" rel="stylesheet" />
  <script src="../Content/bootstrap@5.2.0/bootstrap.bundle.min.js"></script>

  <link href="../Content/bootstrap@5.2.0/sidebars.css" rel="stylesheet" />
  <script src="../Content/bootstrap@5.2.0/sidebars.js"></script>

  <!-- bootstrap-icons@1.9.1 -->
  <link href="../Content/bootstrap-icons@1.9.1/bootstrap-icons.css" rel="stylesheet" />

  <style>
    * {
      font-size: 16px;
      padding: 0;
    }
    th, td {
      padding: 0;
    }
    .table-sm {
      padding: 0;
    }
    table, th, td {
      border: 1px solid lightgray;
      border-collapse: collapse;
      text-align: center;
    }
    @media print {
      #printPageButton {
        display: none;
      }
      .bel{
        position:fixed;
        bottom:0;
      }
    }
  </style>
</head>
<body>
 <form id="form1" runat="server" class="container p-2">

    <%-- Header --%>
    <div id="printPageButton" class="mx-auto my-4" style="width: 21cm;">
      <div class="d-flex justify-content-between align-items-end">
        <b class="p-2 d-flex align-items-end"><i class="bi bi-file-earmark-pdf-fill"></i>
          <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></b>
        <div class="d-flex gap-3" style="width: 18rem;">
          <asp:TextBox ID="TextBox1" CssClass="form-control w-100" runat="server"
            OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
          <button class="btn btn-light btn-lg card" type="button" onclick="window.print();">
          <i class="bi bi-printer-fill"></i></button>
        </div>
       </div>
      <hr />
    </div>

    <%-- Print Page --%>
    <div style="width: 21cm;" class="m-auto">
      <div class="row w-100 mx-0 mb-2">
        <div class="col-4 p-0">
          <img src="../Images/logo.png" alt="logo" style="height: 39px; width: 130px;" />
        </div>
        <div class="col-4 text-center">
          <div><b>บริษัท ซีพีแรม จำกัด</b></div>
          <div><b>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
          </b></div>
        </div>
        <div class="col-4 text-center"></div>
      </div>
      <br />
      <div class="text-end"><asp:Label ID="Label1" runat="server" Text="วันที่ : "></asp:Label></div>
      <br />
      <b>สำหรับผู้ใช้เครื่องมือวัด</b>
      <div><asp:Label ID="Label2" runat="server" Text="เลขที่ : "></asp:Label></div>
      <div><asp:Label ID="Label3" runat="server" Text="ส่งถึง : "></asp:Label></div>
      <div><asp:Label ID="Label9" runat="server" Text="สำเนา : "></asp:Label></div>
      <div><asp:Label ID="Label10" runat="server" Text="ชื่อผู้แจ้ง : "></asp:Label></div>
      <div></div>
      <br />
      <b>รายละเอียด</b>
      <div><asp:Label ID="Label4" runat="server" Text="..."></asp:Label></div>
      <br />
      <b>รายละเอียดเพิ่มเติม</b>
      <div><asp:Label ID="Label5" runat="server" Text="..."></asp:Label></div>
      <br />
      <b>รายละเอียด</b>
      <div><asp:Label ID="Label6" runat="server" Text="..."></asp:Label></div>
      <br />
      <b>วิธีแก้ไข</b>
      <div><asp:Label ID="Label7" runat="server" Text="..."></asp:Label></div>
      <br />
      <b>หมายเหตุ/การดำเนินการ</b>
      <div><asp:Label ID="Label8" runat="server" Text="..."></asp:Label></div>
      <br />
      <table class="w-100">
        <thead>
          <tr>
            <th scope="col">รหัสลงทะเบียน</th>
            <th scope="col">รหัส</th>
            <th scope="col">เครื่องมือ</th>
            <th scope="col">ผู้ผลิต</th>
            <th scope="col">ช่วงใช้งาน</th>
          </tr>
        </thead>
        <tbody>
          <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </tbody>
      </table>
      <br />
      <div class="bel">
        <div><b>
          <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
        </b></div>
        <div><b>วันที่เริ่มใช้งานแบบฟอร์ม : 05-10-2559</b></div>
      </div>
    </div>
  </form>
</body>
</html>
