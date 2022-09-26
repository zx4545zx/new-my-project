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

      <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th>#</th>
            <th class="text-nowrap">เลขที่ใบทะเบียน</th>
            <th class="text-nowrap">รหัส</th>
            <th class="text-nowrap">วันที่แจ้ง</th>
            <th class="text-nowrap">ชื่อผู้แจ้ง</th>
            <th class="text-nowrap">แผนก</th>
            <th class="text-nowrap">เบอร์ติดต่อ</th>
            <th class="text-nowrap">อีเมล</th>
            <th class="text-nowrap">วันที่สอบเทียบ</th>
            <th class="text-nowrap">สถานะ</th>
            <th class="text-nowrap">ผู้อนุมัติ</th>
            <th class="text-nowrap">Action</th>
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
          </tr>
        </tfoot>
      </table>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
