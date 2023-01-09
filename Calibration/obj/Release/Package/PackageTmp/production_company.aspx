﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="production_company.aspx.cs" Inherits="Calibration.production_company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">บริษัทผู้ผลิต</h4>
        <div>
          <a href="production_company_new.aspx" class="btn btn-primary">
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
              <th width="1%" class="text-center">Code</th>
              <th>Name</th>
              <th width="10%" class="text-center">Action</th>
            </tr>
          </thead>
          <tbody>
            <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
          </tbody>
          <tfoot>
            <tr>
              <th>ID</th>
              <th>Code</th>
              <th>Name</th>
              <th>Action</th>
            </tr>
          </tfoot>
        </table>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
