<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tool_history.aspx.cs" Inherits="Calibration.tool_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">
          <i class="bi bi-clipboard2-pulse-fill"></i>
          ประวัติเครื่องมือ</h4>
        <div>
          <button type="button" class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#Filter">
            <i class="bi bi-funnel-fill"></i>
          </button>
        </div>
      </div>

      <!-- Modal -->
      <div class="modal fade" id="Filter" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-body">

              <%--<div class="mb-3">
                <label for="SelectYear" class="form-label">ปี : </label>
                <select class="form-select" id="SelectYear">
                  <option selected value="0">กรุณาเลือก</option>
                  <option value="2565">2565</option>
                  <option value="2567">2567</option>
                  <option value="2568">2568</option>
                  <option value="2569">2569</option>
                  <option value="2570">2570</option>
                </select>
              </div>--%>

              <div class="mb-3">
                <label for="SelectYear" class="form-label">เดือน/ปี : </label>
                <input class="form-control" type="month" />
              </div>

              <div class="mb-3">
                <label for="SelectCode" class="form-label">รหัสเครื่องมือ : </label>
                <select class="form-select" id="SelectCode">
                  <option selected value="0">กรุณาเลือก</option>
                  <option value="1">One</option>
                  <option value="2">Two</option>
                  <option value="3">Three</option>
                </select>
              </div>

            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">ปิด</button>
              <button type="button" class="btn btn-primary">ยืนยัน</button>
            </div>
          </div>
        </div>
      </div>

      <hr />

      <div class="row">

        <div class="col-6">
          <div class="card">
            <div class="row">
              <div class="col-6">
                <img src="Images/default-placeholder.png" class="card-img-top" alt="cover">
              </div>
              <div class="col-6 d-flex align-items-center">
                <div class="card-body p-3">
                  <div>
                    <div class="mb-3">
                      <span>เลขที่ขึ้นทะเบียน :&nbsp;</span>
                      <span>2565/000001</span>
                    </div>

                    <div class="mb-3">
                      <span>รหัส :&nbsp;</span>
                      <span>DC1100/12</span>
                    </div>

                    <div class="mb-3">
                      <span>ชื่อเครื่องมือ :&nbsp;</span>
                      <span>เครื่องชั่ง</span>
                    </div>

                    <div class="mb-3">
                      <span>ยี่ห้อ :&nbsp;</span>
                      <span>CP</span>
                    </div>

                    <div class="mb-3">
                      <span>รุ่น :&nbsp;</span>
                      <span>654651321</span>
                    </div>

                    <div class="mb-3">
                      <span>หมายเลขเครื่อง :&nbsp;</span>
                      <span>165516</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="col-6">
          <canvas id="myChart"></canvas>
        </div>

      </div>

      <hr />

    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
