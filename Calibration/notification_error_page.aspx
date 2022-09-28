<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notification_error_page.aspx.cs" Inherits="Calibration.notification_error_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100 mb-3">
        <h4 class="m-0 text-lg">
          <i class="bi bi-file-earmark-spreadsheet-fill"></i>&nbsp;ใบแจ้งไม่สามารถสอบเทียบได้</h4>
        <div>
        </div>
      </div>

      <hr />

      <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th>#</th>
            <th class="text-center">เลขที่ใบแจ้ง</th>
            <th class="text-center">ส่งถึง</th>
            <th class="text-center">ผู้อนุมัติ (ฝ่าย)</th>
            <th class="text-center">ชื่อผู้แจ้ง</th>
            <th class="text-center">รายละเอียด</th>
            <th class="text-center">เนื่องจาก</th>
            <th width="10%" class="text-center">สถานะ</th>
            <th class="text-center">วันที่แจ้ง</th>
             <th>Action</th>
            <th>รายชื่อเครื่องมือ</th>
          </tr>
        </thead>
        <tbody>
          <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
          <tr>
            <th>#</th>
            <th class="text-center">เลขที่ใบแจ้ง</th>
            <th class="text-center">ส่งถึง</th>
            <th class="text-center">ผู้อนุมัติ (ฝ่าย)</th>
            <th class="text-center">ชื่อผู้แจ้ง</th>
            <th class="text-center">รายละเอียด</th>
            <th class="text-center">เนื่องจาก</th>
            <th width="10%" class="text-center">สถานะ</th>
            <th class="text-center">วันที่แจ้ง</th>
            <th>Action</th>
            <th>รายชื่อเครื่องมือ</th>
          </tr>
        </tfoot>
      </table>

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
