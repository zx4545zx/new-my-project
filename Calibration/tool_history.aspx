<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tool_history.aspx.cs" Inherits="Calibration.tool_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">
          <i class="bi bi-clipboard2-pulse-fill"></i>
          ประวัติเครื่องมือ</h4>
        <div>
          <button type="button" class="btn btn-sm btn-secondary" data-bs-toggle="collapse"
            data-bs-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
            <i class="bi bi-funnel-fill"></i>
          </button>
        </div>
      </div>

      <!-- Modal -->
      <div class="collapse" id="collapseExample">
        <hr />
        <div class="card mb-3" style="background-color: #f0f9ff;">
          <div class="card-body">

            <div class="mb-3">
              <label for="picker" class="form-label">เดือน/ปี : </label>
              <input type="month" class="form-control" name="picker" id="Picker" runat="server" required />
              <div class="form-check">

                <input class="form-check-input" type="checkbox" value=""
                  id="flexCheckDefault" runat="server" checked>
                <label class="form-check-label" for="flexCheckDefault">
                  ทั้งปี
                </label>
              </div>
            </div>

            <div class="d-flex justify-content-between align-items-center gap-2">
              <div class="mb-3 w-50">
                <label for="SelectCode" class="form-label px-0">รหัสเครื่องมือ : </label>
                <asp:DropDownList ID="SelectCode" runat="Server" CssClass="form-select">
                  <asp:ListItem Text="กรุณาเลือก" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="SelectCode"
                  InitialValue="0" runat="server" ForeColor="Red" />
              </div>

              <div class="mb-3 w-50">
                <label for="SelectTool" class="form-label px-0">เลือกเครื่องมือ : </label>
                <asp:DropDownList ID="SelectTool" runat="Server" CssClass="form-select">
                  <asp:ListItem Text="กรุณาเลือก" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="SelectTool"
                  InitialValue="0" runat="server" ForeColor="Red" />
              </div>
            </div>

            <div class=" d-flex justify-content-end gap-2">
              <button type="button" class="btn btn-secondary" data-bs-toggle="collapse"
                data-bs-target="#collapseExample" aria-expanded="false"
                aria-controls="collapseExample">
                ปิด</button>
              <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary"
                Text="ยืนยัน" />
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

      <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">First</th>
            <th scope="col">Last</th>
            <th scope="col">Handle</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th scope="row">1</th>
            <td>Mark</td>
            <td>Otto</td>
            <td>@mdo</td>
          </tr>
          <tr>
            <th scope="row">2</th>
            <td>Jacob</td>
            <td>Thornton</td>
            <td>@fat</td>
          </tr>
          <tr>
            <th scope="row">3</th>
            <td>Larry</td>
            <td>the Bird</td>
            <td>@twitter</td>
          </tr>
        </tbody>
        <tfoot>
          <tr>
            <th scope="col">#</th>
            <th scope="col">First</th>
            <th scope="col">Last</th>
            <th scope="col">Handle</th>
          </tr>
        </tfoot>
      </table>

    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
