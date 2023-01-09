$(document).ready(function () {
  $('#example').DataTable({
    responsive: true,
    initComplete: function (settings, json) {
      $('#showeTable').show();
      $('#example').DataTable().columns.adjust();
    },
  });

  $('#scrollx').DataTable({
    scrollX: true,
    initComplete: function (settings, json) {
      $('#showeTable').show();
      $('#scrollx').DataTable().columns.adjust();
    },
  });

  fixHeader();
});

function fixHeader() {
  $('#fixHeader').DataTable({
    responsive: true,
    deferRender: true,
    initComplete: function (settings, json) {
      $('#showeTable').show();   
      this.api()
        .columns()
        .every(function () {
          var column = this;
          var select = $('<select class="form-select form-select-sm"><option value="">ทั้งหมด</option></select>')
            .appendTo($(column.footer()).empty())
            .on('change', function () {
              var val = $.fn.dataTable.util.escapeRegex($(this).val());

              column.search(val ? '^' + val + '$' : '', true, false).draw();
            });

          column
            .data()
            .unique()
            .sort()
            .each(function (d, j) {
              select.append('<option value="' + d + '">' + d + '</option>');
            });
        });
      document.getElementById("showSpinner").hidden = true;
    },
  })
}

function MessageNoti(status, title, message, href = '#') {
  Swal.fire({
    icon: status,
    title: title,
    text: message,
    confirmButtonText: `<a href="${href}">ตกลง</a>`,
  })
}

function DisplayChart(data = [{ date: "", error: "" }]) {
  const Utils = ChartUtils.init();
  new Chart(document.getElementById("myChart"), {
    type: 'line',
    data: {
      datasets: [
        {
          label: 'ERROR',
          fill: false,
          //tension: 0.4,
          backgroundColor: Utils.transparentize(Utils.CHART_COLORS.red, 0.5),
          borderColor: Utils.CHART_COLORS.red,
          borderWidth: 2,
          pointStyle: 'circle',
          pointRadius: 5,
          pointHoverRadius: 10,
          data: data.map(o => ({ x: o.date, y: o.error }))
        }
      ]
    },
    options: {
      scales: {
        x: {
          display: true,
          title: {
            display: true
          }
        },
        y: {
          display: true,
          title: {
            display: true
          },
          suggestedMin: 0,
          suggestedMax: 1
        }
      }
    }
  });
}

function ConfirmDel(url, id) {
  let result = confirm("คุณต้องการจะลบข้อมูลนี้ ใช่หรือไม่?");
  if (result) {
    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ id: id })
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.d == true) {
          window.location.reload()
        }
        console.log(data);
      })
      .catch((err) => console.error(err))
  }
}

function ShowPreview(input) {
  console.log(input)
  if (input.files && input.files[0]) {
    var ImageDir = new FileReader();
    ImageDir.onload = function (e) {
      try {
        let image = document.getElementById("impPrev");
        image.src = e.target.result;
      } catch {
        let image = document.getElementById("impPrev");
        image.src = "#";
      }
    }
    ImageDir.readAsDataURL(input.files[0]);
    document.getElementById("hidentImg").hidden = false;
  } else {
    let image = document.getElementById("impPrev");
    image.src = "#";
    document.getElementById("hidentImg").hidden = "hidden";
  }
}


