<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notification_defective_page.aspx.cs" Inherits="Calibration.notification_defective_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100 mb-3">
        <h4 class="m-0 text-lg">
          <i class="bi bi-file-earmark-spreadsheet-fill"></i>&nbsp;ใบแจ้งเตือนบกพร่อง</h4>
        <div>
        </div>
      </div>

      <hr />

      <div id="showSpinner">
        <div class="d-flex justify-content-center align-items-center text-primary" style="height: 50vh;">
          <div class="spinner-grow" style="width: 8rem; height: 8rem;" role="status">
            <span class="visually-hidden">Loading...</span>
          </div>
        </div>
      </div>

      <div id="showeTable" class="container" style="display:none;">
        <table id="fixHeader" class="table table-striped table-bordered nowrap" style="width: 100%">
          <thead>
            <tr>
              <th>#</th>
              <th width="10%" class="text-center">สถานะ</th>
              <th class="text-center">เลขที่ใบแจ้ง</th>
              <th class="text-center">ส่งถึง</th>
              <th class="text-center">ผู้อนุมัติ (ฝ่าย)</th>
              <th class="text-center">ชื่อผู้แจ้ง</th>
              <th class="text-center">รายละเอียด</th>
              <th class="text-center">รายละเอียดเพิ่มเติม</th>
              <th class="text-center">หมายเหตุ</th>
              <th class="text-center">วันที่แจ้ง</th>
              <th>Action</th>
              <th>รายชื่อเครื่องมือ</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
          </tbody>
          <tfoot>
            <tr>
              <th>#</th>
              <th width="10%" class="text-center">สถานะ</th>
              <th class="text-center">เลขที่ใบแจ้ง</th>
              <th class="text-center">ส่งถึง</th>
              <th class="text-center">ผู้อนุมัติ (ฝ่าย)</th>
              <th class="text-center">ชื่อผู้แจ้ง</th>
              <th class="text-center">รายละเอียด</th>
              <th class="text-center">รายละเอียดเพิ่มเติม</th>
              <th class="text-center">หมายเหตุ</th>
              <th class="text-center">วันที่แจ้ง</th>
              <th>Action</th>
              <th>รายชื่อเครื่องมือ</th>
              <th></th>
            </tr>
          </tfoot>
        </table>
      </div>

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
