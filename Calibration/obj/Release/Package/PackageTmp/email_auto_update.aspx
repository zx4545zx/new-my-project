<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="email_auto_update.aspx.cs" Inherits="Calibration.email_auto_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100">
        <div>
          <a href="email_auto.aspx" class="btn btn-secondary">
            <i class="bi bi-arrow-return-left"></i>
            &nbsp;BACK
          </a>
        </div>
        <h4 class="m-0 p-2 text-lg card flex-row"><i class="bi bi-bell-fill"></i>&nbsp;การแจ้งเตือนแบบอัตโนมัติ</h4>
      </div>

      <hr />

      <div class="card mx-auto w-100" style="background-color: #f0f9ff;">
        <div class="card-body">
          <h5 class="card-title">
            <i class="bi bi-envelope-fill"></i>
            &nbsp;แจ้งเตือนการสอบเทียบเครื่องมือวัด</h5>

          <hr />

          <div class="mx-5">
            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">แผนก : </label>
                  <asp:DropDownList ID="Department" runat="Server" CssClass="form-select" AutoPostBack="true"
                    OnSelectedIndexChanged="Department_SelectedIndexChanged">
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
                  <input type="text" class="form-control" id="Text1"
                    value="แจ้งเตือนการสอบเทียบเครื่องมือวัด" runat="server" required>
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

            <div class="row mb-3">
              <div class="col">
                <div>
                  <i class="bi bi-info-circle"></i>
                  กรุณาส่งเครื่องมือมาทำการสอบเทียบ หากมีข้อขัดข้องประการใด โปรดติดต่อมาที่แผนกสอบเทียบ
                </div>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col" id="other1">
                <label for="master" class="form-label px-0">รายละเอียด : </label>
                <textarea class="form-control" placeholder="รายละเอียด..."
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
                  <th class="text-center">ID</th>
                  <th class="text-center">เลขที่ใบลงทะเบียน</th>
                  <th class="text-center">รหัสเครื่องมือ</th>
                  <th class="text-center">ชื่อเครื่องมือ</th>
                  <th class="text-center">ยี่ห้อ</th>
                  <th class="text-center">ช่วงการใช้งาน</th>
                  <th class="text-center">วันที่สอบเทียบ</th>
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
                  <label for="email1" class="form-label px-0">Email : </label>
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

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">วันที่แจ้งเตือน : </label>
                  <input type="date" class="form-control" id="Date1" runat="server" required>
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">รอบการแจ้งเตือน : </label>
                  <div class="input-group mb-3">
                    <span class="input-group-text">ทุก</span>
                    <input type="number" class="form-control" id="Round" runat="server" required>
                    <span class="input-group-text">เดือน</span>
                  </div>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-check-label" for="DropDownList1">สถานะ</label>
                  <asp:DropDownList ID="DropDownList1" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="เปิดใช้งาน" Value="1" />
                    <asp:ListItem Text="ปิดใช้งาน" Value="0" />
                  </asp:DropDownList>
                </div>
              </div>
              <div class="col"></div>
            </div>
          </div>

          <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>

          <div class="mx-5 text-end">
            <asp:Button ID="Button2" runat="server" DepId="" CssClass="btn btn-primary btn-lg"
              Text="บันทึก" OnClick="Button2_Click" />
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
              <button type="button" class="btn btn-primary" data-bs-dismiss="modal" runat="server"
                onserverclick="Unnamed_ServerClick">
                ยืนยัน</button>
            </div>
          </div>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
