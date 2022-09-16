<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notification_update.aspx.cs" Inherits="Calibration.notification_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="m-auto">
        <div class="d-flex justify-content-between align-items-end w-100">
          <div>
            <a href="notification_setting.aspx" class="btn btn-secondary">
              <i class="bi bi-arrow-return-left"></i>
              &nbsp;BACK
            </a>
          </div>
          <h4 class="m-0 p-2 text-lg card">ตั้งค่าการแจ้งเตือน Email ทั่วไป</h4>
        </div>

        <hr />

        <div class="card mx-auto w-100">
          <div class="card-body">
            <div class="mx-5">
              <div class="row">
                <div class="col me-4">
                  <div class="mb-3 row">
                    <label class="form-label px-0">แผนก : </label>
                    <asp:DropDownList ID="DropList" runat="Server" CssClass="form-select">
                      <asp:ListItem Text="กรุณาเลือกแผนก" Value="0" />
                    </asp:DropDownList>
                  </div>
                </div>
                <div class="col"></div>
              </div>

              <div class="row">
                <div class="col me-4">
                  <div class="mb-3 row">
                    <label for="name" class="form-label px-0">ชื่อผู้รับทราบ : </label>
                    <input type="text" class="form-control" id="name"
                      placeholder="ex : xxx xxx" runat="server">
                  </div>
                </div>

                <div class="col">
                  <div class="mb-3 row">
                    <label for="email" class="form-label px-0">Email ผู้รับทราบ : </label>
                    <input type="email" class="form-control" id="email"
                      placeholder="ex : example@cpram.co.th" runat="server">
                  </div>
                </div>
              </div>

              <div class="row">
                <div class="col me-4">
                  <div class="mb-3 row">
                    <label for="sname" class="form-label px-0">ชื่อผู้ที่ต้องการเรียนถึง : </label>
                    <input type="text" class="form-control" id="sname"
                      placeholder="ex : xxx xxx" runat="server">
                  </div>
                </div>

                <div class="col">
                  <div class="mb-3 row">
                    <label for="semail" class="form-label px-0">Email ผู้ที่ต้องการเรียนถึง : </label>
                    <input type="email" class="form-control" id="semail"
                      placeholder="ex : example@cpram.co.th" runat="server">
                  </div>
                </div>
              </div>

              <div class="row mb-3">
                <div class="col p-0">
                  <label class="form-label px-0">Email อื่นๆ : </label>
                  <textarea class="form-control"
                    placeholder="ex : example@cpram.co.th,example2@cpram.co.th,example3@cpram.co.th"
                    id="floatingTextarea2" style="height: 100px" runat="server"></textarea>
                </div>
              </div>

              <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
              <div class="text-end">
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-lg"
                  Text="Save" OnClick="Button2_Click" />
              </div>
            </div>
          </div>
        </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
