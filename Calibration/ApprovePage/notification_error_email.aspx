<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notification_error_email.aspx.cs" Inherits="Calibration.ApprovePage.notification_error_email" %>

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

  <!-- jquery@3.5.1 -->
  <script src="../Content/jquery@3.5.1/jquery-3.5.1.js"></script>

  <!-- datatables@1.12.1 -->
  <link href="../Content/datatables@1.12.1/dataTables.bootstrap5.min.css" rel="stylesheet" />
  <link href="../Content/datatables@1.12.1/responsive.bootstrap.min.css" rel="stylesheet" />
  <link href="../Content/datatables@1.12.1/buttons.dataTables.min.css" rel="stylesheet" />

  <script src="../Content/datatables@1.12.1/jquery.dataTables.min.js"></script>
  <script src="../Content/datatables@1.12.1/dataTables.bootstrap5.min.js"></script>
  <script src="../Content/datatables@1.12.1/dataTables.fixedHeader.min.js"></script>
  <script src="../Content/datatables@1.12.1/dataTables.responsive.min.js"></script>

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
    <div>
      <div class="container p-3">
        <div class="card">
          <div class="card-header">
            แจ้งเตือนไม่สามารถสอบเทียบเครื่องมือวัดได้
          </div>
          <div class="card-body">
            <table id="example" class="table table-striped table-bordered">
              <thead>
                <tr>
                  <th>#</th>
                  <th class="text-center text-nowrap">แจ้งข้อมูลกลับ</th>
                  <th class="text-center text-nowrap">เลขที่ใบแจ้ง</th>
                  <th class="text-center text-nowrap">ส่งถึง</th>
                  <th class="text-center text-nowrap">ผู้อนุมัติ (ฝ่าย)</th>
                  <th class="text-center text-nowrap">ชื่อผู้แจ้ง</th>
                  <th class="text-center text-nowrap">รายละเอียด</th>
                  <th class="text-center text-nowrap">รายละเอียดเพิ่มเติม</th>
                  <th class="text-center text-nowrap">วันที่แจ้ง</th>
                  <th class="text-nowrap">รายชื่อเครื่องมือ</th>
                </tr>
              </thead>
              <tbody>
                <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>

    <script type="text/javascript">
      function Approved(url, id) {
        let comment = prompt("รายละเอียด : ");
        let solution = prompt("วิธีแก้ไข : ");

        if (comment && solution) {
          fetch(url, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({ data: `${id},${comment},${solution}` })
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
