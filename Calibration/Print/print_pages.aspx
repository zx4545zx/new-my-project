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
<body>
  <form id="form1" runat="server" class="container p-2">

    <%-- Header --%>
    <div id="printPageButton" class="mx-auto my-4" style="width: 21cm;">
      <div class="d-flex justify-content-between align-items-end">
        <b class="card p-2">ใบลงทะเบียนเครื่องมือวัด</b>
        <button class="btn btn-outline-secondary text-black" onclick="window.print();">
          <i class="bi bi-printer-fill"></i>&nbsp;Print</button>
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
      <div>วันที่:22/09/2022</div>
      <div>เลขที่:2565/000434</div>
      <br />
      <b>สำหรับผู้ใช้เครื่องมือวัด</b>
      <div>ชื่อผู้ขอ:สวัสดี ปีใหม่</div>
      <div>แผนก:สวัสดี ปีใหม่ ฝ่าย:หน่วยงาน Q.C หมายเลขโทรศัพท์: 2228</div>
      <br />
      <b>ต้องการส่งเครื่องมือวัดมาเพื่อ</b>
      <div>ขึ้นทะเบียนใหม่ ISO,สอบเทียบภายนอก,ไม่มีใบ Cer,ISO 9001</div>
      <br />
      <b>รายการดังต่อไปนี้</b>
      <div>ชื่อเครื่องมือวัด: เครื่องชั่ง รหัส: (หน่วยงานสอบเทียบกำหนดให้) QAC319/505</div>
      <div>ผู้ผลิต: CO รุ่น: hd-1234</div>
      <div>หมายเลขเครื่อง: E1234 ช่วงใช้งาน: 1-100 c</div>
      <div>สถานที่ใช้งาน: ไลน์ผลิต ค่าผิดพลาดที่ยอมรับได้: +-1 c</div>
      <br />
      <b>รายละเอียด</b>
      <div>ใช้งานคู่กับ QC12345</div>
      <br />
      <br />
      <hr />
      <br />
      <div><b>ส่วนของหน่วยสอบเทียบ</b></div>
      <b>รายละเอียด</b>
      <div>ใช้ในไลน์ผลิต สอบเทียบทุกวันที่ 16 ของทุกเดือน</div>
    </div>

  </form>
</body>
</html>

