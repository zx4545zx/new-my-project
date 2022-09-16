<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="plan.aspx.cs" Inherits="Calibration.plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <div class="d-flex justify-content-between align-items-end w-100">
        <h4 class="m-0 text-lg">
          <i class="bi bi-file-earmark-spreadsheet-fill"></i>
          แผนการสอบเทียบเครื่องมือ</h4>
        <div>
          <button id="export_button" class="btn btn-sm btn-success">
            <i class="bi bi-file-spreadsheet-fill"></i>
            &nbsp;XLSX
          </button>
        </div>
      </div>

      <hr />

      <table id="scrollx" class="table table-sm table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th rowspan="2" class="text-nowrap text-center">ลำดับ</th>
            <th rowspan="2" class="text-nowrap text-center">รหัสใหม่</th>
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

      <script type="text/javascript" src="https://unpkg.com/xlsx@0.15.1/dist/xlsx.full.min.js"></script>
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
