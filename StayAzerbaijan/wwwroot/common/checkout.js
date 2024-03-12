document.addEventListener("DOMContentLoaded", function () {
  var image = document.getElementById("hotel-img");

  image.addEventListener("click", function () {
    image.classList.toggle("zoomed");
  });
});

document.addEventListener("DOMContentLoaded", function () {
  const reservationForm = document.getElementById("reservation-form");

  reservationForm.addEventListener("submit", function (event) {
    event.preventDefault();

    const firstName = document.getElementById("first-name").value.trim();
    const lastName = document.getElementById("last-name").value.trim();
    const passportNumber = document
      .getElementById("passport-number")
      .value.trim();
    const phoneNumber = document.getElementById("phone-number").value.trim();

    if (!firstName || !lastName || !passportNumber || !phoneNumber) {
      showToast("Please fill out all the required fields.");
    } else {
          showPaymentSuccessModal(); 
      }
  });

    function showPaymentSuccessModal() {
      
        var modal = new bootstrap.Modal(document.getElementById('paymentSuccessModal'));
        modal.show();
    }

function showToast(message) {
  Toastify({
    text: message,
    duration: 3000,
    close: true,
    gravity: "top",
    position: "right",
    stopOnFocus: true,
    style: {
      background: "linear-gradient(to right, #e74c3c, #e74c3c)",
    },
  }).showToast();
}

(function () {
  "use strict";
  window.addEventListener(
    "load",
    function () {
      var forms = document.getElementsByClassName("needs-validation");
      Array.prototype.filter.call(forms, function (form) {
        form.addEventListener(
          "submit",
          function (event) {
            if (form.checkValidity() === false) {
              event.preventDefault();
              event.stopPropagation();
            }
            form.classList.add("was-validated");
          },
          false
        );
      });
    },
    false
  );
})();
