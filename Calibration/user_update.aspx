<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="user_update.aspx.cs" Inherits="Calibration.user_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="m-auto">

        <div class="d-flex justify-content-between align-items-end w-100">
          <div>
            <a href="user.aspx" class="btn btn-secondary">
              <i class="bi bi-arrow-return-left"></i>
              &nbsp;BACK
            </a>
          </div>
          <h4 class="m-0 p-2 text-lg card">ผู้มีสิทธิ์เข้าใช้งาน</h4>
        </div>

        <hr />

        <asp:Panel ID="Panel1" DefaultButton="Submit" runat="server">
          <div class="card m-auto w-50" style="min-width: 500px;">
            <div class="card-body">

              <div class="mb-3">
                <label for="TextBoxUserName" class="form-label">Username</label>
                <asp:TextBox ID="TextBoxUserName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <div class="mb-3">
                <label for="TextBoxName" class="form-label">Name</label>
                <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <div class="mb-3">
                <label for="TextBoxEmail" class="form-label">Email</label>
                <asp:TextBox ID="TextBoxEmail" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>

              <asp:Button ID="Button1" runat="server" CssClass="btn btn-link float-start" Text="เปลี่ยนรหัสผ่าน" OnClick="Button1_Click"  />
              <asp:Button ID="Submit" runat="server" CssClass="btn btn-primary float-end"
                Text="Save" OnClick="Submit_Click" />
            </div>
          </div>
        </asp:Panel>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
