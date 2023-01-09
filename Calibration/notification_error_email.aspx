<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notification_error_email.aspx.cs" Inherits="Calibration.ApprovePage.notification_error_email" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>



      <div>
        <div class="container p-3">
          <div class="card">
            <div class="card-header">
              แจ้งเตือนไม่สามารถสอบเทียบเครื่องมือวัดได้
            </div>
            <div class="card-body">
              <table id="fixHeader" class="table table-striped table-bordered">
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



    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
