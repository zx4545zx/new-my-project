<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register_tool.aspx.cs" Inherits="Calibration.register_tool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="card mx-auto w-100" style="background-color: #f0f9ff;">
        <div class="card-body">
          <h5 class="card-title">
            <i class="bi bi-check2-circle"></i>
            &nbsp;ขึ้นทะเบียนเครื่องมือ</h5>

          <hr />

          <div class="mx-5">
            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="name" class="form-label px-0">ชื่อผู้ขอ : </label>
                  <input type="text" class="form-control" id="name"
                    placeholder="กรุณากรอกชื่อ และนามสกุล..." runat="server" required>
                </div>
              </div>
              <div class="col"></div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="email" class="form-label px-0">Email : </label>
                  <input type="email" class="form-control" id="email"
                    placeholder="ex : example@cpram.co.th" runat="server" required>
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="tel" class="form-label px-0">เบอร์ติดต่อ : </label>
                  <input type="tel" class="form-control" id="tel"
                    placeholder="ex : xxx, xxx" runat="server" required>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">ฝ่ายต้นสังกัด : </label>
                  <asp:DropDownList ID="Cotton" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Cotton"
                    InitialValue="0" runat="server" ForeColor="Red" />
                </div>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">โรงงาน : </label>
                  <asp:DropDownList ID="Factory" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Factory"
                    InitialValue="0" runat="server" ForeColor="Red" />
                </div>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">แผนก : </label>
                  <asp:DropDownList ID="Department" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Department"
                    InitialValue="0" runat="server" ForeColor="Red" />
                </div>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">เครื่องมือวัด : </label>
                  <asp:DropDownList ID="Meter" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Meter"
                    InitialValue="0" runat="server" ForeColor="Red" />
                </div>
              </div>

              <div class="col">
                <div class="mb-3 row">
                  <label class="form-label px-0">ผู้อนุมัติ (ฝ่าย) : </label>
                  <asp:DropDownList ID="Approver" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Approver"
                    InitialValue="0" runat="server" ForeColor="Red" />
                </div>
              </div>
            </div>

            <hr />

            <div class="row mb-3">
              <div class="col">
                <h6>ต้องการส่งเครื่องมือวัดมาเพื่อ</h6>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="ขึ้นทะเบียนใหม่ ISO" id="chiso" runat="server">
                  <label class="form-check-label" for="chiso">
                    ขึ้นทะเบียนใหม่ ISO
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="สอบเทียบภายใน" id="chin" runat="server">
                  <label class="form-check-label" for="chin">
                    สอบเทียบภายใน
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="สอบเทียบภายนอก" id="chout" runat="server">
                  <label class="form-check-label" for="chout">
                    สอบเทียบภายนอก
                  </label>
                </div>
              </div>

              <div class="col">
                <h6>มีใบ Certificate หรือไม่?</h6>
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1" value="1" runat="server"
                    required>
                  <label class="form-check-label" for="flexRadioDefault1">
                    มี
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="0" runat="server"
                    required>
                  <label class="form-check-label" for="flexRadioDefault2">
                    ไม่มี
                  </label>
                </div>
              </div>
            </div>


            <div class="row">
              <div class="col">
                <label class="form-label px-0">ISO : </label>
                <asp:DropDownList ID="Iso" runat="Server" CssClass="form-select">
                  <asp:ListItem Text="กรุณาเลือก" Value="null" />
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Iso"
                  InitialValue="0" runat="server" ForeColor="Red" />--%>
              </div>
            </div>

            <hr />

            <div class="row mb-3">
              <div class="col">
                <label for="ntool" class="form-label px-0">ชื่อเครื่องมือวัด : </label>
                <input type="text" class="form-control" id="ntool" placeholder="กรุณากรอกชื่อเครื่องมือ..." runat="server" required>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col me-4">
                <label class="form-label px-0">บริษัทผู้ผลิต : </label>
                <asp:DropDownList ID="PCompany" runat="Server" CssClass="form-select">
                  <asp:ListItem Text="กรุณาเลือก" Value="0" />
                </asp:DropDownList>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="type" class="form-label px-0">รุ่น : </label>
                  <input type="text" class="form-control" id="model" placeholder="ex : model" runat="server" required>
                </div>
              </div>

              <div class="col">
                <label for="notool" class="form-label px-0">หมายเลขเครื่อง : </label>
                <input type="text" class="form-control" id="notool" placeholder="ex : no." runat="server" required>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col me-4">
                <label for="location" class="form-label px-0">สถานที่ใช้งาน : </label>
                <input type="text" class="form-control" id="location" placeholder="กรุณากรอกชื่อสถานที่ใช้งาน..." runat="server" required>
              </div>

              <div class="col me-4">
                <label class="form-label px-0">ช่วงใช้งาน : </label>
                <div class="input-group mb-3">
                  <input type="text" class="form-control" placeholder="ex: 0-100" id="unitRang" runat="server" required>
                  <asp:DropDownList ID="Unit1" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                </div>
              </div>

              <div class="col me-4">
                <label class="form-label px-0">ค่าผิดพลาดที่ยอมรับได้ : </label>
                <div class="input-group mb-3">
                  <input type="text" class="form-control" placeholder="ex: +-1" id="unitError" runat="server" required>
                  <asp:DropDownList ID="Unit2" runat="Server" CssClass="form-select">
                    <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  </asp:DropDownList>
                </div>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col">
                <label class="form-label px-0">รายละเอียด : </label>
                <textarea class="form-control" placeholder="กรอกรายละเอียดที่นี่..."
                  id="floatingTextarea2" style="height: 100px" runat="server"></textarea>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col">
                <label class="form-label px-0">รูปภาพประกอบ : </label>
                <div class="input-group p-0">
                  <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" onchange="ShowPreview(this)" />
                </div>
              </div>
            </div>

            <div id="hidentImg" hidden="hidden" style="width: 100%;">
              <img id="impPrev" class="rounded" alt="preview" src="#" style="width: 100%;" accept="image/*" />
            </div>
          </div>

          <hr />

          <div class="mx-5 text-end">
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-lg"
              Text="Save" OnClick="Button2_Click" />
          </div>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
