<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="Calibration.user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">ผู้มีสิทธิ์เข้าใช้งาน</h4>
        <div>
          <a href="user_new.aspx" class="btn btn-primary">
            <i class="bi bi-plus-circle-fill"></i>
            &nbsp;ADD
          </a>
        </div>
      </div>

      <hr />

      <div id="showeTable" class="container" style="display: none;">
        <table id="scrollx" class="table table-striped table-bordered nowrap" style="width: 100%">
          <thead>
            <tr>
              <th width="1%" class="text-center">ID</th>
              <th>Username</th>
              <th>Name</th>
              <th>Email</th>
              <th width="10%" class="text-center">Action</th>
            </tr>
          </thead>
          <tbody>
            <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
          </tbody>
          <tfoot>
            <tr>
              <th class="text-center">ID</th>
              <th>Username</th>
              <th>Name</th>
              <th>Email</th>
              <th class="text-center">Action</th>
            </tr>
          </tfoot>
        </table>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
