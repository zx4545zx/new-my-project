<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="evaluate.aspx.cs" Inherits="Calibration.evaluate" %>

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
        <button class="btn btn-primary" type="button" data-bs-toggle="collapse"
          data-bs-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
          ประเมิน</button>
      </div>

      <hr />

      <div class="collapse" id="collapseExample">
        <div class="card mb-3" style="background-color: #f0f9ff;">
          <div class="card-body">
            <div class="d-flex justify-content-between gap-2">
              <div class="d-flex align-items-center">
                <div>เลขที่ใบลงทะเบียน :&nbsp;</div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
              </div>
              <div class="d-flex align-items-center">
                <div>รหัส :&nbsp;</div>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
              </div>
              <div class="d-flex align-items-center">
                <div>รอบการสอบเทียบ :&nbsp;</div>
                <asp:Label ID="Label3" runat="server" CssClass="btn btn-sm btn-danger disabled" Text="-"></asp:Label>
              </div>
            </div>

            <hr />

            <div class="d-flex justify-content-between gap-2">
              <div class="w-100">
                <label class="form-label px-0">ค่า Error : </label>
                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="กรุณากรอกข้อมูล..." ControlToValidate="TextBox1"
                  InitialValue="" runat="server" ForeColor="Red" />
              </div>

              <div class="w-100">
                <label class="form-label px-0">สถานะ : </label>
                <asp:DropDownList ID="Status" runat="Server" CssClass="form-select">
                  <asp:ListItem Text="กรุณาเลือก" Value="0" />
                  <asp:ListItem Text="ผ่าน" Value="1" />
                  <asp:ListItem Text="ไม่ผ่าน" Value="2" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="Status"
                  InitialValue="0" runat="server" ForeColor="Red" />
              </div>

              <div class="w-100">
                <label class="form-label px-0">วันที่ทำการสอบเทียบ : </label>
                <input type="date" id="DatePlan" class="form-control" required runat="server">
              </div>

              <div class="w-100">
                <label class="form-label px-0">สถานะข้อมูล : </label>
                <asp:DropDownList ID="StatusData" runat="Server" CssClass="form-select">
                  <asp:ListItem Text="กรุณาเลือก" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="StatusData"
                  InitialValue="0" runat="server" ForeColor="Red" />
              </div>
            </div>

            <div class="d-flex justify-content-between gap-2">
              <div class="w-100">
                <label class="form-label px-0">ผู้ทำการสอบเทียบ : </label>
                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="กรุณากรอกข้อมูล..." ControlToValidate="TextBox2"
                  InitialValue="" runat="server" ForeColor="Red" />
              </div>
              <div class="w-100"></div>
            </div>

            <div class="w-100">
              <label class="form-label px-0">หมายเหตุ : </label>
              <textarea class="form-control" placeholder="หมายเหตุ..."
                id="floatingTextarea2" style="height: 100px" runat="server"></textarea>
            </div>

            <hr />

            <div class="w-100 text-end">
              <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary"
                Text="บันทึกการประเมิน" OnClick="Button2_Click" />
            </div>

          </div>
        </div>
      </div>

      <div class="card mb-3">
        <div class="card-body">
          <table id="fixHeader" class="table table-sm table-striped table-bordered nowrap">
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
                <th scope="col" class='text-center'>Action</th>
              </tr>
            </thead>
            <tbody>
              <asp:Literal ID="RowData" runat="server"></asp:Literal>
            </tbody>
            <tfoot>
              <tr>
                <th scope="col">#</th>
                <th scope="col" class='text-center'>ค่า Error</th>
                <th scope="col" class='text-center'>สถานะ</th>
                <th scope="col" class='text-center'>วันที่ทำการสอบเทียบ</th>
                <th scope="col">ผู้ทำการสอบเทียบ</th>
                <th scope="col" class='text-center'>สถานะข้อมูล</th>
                <th scope="col">หมายเหตุ</th>
                <th scope="col" class='text-center'>วันที่บันทึก</th>
                <th scope="col" class='text-center'>Action</th>
              </tr>
            </tfoot>
          </table>
        </div>
      </div>

    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
