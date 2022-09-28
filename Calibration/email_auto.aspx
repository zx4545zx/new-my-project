<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="email_auto.aspx.cs" Inherits="Calibration.email_auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">ตั้งค่าการแจ้งเตือน Email อัติโนมัติ</h4>
        <div>
          <a href="#" class="btn btn-primary">
            <i class="bi bi-plus-circle-fill"></i>
            ADD</a>
        </div>
      </div>

      <hr />

      <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th width="1%">#</th>
            <th class="text-center">แผนก</th>
            <th class="text-center">รหัส</th>
            <th class="text-center">ชื่อเครื่องมือ</th>
            <th class="text-center">บริษัทผู้ผลิต</th>
            <th class="text-center">รุ่น/พิกัด</th>
            <th class="text-center">วันที่สอบเทียบ</th>
            <th class="text-center">การส่งแจ้งเตือน</th>
            <th class="text-center">สถานะ</th>
            <th class="text-center">Email</th>
            <th width="10%" class="text-center">Action</th>
          </tr>
        </thead>
        <tbody>
          <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
          <tr>
            <th width="1%">#</th>
            <th class="text-center">แผนก</th>
            <th class="text-center">รหัส</th>
            <th class="text-center">ชื่อเครื่องมือ</th>
            <th class="text-center">บริษัทผู้ผลิต</th>
            <th class="text-center">รุ่น/พิกัด</th>
            <th class="text-center">วันที่สอบเทียบ</th>
            <th class="text-center">การส่งแจ้งเตือน</th>
            <th class="text-center">สถานะ</th>
            <th class="text-center">Email</th>
            <th width="10%" class="text-center">Action</th>
          </tr>
        </tfoot>
      </table>

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
