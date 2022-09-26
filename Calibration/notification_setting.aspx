<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
  CodeBehind="notification_setting.aspx.cs" Inherits="Calibration.notification_setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">ตั้งค่าการแจ้งเตือน Email</h4>
        <div>
          <a href="notification_new.aspx" class="btn btn-primary">
            <i class="bi bi-plus-circle-fill"></i>
            ADD</a>
        </div>
      </div>

      <hr />

      <table id="example" class="table table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th width="5%" class="text-center">#</th>
            <th width="10%" class="text-center">Action</th>
            <th width="1%" class="text-center">แผนก</th>
            <th>ชื่อผู้รับทราบ</th>
            <th>อีเมลล์ผู้รับทราบ</th>
            <th>ชื่อผู้ที่ต้องการเรียนถึง</th>
            <th>อีเมลล์ผู้ที่ต้องการเรียนถึง</th>
            <th>อีเมลล์อื่นๆ</th>
          </tr>
        </thead>
        <tbody>
          <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
          <tr>
            <th>#</th>
            <th>Action</th>
            <th width="1%" class="text-center">แผนก</th>
            <th>ชื่อผู้รับทราบ</th>
            <th>อีเมลล์ผู้รับทราบ</th>
            <th>ชื่อผู้ที่ต้องการเรียนถึง</th>
            <th>อีเมลล์ผู้ที่ต้องการเรียนถึง</th>
            <th>อีเมลล์อื่นๆ</th>
          </tr>
        </tfoot>
      </table>

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
