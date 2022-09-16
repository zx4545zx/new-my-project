$(document).ready(function () {
  $('#example').DataTable({
    responsive: true
  });

  $('#scrollx').DataTable({
    scrollX: true,
  });

  DisplayChart()
});

function MessageNoti(status, title, message, href) {
  Swal.fire({
    icon: status,
    title: title,
    text: message,
    confirmButtonText: `<a href="${href}">ตกลง</a>`,
  })
}

function DisplayChart() {

  const data = [
    { date: '2020-03-1', error: 0.8 },
    { date: '2020-03-2', error: 0.1 },
    { date: '2020-03-3', error: 0.5 },
    { date: '2020-03-4', error: 0.9 },
    { date: '2020-03-5', error: 0.4 },
    { date: '2020-03-6', error: 0.8 },
    { date: '2020-03-7', error: 0.1 },
    { date: '2020-03-8', error: 0.5 },
    { date: '2020-03-9', error: 0.9 },
    { date: '2020-03-10', error: 0.4 },
    { date: '2020-03-11', error: 0.8 },
    { date: '2020-03-12', error: 0.1 },
    { date: '2020-03-13', error: 0.5 },
    { date: '2020-03-14', error: 0.9 },
    { date: '2020-03-15', error: 0.4 },
    { date: '2020-03-16', error: 0.8 },
    { date: '2020-03-17', error: 0.1 },
    { date: '2020-03-18', error: 0.5 },
    { date: '2020-03-19', error: 0.9 },
    { date: '2020-03-20', error: 0.4 },
    { date: '2020-03-21', error: 0.8 },
    { date: '2020-03-22', error: 0.1 },
    { date: '2020-03-23', error: 0.5 },
    { date: '2020-03-24', error: 0.9 },
    { date: '2020-03-25', error: 0.4 },
    { date: '2020-03-26', error: 0.8 },
    { date: '2020-03-27', error: 0.1 },
    { date: '2020-03-28', error: 0.5 },
    { date: '2020-03-29', error: 0.9 },
    { date: '2020-03-30', error: 0.4 },
    { date: '2020-03-31', error: 0.9 },
  ];

  new Chart(document.getElementById("myChart"), {
    type: 'line',
    data: {
      datasets: [
        {
          label: 'ค่า ERROR',
          fill: false,
          lineTension: 0.4,
          backgroundColor: 'red',
          borderWidth: 2,
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
        console.error(data);
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