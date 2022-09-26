<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notification_approve.aspx.cs" Inherits="Calibration.ApproverNotification.notification_approve" %>

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
    @font-face {
      font-family: Kanit;
      src: url(../Font/Kanit-Regular.ttf);
    }

    *,
    ::before,
    ::after {
      box-sizing: border-box;
      font-family: 'Kanit', sans-serif;
    }
  </style>
</head>
<body>
  <form id="form1" runat="server">
    <div class="container p-3">
      <div class="card">
        <div class="card-header">
          ทะเบียนเครื่องมือวัด
        </div>
        <div class="card-body">
          <table class="table table-striped table-bordered">
            <thead>
              <tr>
                <th>เลขที่ใบแจ้ง</th>
                <th>รหัส</th>
                <th>วันที่แจ้ง</th>
                <th>ชื่อผู้แจ้ง</th>
                <th>แผนก</th>
                <th>เบอร์ติดต่อ</th>
                <th>Email</th>
                <th>สถานะ</th>
                <th>อนุมัติ</th>
              </tr>
            </thead>
            <tbody>
              <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </tbody>
          </table>
        </div>
      </div>

    </div>

    <script type="text/javascript">
      function Approved(url, id) {
        let result = confirm("คุณต้องการจะอนุมัติ ใช่หรือไม่?");
        if (result) {
          fetch(url, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({ id: id })
          })
            .then((response) => response.json())
            .then((data) => {
              console.log(data.d)
              window.location.reload()
            })
            .catch((err) => console.error(err))
        }
      }
    </script>
  </form>
</body>
</html>
