<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notification_defective_page_update.aspx.cs" Inherits="Calibration.notification_defective_page_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="m-auto">

        <div class="d-flex justify-content-between align-items-end w-100">
          <div>
            <a href="notification_defective_page.aspx" class="btn btn-secondary">
              <i class="bi bi-arrow-return-left"></i>
              &nbsp;BACK
            </a>
          </div>
          <h4 class="m-0 p-2 text-lg card">ใบแจ้งเตือนบกพร่อง</h4>
        </div>

        <hr />

        <asp:Panel ID="Panel1" DefaultButton="Submit" runat="server">
          <div class="card m-auto w-50" style="min-width: 500px;">
            <div class="card-body">
              <div class="mb-3">
                <label for="floatingTextarea2" class="form-label">รายละเอียดเพิ่มเติม</label>
                <textarea class="form-control" placeholder="รายละเอียด..."
                  id="floatingTextarea2" style="height: 100px" runat="server"></textarea>
              </div>

              <div class="mb-3">
                <label for="Textarea1" class="form-label">หมายเหตุและการดำเนินการ</label>
                <textarea class="form-control" placeholder="หมายเหตุและการดำเนินการ..."
                  id="Textarea1" style="height: 100px" runat="server"></textarea>
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
