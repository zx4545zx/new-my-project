<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="send_notification_error.aspx.cs" Inherits="Calibration.send_notification_error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100">
        <div>
          <a href="administrator.aspx" class="btn btn-secondary">
            <i class="bi bi-arrow-return-left"></i>
            &nbsp;BACK
          </a>
        </div>
        <h4 class="m-0 p-2 text-lg card">แจ้งไม่สามารถสอบเทียบได้</h4>
      </div>

      <hr />

      <div class="card mx-auto w-100" style="background-color: #f0f9ff;">
        <div class="card-body">
          <h5 class="card-title">
            <i class="bi bi-envelope-fill"></i>
            &nbsp;แจ้งเตือนไม่สามารถสอบเทียบได้</h5>

          <hr />

          <div class="mx-5">
            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">แผนก : </label>
                  <asp:DropDownList ID="Department" runat="Server" CssClass="form-select"
                    AutoPostBack="true" OnSelectedIndexChanged="Department_SelectedIndexChanged">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Department"
                    InitialValue="0" runat="server" ForeColor="Red" />
                </div>
              </div>
              <div class="col"></div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">เรียน : </label>
                  <input type="text" class="form-control" id="master"
                    placeholder="เรียน..." runat="server" required disabled>
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="email" class="form-label px-0">Email : </label>
                  <input type="email" class="form-control" id="email"
                    placeholder="example@cpram.co.th" runat="server" required disabled>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">เรื่อง : </label>
                  <input type="text" class="form-control" id="Text2"
                    value="แจ้งไม่สามารถสอบเทียบได้" runat="server" required>
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">จาก : </label>
                  <input type="text" class="form-control" id="Text4"
                    value="แผนกสอบเทียบ" runat="server" required>
                </div>
              </div>
            </div>

            <hr />

            <div class="row">
              <div class="col">
                <div>
                  <i class="bi bi-info-circle"></i>
                  ข้อบกพร่อง
                </div>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col">
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" name="flexDefault"
                    id="flexDefault1" value="ไม่สามารถดำเนินการสอบเทียบตามวันเวลาสอบเทียบได้" runat="server" checked>
                  <label class="form-check-label" for="flexRadioDefault1">
                    ไม่สามารถดำเนินการสอบเทียบตามวันเวลาสอบเทียบได้
                  </label>
                </div>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col" id="other1">
                <label class="form-label" for="floatingTextarea2">
                  เนื่องจาก :
                </label>
                <textarea class="form-control" placeholder="ระบุ..."
                  id="floatingTextarea2" style="height: 100px" runat="server"></textarea>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col">
                <button class="btn btn-primary" type="button"
                  data-bs-toggle="modal" data-bs-target="#fullModal">
                  เลือกเครื่องมือ</button>
              </div>
            </div>

            <table class="table table-bordered bg-light">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>เลขที่ใบลงทะเบียน</th>
                  <th>รหัสเครื่องมือ</th>
                  <th>ชื่อเครื่องมือ</th>
                  <th>ยี่ห้อ</th>
                  <th>ช่วงการใช้งาน</th>
                  <th>วันที่สอบเทียบ</th>
                </tr>
              </thead>
              <tbody>
                <asp:Literal ID="RowData" runat="server"></asp:Literal>
              </tbody>
            </table>

            <hr />

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="second" class="form-label px-0">ผู้รับทราบ : </label>
                  <input type="text" class="form-control" id="second"
                    placeholder="เรียน..." runat="server" required disabled>
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="email" class="form-label px-0">Email : </label>
                  <input type="email" class="form-control" id="email1"
                    placeholder="example@cpram.co.th" runat="server" required disabled>
                </div>
              </div>
            </div>

            <asp:HiddenField ID="HiddenField1" runat="server" />

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">ผู้แจ้ง : </label>
                  <input type="text" class="form-control" id="Text3"
                    value="" runat="server" required>
                </div>
              </div>
              <div class="col"></div>
            </div>

            <hr />

          </div>

          <div class="mx-5 text-end">
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-lg"
              Text="Send Email" OnClick="Button2_Click" />
          </div>
        </div>
      </div>


      <div class="modal ld ld-slide-ttb-in" id="fullModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-fullscreen">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">เลือกเครื่องมือ</h5>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
              <ul class="twocol">
                <asp:Literal ID="LiteralList" runat="server"></asp:Literal>
              </ul>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">ปิด</button>
              <button type="button" class="btn btn-primary" data-bs-dismiss="modal" onserverclick="Unnamed_ServerClick" runat="server">ยืนยัน</button>
            </div>
          </div>
        </div>
      </div>

      <script type="text/javascript">
        function showOther() {
          document.getElementById("other1").hidden = false;
        }
      </script>
    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
