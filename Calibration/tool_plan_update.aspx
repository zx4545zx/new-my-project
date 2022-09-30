<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tool_plan_update.aspx.cs" Inherits="Calibration.tool_plan_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <div class="m-auto">
        <div class="d-flex justify-content-between align-items-end w-100">
          <div>
            <a href="administrator.aspx" class="btn btn-secondary">
              <i class="bi bi-arrow-return-left"></i>
              &nbsp;BACK
            </a>
          </div>
          <h4 class="m-0 p-2 text-lg card">แก้ไขข้อมูลทะเบียนเครื่องมือ</h4>
        </div>

        <hr />

        <div class="card mb-3 mx-auto w-100">
          <div class="row g-0">
            <div class="col-4 p-2">
              <label for="img" class="form-label px-0">รูปภาพประกอบ :</label>
              <asp:Image ID="imgViewFile" CssClass="img-fluid rounded w-100" runat="server" />
            </div>
            <div class="col-8 px-2">
              <div class="card-body">

                <div class="row justify-content-center">
                  <div class="col me-4 p-0">
                    <div>
                      <span class="form-label px-0">เลขใบแจ้งลงทะเบียน :&nbsp;</span>
                      <asp:Label ID="Label1" runat="server" Text="-"></asp:Label>
                    </div>
                  </div>

                  <div class="col p-0">
                    <div class="text-end">
                      <span class="form-label px-0">รหัส :&nbsp;</span>
                      <asp:Label ID="Label2" runat="server" Text="-"></asp:Label>
                    </div>
                  </div>
                </div>

                <hr class="row" />

                <div class="row">
                  <div class="col me-4">
                    <div class="mb-3 row">
                      <label for="name" class="form-label px-0">ชื่อผู้ขอ :</label>
                      <input type="text" class="form-control sub-color" id="Text1" runat="server">
                    </div>
                  </div>
                  <div class="col me-4">
                    <div class="mb-3 row">
                      <label for="email" class="form-label px-0">Email :</label>
                      <input type="email" class="form-control sub-color" id="email1" runat="server">
                    </div>
                  </div>
                  <div class="col">
                    <div class="mb-3 row">
                      <label for="tel" class="form-label px-0">เบอร์ติดต่อ :</label>
                      <input type="tel" class="form-control sub-color" id="tel1" runat="server">
                    </div>
                  </div>
                </div>

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

                <div class="row mb-3">
                  <div class="col me-4">
                    <div class="row">
                      <label for="NoCer" class="form-label px-0">เลขที่ใบ : </label>
                      <input type="text" class="form-control" id="NoCer" placeholder="-" runat="server">
                    </div>
                  </div>

                  <div class="col">
                    <label for="DateOut" class="form-label px-0">วันหมดอายุ : </label>
                    <input type="date" class="form-control" id="DateOut" runat="server">
                  </div>
                </div>

                <div class="row">
                  <div class="col me-4">
                    <div class="row">
                      <label class="form-label px-0">ISO : </label>
                      <asp:DropDownList ID="Iso" runat="Server" CssClass="form-select sub-color">
                        <asp:ListItem Text="กรุณาเลือก" Value="0" />
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Iso"
                        InitialValue="0" runat="server" ForeColor="Red" />
                    </div>
                  </div>
                </div>

                <hr />

                <div class="row mb-3">
                  <div class="col">
                    <label for="ntool" class="form-label px-0">ชื่อเครื่องมือวัด : </label>
                    <input type="text" class="form-control sub-color" id="ntool"
                      placeholder="กรุณากรอกชื่อเครื่องมือ..." runat="server" required>
                  </div>
                </div>

                <div class="row mb-3">
                  <div class="col me-4">
                    <label class="form-label px-0">บริษัทผู้ผลิต : </label>
                    <asp:DropDownList ID="PCompany" runat="Server" CssClass="form-select sub-color">
                      <asp:ListItem Text="กรุณาเลือก" Value="0" />
                    </asp:DropDownList>
                  </div>

                  <div class="col me-4">
                    <div class="mb-3 row">
                      <label for="type" class="form-label px-0">รุ่น : </label>
                      <input type="text" class="form-control sub-color" id="Text2"
                        placeholder="ex : model" runat="server" required>
                    </div>
                  </div>

                  <div class="col">
                    <label for="notool" class="form-label px-0">หมายเลขเครื่อง : </label>
                    <input type="text" class="form-control sub-color" id="Text3"
                      placeholder="ex : no." runat="server" required>
                  </div>
                </div>

                <div class="row mb-3">
                  <div class="col me-4">
                    <label for="location" class="form-label px-0">สถานที่ใช้งาน : </label>
                    <input type="text" class="form-control sub-color" id="location"
                      placeholder="กรุณากรอกชื่อสถานที่ใช้งาน..." runat="server" required>
                  </div>

                  <div class="col me-4">
                    <label class="form-label px-0">ช่วงใช้งาน : </label>
                    <div class="input mb-3">
                      <input type="text" class="form-control sub-color"
                        placeholder="ex: 0-100" id="unitRang" runat="server" required>
                    </div>
                  </div>

                  <div class="col me-4">
                    <label class="form-label px-0">ค่าผิดพลาดที่ยอมรับได้ : </label>
                    <div class="input mb-3">
                      <input type="text" class="form-control sub-color"
                        placeholder="ex: +-1" id="unitError" runat="server" required>
                    </div>
                  </div>
                </div>

                <div class="row mb-3">
                  <div class="col">
                    <label class="form-label px-0">รายละเอียด : </label>
                    <textarea class="form-control sub-color" placeholder="กรอกรายละเอียดที่นี่..."
                      id="floatingTextarea2" style="height: 100px" runat="server"></textarea>
                  </div>
                </div>

                <hr />

                <div class="row mb-3">
                  <div class="col">
                    <label class="form-label px-0">รายละเอียดจากแผนกสอบเทียบ : </label>
                    <textarea class="form-control" placeholder="กรอกรายละเอียดที่นี่..."
                      id="Textarea1" style="height: 100px" runat="server"></textarea>
                  </div>
                </div>

                <div class="row mb-3">
                  <div class="col">
                    <label class="form-label px-0">สถานที่สอบเทียบ : </label>
                    <asp:DropDownList ID="LocationCali" runat="Server" CssClass="form-select">
                      <asp:ListItem Text="กรุณาเลือก" Value="0" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="LocationCali"
                      InitialValue="0" runat="server" ForeColor="Red" />
                  </div>
                </div>

                <div class="row mb-3">
                  <div class="col me-4">
                    <label for="notool" class="form-label px-0">กำหนดแผน : </label>
                    <input type="date" class="form-control" id="Date1" runat="server" required>
                  </div>

                  <div class="col">
                    <label for="type" class="form-label px-0">รอบ : </label>
                    <div class="input-group mb-3">
                      <input type="text" class="form-control" placeholder="ex: 0-100" id="RoundNumber" runat="server" required>
                      <asp:DropDownList ID="RoundUnit" runat="Server" CssClass="form-select">
                        <asp:ListItem Text="กรุณาเลือก" Value="0" />
                        <asp:ListItem Text="วัน" Value="d" />
                        <asp:ListItem Text="สัปดาห์" Value="w" />
                        <asp:ListItem Text="เดือน" Value="m" />
                        <asp:ListItem Text="ปี" Value="y" />
                      </asp:DropDownList>
                    </div>
                    <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="RoundUnit"
                      InitialValue="0" runat="server" ForeColor="Red" />
                  </div>
                </div>

                <hr />

                <div class="text-center w-100">
                  <asp:Button ID="Save" runat="server" CssClass="btn btn-primary btn-lg w-100"
                    Text="บันทึกข้อมูล" OnClick="Save_Click" />
                </div>
              </div>
            </div>
          </div>
        </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
