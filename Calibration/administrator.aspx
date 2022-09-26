<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
  CodeBehind="administrator.aspx.cs" Inherits="Calibration.administrator.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100 mb-3">
        <h4 class="m-0 text-lg">
          <i class="bi bi-file-earmark-spreadsheet-fill"></i>&nbsp;ทะเบียนเครื่องมือ</h4>
        <div>
        </div>
      </div>

      <hr />

      <ul class="nav nav-pills nav-fill d-flex gap-2 mb-3 p-2 navbar-light rounded"
        style="background-color: #e3f2fd;">
        <li class="nav-item">
          <a href="send_notification.aspx" class="btn btn-primary w-100">
            <i class="bi bi-envelope-fill"></i>&nbsp;แจ้งเตือนการสอบเทียบ</a>
        </li>
        <li class="nav-item">
          <a href="send_notification_defective.aspx" class="btn btn-warning w-100">
            <i class="bi bi-envelope-exclamation-fill"></i>&nbsp;แจ้งเตือนเครื่องมือวัดบกพร่อง</a>
        </li>
        <li class="nav-item">
          <a href="send_notification_error.aspx" class="btn btn-danger w-100">
            <i class="bi bi-envelope-dash-fill"></i>&nbsp;แจ้งไม่สามารถสอบเทียบได้</a>
        </li>
        <li class="nav-item">
          <a href="send_notification_completed.aspx" class="btn btn-success w-100">
            <i class="bi bi-envelope-check-fill"></i>&nbsp;แจ้งเครื่องมือสอบเทียบเสร็จ</a>
        </li>
      </ul>

      <hr />

      <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th>#</th>
            <th class="text-center">เลขที่ใบลงทะเบียน</th>
            <th class="text-center">รหัส</th>
            <th class="text-center">ชื่อผู้แจ้ง</th>
            <th class="text-center">แผนก</th>
            <th class="text-center">เบอร์ติดต่อ</th>
            <th class="text-center">Email</th>
            <th class="text-center">สถานะ</th>
            <th class="text-center">วันที่สอบเทียบ</th>
            <th class="text-center">สอบเทียบครั้งถัดไป</th>
            <th class="text-center">วันที่ลงทะเบียน</th>
            <th class="text-center">รายละเอียด</th>
            <th width="10%" class="text-center">Action</th>
            <th class="text-center">Print</th>
          </tr>
        </thead>
        <tbody>
          <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
          <tr>
            <th>#</th>
            <th class="text-center">เลขที่ใบลงทะเบียน</th>
            <th class="text-center">รหัส</th>
            <th class="text-center">ชื่อผู้แจ้ง</th>
            <th class="text-center">แผนก</th>
            <th class="text-center">เบอร์ติดต่อ</th>
            <th class="text-center">Email</th>
            <th class="text-center">สถานะ</th>
            <th class="text-center">วันที่สอบเทียบ</th>
            <th class="text-center">สอบเทียบครั้งถัดไป</th>
            <th class="text-center">วันที่ลงทะเบียน</th>
            <th class="text-center">รายละเอียด</th>
            <th width="10%" class="text-center">Action</th>
            <th class="text-center">Print</th>
          </tr>
        </tfoot>
      </table>

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
