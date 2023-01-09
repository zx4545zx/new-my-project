<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notification_approve.aspx.cs" Inherits="Calibration.ApproverNotification.notification_approve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <contenttemplate>



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


    </contenttemplate>
  </asp:UpdatePanel>
</asp:Content>

