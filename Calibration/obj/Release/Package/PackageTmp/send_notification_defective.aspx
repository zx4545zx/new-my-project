<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="send_notification_defective.aspx.cs" Inherits="Calibration.send_notification_defective" %>

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
        <h4 class="m-0 p-2 text-lg card">แจ้งเตือนเครื่องมือวัดบกพร่อง</h4>
      </div>

      <hr />

      <div class="card mx-auto w-100" style="background-color: #f0f9ff;">
        <div class="card-body">
          <h5 class="card-title">
            <i class="bi bi-envelope-fill"></i>
            &nbsp;แจ้งเตือนการสอบเทียบเครื่องมือบกพร่อง</h5>

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
                    placeholder="เรียน..." runat="server" disabled>
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="email" class="form-label px-0">Email : </label>
                  <input type="email" class="form-control" id="email"
                    placeholder="example@cpram.co.th" runat="server" disabled>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">เรื่อง : </label>
                  <input type="text" class="form-control" id="Text2"
                    value="แจ้งเตือนเครื่องมือวัดบกพร่อง" runat="server">
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">จาก : </label>
                  <input type="text" class="form-control" id="Text4"
                    value="แผนกสอบเทียบ" runat="server">
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

            <div class="row">
              <div class="col">
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" name="flexRadioDefault"
                    id="flexDefault1" value="อ่านค่าผิดพลาดปรับได้" runat="server">
                  <label class="form-check-label" for="flexRadioDefault1">
                    อ่านค่าผิดพลาดปรับได้
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" name="flexRadioDefault"
                    id="flexDefault2" value="เสียซ่อมได้" runat="server">
                  <label class="form-check-label" for="flexRadioDefault2">
                    เสียซ่อมได้
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" name="flexRadioDefault"
                    id="Checkbox3" value="อื่นๆ" runat="server">
                  <label class="form-check-label" for="flexRadioDefault2">
                    อื่นๆ
                  </label>
                </div>
              </div>
              <div class="col">
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" name="flexRadioDefault"
                    id="Checkbox1" value="อ่านค่าผิดพลาดปรับไม่ได้" runat="server">
                  <label class="form-check-label" for="flexRadioDefault1">
                    อ่านค่าผิดพลาดปรับไม่ได้
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" name="flexRadioDefault"
                    id="Checkbox2" value="เสียซ่อมไม่ได้ได้" runat="server">
                  <label class="form-check-label" for="flexRadioDefault2">
                    เสียซ่อมไม่ได้ได้
                  </label>
                </div>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col" id="other1">
                <textarea class="form-control" placeholder="อื่นๆ ระบุ..."
                  id="floatingTextarea2" style="height: 100px" runat="server"></textarea>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col" id="other2">
                <label class="form-label" for="Textarea1">รายละเอียดเพิ่มเติม :</label>
                <textarea class="form-control" placeholder="รายละเอียดเพิ่มเติม..."
                  id="Textarea1" style="height: 100px" runat="server"></textarea>
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
                    placeholder="เรียน..." runat="server" disabled>
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="email" class="form-label px-0">Email : </label>
                  <input type="email" class="form-control" id="email1"
                    placeholder="example@cpram.co.th" runat="server" disabled>
                </div>
              </div>
            </div>

            <asp:HiddenField ID="HiddenField1" runat="server" />

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="master" class="form-label px-0">ผู้แจ้ง : </label>
                  <input type="text" class="form-control" id="Text3"
                    value="" runat="server">
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

    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
