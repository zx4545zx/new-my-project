<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tool_history.aspx.cs" Inherits="Calibration.tool_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">
          <i class="bi bi-clipboard2-pulse-fill"></i>
          ประวัติเครื่องมือ</h4>
        <div>
          <button id="export_button" type="button" class="btn btn-success"
            runat="server" onserverclick="export_button_ServerClick">
            <i class="bi bi-file-spreadsheet-fill"></i>
            &nbsp;REPORT
          </button>
          <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
            <i class="bi bi-search"></i>ค้นหา
          </button>
        </div>
      </div>

      <!-- Modal -->
      <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel"><i class="bi bi-search"></i>ค้นหา</h5>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">

              <div class="mb-3">
                <label for="picker" class="form-label">เดือน/ปี : </label>
                <input type="month" class="form-control" name="picker" id="Picker" runat="server" required />
                <div class="form-check">
                  <div class="mb-3 "></div>
                  <input class="form-check-input" type="checkbox" value=""
                    id="flexCheckDefault" runat="server" checked>
                  <label class="form-check-label" for="flexCheckDefault">
                    ทั้งปี
                  </label>
                </div>
              </div>

              <div class="mb-3">
                <label for="SelectCode" class="form-label px-0">รหัสเครื่องมือ : </label>
                <asp:DropDownList ID="SelectCode" runat="Server" CssClass="form-select">
                  <asp:ListItem Text="กรุณาเลือก" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="SelectCode"
                  InitialValue="0" runat="server" ForeColor="Red" />
              </div>

            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
              <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="ยืนยัน" OnClick="Button2_Click" />
            </div>
          </div>
        </div>
      </div>

      <hr />

      <asp:Panel ID="Panel2" runat="server">
        <div class="row">
          <div class="col-6">
            <div class="card">
              <div class="row">
                <div class="col-6">
                  <img id="ImgCover" src="Images/default-placeholder.png" class="card-img-top rounded" alt="cover" runat="server">
                </div>
                <div class="col-6 d-flex align-items-center">
                  <div class="card-body p-3">
                    <div>
                      <div class="mb-3">
                        <span>เลขที่ขึ้นทะเบียน :&nbsp;</span>
                        <span>
                          <asp:Label ID="RegCode" runat="server" Text="5434343"></asp:Label>
                        </span>
                      </div>

                      <div class="mb-3">
                        <span>รหัส :&nbsp;</span>
                        <span>
                          <asp:Label ID="Code" runat="server" Text="43434343"></asp:Label>
                        </span>
                      </div>

                      <div class="mb-3">
                        <span>ชื่อเครื่องมือ :&nbsp;</span>
                        <span>
                          <asp:Label ID="NameTool" runat="server" Text="434345"></asp:Label>
                        </span>
                      </div>

                      <div class="mb-3">
                        <span>ยี่ห้อ :&nbsp;</span>
                        <span>
                          <asp:Label ID="Company" runat="server" Text="434345"></asp:Label>
                        </span>
                      </div>

                      <div class="mb-3">
                        <span>รุ่น :&nbsp;</span>
                        <span>
                          <asp:Label ID="Model" runat="server" Text="434345"></asp:Label>
                        </span>
                      </div>

                      <div class="mb-3">
                        <span>หมายเลขเครื่อง :&nbsp;</span>
                        <span>
                          <asp:Label ID="ToolNo" runat="server" Text="434345"></asp:Label>
                        </span>
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
      </asp:Panel>

      <asp:Panel ID="Panel1" runat="server">
        <div id="showeTable" style="display: none;">
          <table id="scrollx" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
            <thead>
              <tr>
                <th scope="col" width="1%">#</th>
                <th scope="col" class='text-center'>ค่า Error</th>
                <th scope="col" class='text-center'>สถานะ</th>
                <th scope="col" class='text-center'>วันที่ทำการสอบเทียบ</th>
                <th scope="col">ผู้ทำการสอบเทียบ</th>
                <th scope="col" class='text-center'>สถานะข้อมูล</th>
                <th scope="col">หมายเหตุ</th>
                <th scope="col" class='text-center'>วันที่บันทึก</th>
              </tr>
            </thead>
            <tbody>
              <asp:Literal ID="RowData" runat="server"></asp:Literal>
            </tbody>
          </table>
        </div>
      </asp:Panel>

    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
