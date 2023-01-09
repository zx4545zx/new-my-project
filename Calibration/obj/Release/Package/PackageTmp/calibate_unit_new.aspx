<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="calibate_unit_new.aspx.cs" Inherits="Calibration.calibate_unit_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="m-auto">

        <div class="d-flex justify-content-between align-items-end w-100">
          <div>
            <a href="calibate_unit.aspx" class="btn btn-secondary">
              <i class="bi bi-arrow-return-left"></i>
              &nbsp;BACK
            </a>
          </div>
          <h4 class="m-0 p-2 text-lg card">หน่วยสอบเทียบ</h4>
        </div>

        <hr />

        <asp:Panel ID="Panel1" DefaultButton="Submit" runat="server">
          <div class="card m-auto w-50" style="min-width: 500px;">
            <div class="card-body">
              <div class="mb-3">
                <label for="code" class="form-label">รหัส</label>
                <asp:TextBox ID="TextBoxCode" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <div class="mb-3">
                <label for="name" class="form-label">ชื่อ</label>
                <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
              <asp:Button ID="Submit" runat="server" CssClass="btn btn-primary float-end"
                Text="Save" OnClick="Submit_Click" />
            </div>
          </div>
        </asp:Panel>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
