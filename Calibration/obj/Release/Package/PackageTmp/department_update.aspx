<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
  CodeBehind="department_update.aspx.cs" Inherits="Calibration.department_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="m-auto">

        <div class="d-flex justify-content-between align-items-end w-100">
          <div>
            <a href="department.aspx" class="btn btn-secondary">
              <i class="bi bi-arrow-return-left"></i>
              &nbsp;BACK
            </a>
          </div>
          <h4 class="m-0 p-2 text-lg card">แผนก</h4>
        </div>

        <hr />

        <asp:Panel ID="Panel1" DefaultButton="Submit" runat="server">
          <div class="card w-50 m-auto">
            <div class="card-body">
              <div class="mb-3">
                <label for="TextBoxCode" class="form-label">รหัส</label>
                <asp:TextBox ID="TextBoxCode" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <div class="mb-3">
                <label for="TextBoxName" class="form-label">ชื่อ</label>
                <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
              <asp:Button ID="Submit" runat="server" CssClass="btn btn-primary float-end"
                Text="Update" OnClick="Submit_Click" />
            </div>
          </div>
        </asp:Panel>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
