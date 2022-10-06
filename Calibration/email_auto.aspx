<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="email_auto.aspx.cs" Inherits="Calibration.email_auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">ตั้งค่าการแจ้งเตือน Email อัติโนมัติ</h4>
        <div>
          <a href="email_auto_add.aspx" class="btn btn-primary">
            <i class="bi bi-plus-circle-fill"></i>
            ADD</a>
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

      <div id="showeTable" class="container" style="display: none;">
        <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
          <thead>
            <tr>
              <th width="1%">#</th>
              <th class="text-center">แผนก</th>
              <th class="text-center">วันที่สอบเทียบ</th>
              <th class="text-center">การส่งแจ้งเตือน</th>
              <th class="text-center">Email</th>
              <th class="text-center">สถานะ</th>
              <th width="10%" class="text-center">Action</th>
              <th class="text-center">รายชื่อเครื่องมือ</th>
            </tr>
          </thead>
          <tbody>
            <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
          </tbody>
          <tfoot>
            <tr>
              <th width="1%">#</th>
              <th class="text-center">แผนก</th>
              <th class="text-center">วันที่สอบเทียบ</th>
              <th class="text-center">การส่งแจ้งเตือน</th>
              <th class="text-center">Email</th>
              <th class="text-center">สถานะ</th>
              <th width="10%" class="text-center">Action</th>
              <th class="text-center">รายชื่อเครื่องมือ</th>
            </tr>
          </tfoot>
        </table>
      </div>

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
