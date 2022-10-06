<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print_pages.aspx.cs" Inherits="Calibration.Print.print_pages" %>

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
    @media print {
      #printPageButton {
        display: none;
      }
    }
  </style>
</head>
<body onload="window.print();">
  <form id="form1" runat="server" class="container p-2">

    <%-- Header --%>
    <div id="printPageButton" class="mx-auto my-4" style="width: 21cm;">
      <div class="d-flex justify-content-between align-items-end">
        <b class="p-2 d-flex align-items-end"><i class="bi bi-file-earmark-pdf-fill"></i> <span>ใบลงทะเบียนเครื่องมือวัด</span></b>
        <button class="btn btn-light btn-lg card" onclick="window.print();">
          <i class="bi bi-printer-fill"></i></button>
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
          <div><b>ใบลงทะเบียนเครื่องมือวัด</b></div>
        </div>
        <div class="col-4 text-center"></div>
      </div>
      <br />
      <div class="text-end"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
      <div class="text-end"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></div>
      <br />
      <b>สำหรับผู้ใช้เครื่องมือวัด</b>
      <div><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></div>
      <div class="row">
        <div class="col-4"><asp:Label ID="Label4" runat="server" Text="แผนก : "></asp:Label></div>
        <div class="col-2"><asp:Label ID="Label12" runat="server" Text="Code : "></asp:Label></div>
        <div class="col-3"><asp:Label ID="Label13" runat="server" Text="ฝ่าย : "></asp:Label></div>
        <div class="col-3"><asp:Label ID="Label14" runat="server" Text="หมายเลขโทรศัพท์ : "></asp:Label></div>
      </div>
      <br />
      <b>ต้องการส่งเครื่องมือวัดมาเพื่อ</b>
      <div><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></div>
      <br />
      <b>รายการดังต่อไปนี้</b>
      <div class="row">
        <div class="col-6"><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></div>
        <div class="col-6"><asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></div>
      </div>
      <div class="row">
        <div class="col-6"><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></div>
        <div class="col-6"><asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></div>
      </div>
      <div class="row">
        <div class="col-6"><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></div>
        <div class="col-6"><asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></div>
      </div>
      <div class="row">
        <div class="col-6"><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></div>
        <div class="col-6"><asp:Label ID="Label18" runat="server" Text="Label"></asp:Label></div>
      </div>
      <br />
      <b>รายละเอียด</b>
      <div></div>
      <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
      <br />
      <br />
      <hr />
      <br />
      <div><b>ส่วนของหน่วยสอบเทียบ</b></div>
      <b>รายละเอียด</b>
      <div><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></div>
    </div>

  </form>
</body>
</html>

