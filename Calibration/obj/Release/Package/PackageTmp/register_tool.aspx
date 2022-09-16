<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register_tool.aspx.cs" Inherits="Calibration.register_tool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="card mx-auto w-100" style="background-color: #f0f9ff;">
        <div class="card-body">
          <h5 class="card-title">ขึ้นทะเบียนเครื่องมือ</h5>

          <hr />

          <div class="mx-5">
            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="name" class="form-label px-0">ชื่อผู้ขอ : </label>
                  <input type="text" class="form-control" id="name">
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="date" class="form-label px-0">วันที่ : </label>
                  <input type="date" class="form-control" id="date">
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="email" class="form-label px-0">Email : </label>
                  <input type="email" class="form-control" id="email">
                </div>
              </div>
              <div class="col">
                <div class="mb-3 row">
                  <label for="tel" class="form-label px-0">เบอร์ติดต่อ : </label>
                  <input type="tel" class="form-control" id="tel">
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">ฝ่ายต้นสังกัด : </label>
                  <select class="form-select" aria-label="Default select example">
                    <option selected>กรุณาเลือก</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                  </select>
                </div>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">โรงงาน : </label>
                  <select class="form-select" aria-label="Default select example">
                    <option selected>กรุณาเลือก</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                  </select>
                </div>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">แผนก : </label>
                  <select class="form-select" aria-label="Default select example">
                    <option selected>กรุณาเลือก</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                  </select>
                </div>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label class="form-label px-0">เครื่องมือวัด : </label>
                  <select class="form-select" aria-label="Default select example">
                    <option selected>กรุณาเลือก</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                  </select>
                </div>
              </div>

              <div class="col">
                <div class="mb-3 row">
                  <label class="form-label px-0">ผู้อนุมัติ (ฝ่าย) : </label>
                  <select class="form-select" aria-label="Default select example">
                    <option selected>กรุณาเลือก</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                  </select>
                </div>
              </div>
            </div>

            <hr />

            <div class="row">
              <div class="col">
                <h6>ต้องการส่งเครื่องมือวัดมาเพื่อ</h6>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="1" id="chiso">
                  <label class="form-check-label" for="chiso">
                    ขึ้นทะเบียนใหม่ ISO
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="2" id="chin">
                  <label class="form-check-label" for="chin">
                    สอบเทียบภายใน
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="3" id="chout">
                  <label class="form-check-label" for="chout">
                    สอบเทียบภายนอก
                  </label>
                </div>
              </div>

              <div class="col">
                <h6>มีใบ Certificate หรือไม่?</h6>
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1" value="1" runat="server">
                  <label class="form-check-label" for="flexRadioDefault1">
                    มี
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="0" runat="server">
                  <label class="form-check-label" for="flexRadioDefault2">
                    ไม่มี
                  </label>
                </div>
              </div>
            </div>

            <hr />

            <div class="row mb-3">
              <div class="col">
                <label for="ntool" class="form-label px-0">ชื่อเครื่องมือวัด : </label>
                <input type="text" class="form-control" id="ntool">
              </div>
            </div>

            <div class="row mb-3">
              <div class="col me-4">
                <label class="form-label px-0">บริษัทผู้ผลิต : </label>
                <select class="form-select" aria-label="Default select example">
                  <option selected>กรุณาเลือก</option>
                  <option value="1">One</option>
                  <option value="2">Two</option>
                  <option value="3">Three</option>
                </select>
              </div>

              <div class="col me-4">
                <div class="mb-3 row">
                  <label for="type" class="form-label px-0">รุ่น : </label>
                  <input type="text" class="form-control" id="type">
                </div>
              </div>

              <div class="col">
                <label for="notool" class="form-label px-0">หมายเลขเครื่อง : </label>
                <input type="text" class="form-control" id="notool">
              </div>
            </div>

            <div class="row mb-3">
              <div class="col me-4">
                <label for="location" class="form-label px-0">สถานที่ใช้งาน : </label>
                <input type="text" class="form-control" id="location">
              </div>

              <div class="col me-4">
                <label class="form-label px-0">ช่วงใช้งาน : </label>
                <div class="input-group mb-3">
                  <input type="text" class="form-control" placeholder="ex: 0-100">
                  <select class="form-select" aria-label="Default select example">
                    <option selected>กรุณาเลือก</option>
                    <option value="1">%</option>
                    <option value="2">c</option>
                    <option value="3">-</option>
                  </select>
                </div>
              </div>

              <div class="col me-4">
                <label class="form-label px-0">ค่าผิดพลาดที่ยอมรับได้ : </label>
                <div class="input-group mb-3">
                  <input type="text" class="form-control" placeholder="ex: +-1">
                  <select class="form-select" aria-label="Default select example">
                    <option selected>กรุณาเลือก</option>
                    <option value="1">%</option>
                    <option value="2">c</option>
                    <option value="3">-</option>
                  </select>
                </div>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col">
                <label class="form-label px-0">รายละเอียด : </label>
                <textarea class="form-control" placeholder="กรอกรายละเอียดที่นี่..." id="floatingTextarea2" style="height: 100px"></textarea>
              </div>
            </div>

            <div class="row mb-3">
              <div class="col">
                <label class="form-label px-0">รูปภาพประกอบ : </label>
                <div class="input-group p-0">
                  <input type="file" class="form-control" id="inputGroupFile04" aria-describedby="inputGroupFileAddon04" aria-label="Upload">
                  <%--<button class="btn btn-secondary" type="button" id="inputGroupFileAddon04">Preview</button>--%>
                </div>
              </div>
            </div>
          </div>

          <hr />

          <div class="mx-5 text-end">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-secondary btn-lg me-3"
              Text="Clear" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-lg" Text="Save"
              OnClick="Button2_Click" />
          </div>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
