<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="plan.aspx.cs" Inherits="Calibration.plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>
      <table class="table table-striped table-bordered nowrap" style="width: 100%">
        <thead>
          <tr>
            <th rowspan="2">ลำดับ</th>
            <th rowspan="2">รหัสใหม่</th>
            <th rowspan="2">แผนก</th>

            <th colspan="3" class="text-center">รายการ</th>
            <th colspan="10" class="text-center">ประจำเดือน: xxxx ปี: xxxx</th>
          </tr>
          <tr>
            <th>ชื่อ</th>
            <th>ยี่ห้อ</th>
            <th>รุ่น</th>

            <th width="1%">1</th>
            <th width="1%">2</th>
            <th width="1%">3</th>
            <th width="1%">4</th>
            <th width="1%">5</th>
            <th width="1%">6</th>
            <th width="1%">7</th>
            <th width="1%">8</th>
            <th width="1%">9</th>
            <th width="1%">10</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Donna Snider</td>
            <td>Customer Support</td>
            <td>$112,000</td>
            <td>New York</td>
            <td>4226</td>
            <td>d.snider@datatables.net</td>
            <td></td>
            <td>x</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
        </tbody>
        <tfoot>
          <tr>
            <th>ลำดับ</th>
            <th>รหัสใหม่</th>
            <th>แผนก</th>
            <th>ชื่อ</th>
            <th>ยี่ห้อ</th>
            <th>รุ่น</th>
            <th width="1%">1</th>
            <th width="1%">2</th>
            <th width="1%">3</th>
            <th width="1%">4</th>
            <th width="1%">5</th>
            <th width="1%">6</th>
            <th width="1%">7</th>
            <th width="1%">8</th>
            <th width="1%">9</th>
            <th width="1%">10</th>
          </tr>
        </tfoot>
      </table>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
