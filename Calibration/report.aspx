<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="Calibration.report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="d-flex justify-content-between align-items-end w-100 mb-3">
        <h4 class="m-0 text-lg">
          <i class="bi bi-file-earmark-spreadsheet-fill"></i>&nbsp;รายงาน</h4>
        <div>
        </div>
      </div>

      <hr />

      <div class="accordion accordion-flush" id="accordionFlushExample">
        <div class="accordion-item">
          <h2 class="accordion-header" id="flush-headingOne">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
              สรุปรายการทะเบียนเครื่องมือวัด
            </button>
          </h2>
          <div id="flush-collapseOne" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
            <div class="accordion-body">

              <div class="d-flex justify-content-between align-items-end w-100 mb-3">
                <div></div>
                <div>
                  <button id="export_button" type="button" class="btn btn-success"
                    runat="server" onserverclick="export_button_ServerClick">
                    <i class="bi bi-file-spreadsheet-fill"></i>
                    &nbsp;REPORT
                  </button>
                </div>
              </div>

              <hr />

              <table id="regPage" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
                <thead>
                  <tr>
                    <th class="text-center">รหัสแผนก</th>
                    <th class="text-center">ชื่อแผนก</th>
                    <th class="text-center">ชื่อเครื่องมือ</th>
                    <th class="text-center">จำนวน</th>
                  </tr>
                </thead>
                <tbody>
                  <asp:Literal ID="TableRowData" runat="server"></asp:Literal>
                </tbody>
              </table>
            </div>
          </div>
        </div>
        <div class="accordion-item">
          <h2 class="accordion-header" id="flush-headingThree">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseThree" aria-expanded="false" aria-controls="flush-collapseThree">
              สรุปรายการแจ้งเตือนทะเบียนเครื่องมือวัดบกพร่อง
            </button>
          </h2>
          <div id="flush-collapseThree" class="accordion-collapse collapse" aria-labelledby="flush-headingThree" data-bs-parent="#accordionFlushExample">
            <div class="accordion-body">

              <div class="d-flex justify-content-between align-items-end w-100 mb-3">
                <div></div>
                <div>
                  <button id="Button1" type="button" class="btn btn-success"
                    runat="server" onserverclick="Button1_ServerClick">
                    <i class="bi bi-file-spreadsheet-fill"></i>
                    &nbsp;REPORT
                  </button>
                </div>
              </div>

              <hr />

              <table id="defPage" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
                <thead>
                  <tr>
                    <th class="text-center">รหัส</th>
                    <th class="text-center">รหัสแผนก</th>
                    <th class="text-center">ชื่อแผนก</th>
                    <th class="text-center">จำนวนเครื่องมือ</th>
                  </tr>
                </thead>
                <tbody>
                  <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </tbody>
              </table>
            </div>
          </div>
        </div>
        <div class="accordion-item">
          <h2 class="accordion-header" id="flush-headingFour">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseFour" aria-expanded="false" aria-controls="flush-collapseFour">
              สรุปรายการแจ้งเตือนไม่สามารถสอบเทียบเครื่องมือวัดได้
            </button>
          </h2>
          <div id="flush-collapseFour" class="accordion-collapse collapse" aria-labelledby="flush-headingFour" data-bs-parent="#accordionFlushExample">
            <div class="accordion-body">

              <div class="d-flex justify-content-between align-items-end w-100 mb-3">
                <div></div>
                <div>
                  <button id="Button2" type="button" class="btn btn-success"
                    runat="server" onserverclick="Button2_ServerClick">
                    <i class="bi bi-file-spreadsheet-fill"></i>
                    &nbsp;REPORT
                  </button>
                </div>
              </div>

              <hr />

              <table id="errPage" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
                <thead>
                  <tr>
                    <th class="text-center">รหัส</th>
                    <th class="text-center">รหัสแผนก</th>
                    <th class="text-center">ชื่อแผนก</th>
                    <th class="text-center">จำนวนเครื่องมือ</th>
                  </tr>
                </thead>
                <tbody>
                  <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>

    </ContentTemplate>
  </asp:UpdatePanel>





</asp:Content>
