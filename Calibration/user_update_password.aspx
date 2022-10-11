<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="user_update_password.aspx.cs" Inherits="Calibration.user_update_password" %>

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
          <h4 class="m-0 p-2 text-lg card">เปลี่ยนรหัสผ่าน</h4>
        </div>

        <hr />

        <asp:Panel ID="Panel1" DefaultButton="Submit" runat="server">
          <div class="card m-auto w-50" style="min-width: 500px;">
            <div class="card-body">

              <div class="mb-3">
                <label for="TextBoxNewPassword" class="form-label">รหัสผ่านใหม่</label>
                <asp:TextBox ID="TextBoxNewPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 ErrorMessage="กรุณากรอกรหัสผ่าน" 
                 ControlToValidate="TextBoxNewPassword"
                 CssClass="text-danger"/>
              </div>

              <div class="mb-3">
                <label for="TextBoxConfirmNewPassword" class="form-label">ยืนยันรหัสผ่านใหม่</label>
                <asp:TextBox ID="TextBoxConfirmNewPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                <div>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                 ErrorMessage="กรุณากรอกรหัสผ่าน" 
                 ControlToValidate="TextBoxConfirmNewPassword"
                 CssClass="text-danger"/>
                </div>
                <div>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" 
                 ControlToValidate="TextBoxConfirmNewPassword"
                 CssClass="text-danger"
                 ControlToCompare="TextBoxNewPassword"
                 ErrorMessage="รหัสผ่านไม่ตรงกัน" />
                </div>
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
