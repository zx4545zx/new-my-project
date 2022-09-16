$(document).ready(function () {
  console.log("testttttt");
  $('#example').DataTable({
    responsive: true
  });
  DisplayChart();
});

function DisplayChart() {
  const labels = [
    'January',
    'February',
    'March',
    'January',
    'February',
    'March',
    'January',
    'February',
    'March',
    'January',
    'February',
    'March',
    'January',
    'February',
    'March',
    'January',
    'February',
    'March',
  ];

  const data = {
    labels: labels,
    datasets: [{
      label: '',
      data: [65, 59, 80, 65, 59, 80, 65, 59, 80, 65, 59, 80, 65, 59, 80, 65, 59, 80],
      fill: true,
      borderColor: 'rgb(75, 192, 192)',
      tension: 0.1
    }]
  };

  const config = {
    type: 'line',
    data: data,
  };

  new Chart(
    document.getElementById('myChart'),
    config
  );
}

document.addEventListener("DOMContentLoaded", function (event) {

  const showNavbar = (toggleId, navId, bodyId, headerId) => {
    const toggle = document.getElementById(toggleId),
      nav = document.getElementById(navId),
      bodypd = document.getElementById(bodyId),
      headerpd = document.getElementById(headerId)

    // Validate that all variables exist
    if (toggle && nav && bodypd && headerpd) {
      toggle.addEventListener('click', () => {
        // show navbar
        nav.classList.toggle('show')
        // change icon
        toggle.classList.toggle('bx-x')
        // add padding to body
        bodypd.classList.toggle('body-pd')
        // add padding to header
        headerpd.classList.toggle('body-pd')
      })
    }
  }

  showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header')

  /*===== LINK ACTIVE =====*/
  const linkColor = document.querySelectorAll('.nav_link')

  function colorLink() {
    if (linkColor) {
      linkColor.forEach(l => l.classList.remove('active'))
      this.classList.add('active')
    }
  }
  linkColor.forEach(l => l.addEventListener('click', colorLink))

  // Your code to run since DOM is loaded and ready
})