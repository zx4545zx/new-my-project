<%@ Page
  Title="Home Page"
  Language="C#"
  MasterPageFile="~/Site.Master"
  AutoEventWireup="true"
  CodeBehind="Default.aspx.cs"
  Inherits="Calibration.Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="alert alert-warning alert-dismissible fade show" role="alert">
        <i class="bi bi-exclamation-triangle-fill"></i>&nbsp; เว็บไซต์นี้ไม่รองรับการทำงานบน &nbsp;<strong><u>Internet Explorer</u></strong>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
      </div>

      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">
          <i class="bi bi-file-earmark-spreadsheet-fill"></i>
          ทะเบียนเครื่องมือ</h4>
        <div>
          <a href="register_tool.aspx" class="btn btn-primary">
            <i class="bi bi-check2-circle"></i>
            &nbsp;ขึ้นทะเบียนเครื่องมือ
          </a>
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

      <div id="showeTable" style="display: none;">
        <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
          <thead>
            <tr>
              <th>#</th>
              <th class="text-nowrap text-center">เลขที่ใบทะเบียน</th>
              <th class="text-nowrap text-center">รหัส</th>
              <th class="text-nowrap text-center">วันที่แจ้ง</th>
              <th class="text-nowrap text-center">ชื่อผู้แจ้ง</th>
              <th class="text-nowrap text-center">แผนก</th>
              <th class="text-nowrap text-center">เบอร์ติดต่อ</th>
              <th class="text-nowrap text-center">อีเมล</th>
              <th class="text-nowrap text-center">วันที่สอบเทียบ</th>
              <th class="text-nowrap text-center">สถานะ</th>
              <th class="text-nowrap text-center">ผู้อนุมัติ</th>
              <th class="text-nowrap text-center">Action</th>
              <th>รายละเอียด</th>
              <th>ข้อมูลการแจ้งเตือน</th>
              <th>ข้อมูลเครื่องมือวัดบกพร่อง</th>
              <th>ข้อมูลไม่สามารถสอบเทียบได้</th>
            </tr>
          </thead>
          <tbody>
            <asp:Literal ID="RowData" runat="server"></asp:Literal>
          </tbody>
          <tfoot>
            <tr>
              <th>#</th>
              <th>เลขที่ใบทะเบียน</th>
              <th>รหัส</th>
              <th>วันที่แจ้ง</th>
              <th>ชื่อผู้แจ้ง</th>
              <th>แผนก</th>
              <th>เบอร์ติดต่อ</th>
              <th>อีเมล</th>
              <th>วันที่สอบเทียบ</th>
              <th>สถานะ</th>
              <th>ผู้อนุมัติ</th>
              <th>Action</th>
              <th>รายละเอียด</th>
              <th>ข้อมูลการแจ้งเตือน</th>
              <th>ข้อมูลเครื่องมือวัดบกพร่อง</th>
              <th>ข้อมูลไม่สามารถสอบเทียบได้</th>
            </tr>
          </tfoot>
        </table>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
