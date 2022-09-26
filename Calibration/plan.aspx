<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="plan.aspx.cs" Inherits="Calibration.plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">
          <i class="bi bi-file-earmark-spreadsheet-fill"></i>
          แผนการสอบเทียบเครื่องมือ</h4>
        <div>
          <button id="export_button" type="button" class="btn btn-sm btn-success">
            <i class="bi bi-file-spreadsheet-fill"></i>
            &nbsp;XLSX
          </button>
          <button id="filter_button" type="button" class="btn btn-sm btn-secondary"
            data-bs-toggle="collapse" data-bs-target="#collapseExample" aria-expanded="false"
            aria-controls="collapseExample">
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
            </div>

            <div class="mb-3">
              <label for="SelectCode" class="form-label px-0">รหัสแผนก : </label>
              <asp:DropDownList ID="SelectCode" runat="Server" CssClass="form-select">
                <asp:ListItem Text="กรุณาเลือก" Value="0" />
              </asp:DropDownList>
              <asp:RequiredFieldValidator ErrorMessage="กรุณาเลือก..." ControlToValidate="SelectCode"
                InitialValue="0" runat="server" ForeColor="Red" />
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

      <table id="scrollx" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th rowspan="2" class="text-nowrap text-center">ลำดับ</th>
            <th rowspan="2" class="text-nowrap text-center">รหัส</th>
            <th rowspan="2" class="text-nowrap text-center">แผนก</th>
            <th colspan="3" class="text-center">รายการ</th>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <th colspan="2" class="text-center">หมายเหตุ</th>
          </tr>
          <tr>
            <th>ชื่อเครื่องมือ</th>
            <th>ยี่ห้อ</th>
            <th>รุ่น</th>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            <th>วันที่ทำการสอบเทียบ</th>
            <th>วันสอบเทียบครั้งถัดไป</th>
          </tr>
        </thead>
        <tbody>
          <asp:Literal ID="RowData" runat="server"></asp:Literal>
        </tbody>
      </table>

      <script type="text/javascript">
        function html_table_to_excel(type) {
          let data = document.getElementById('scrollx');
          let file = XLSX.utils.table_to_book(data, { sheet: "sheet1" });
          XLSX.write(file, { bookType: type, bookSST: true, type: 'base64' });
          XLSX.writeFile(file, 'file.' + type);
        }

        const export_button = document.getElementById('export_button');
        export_button.addEventListener('click', () => {
          html_table_to_excel('xlsx');
          window.location.reload();
        });
      </script>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
