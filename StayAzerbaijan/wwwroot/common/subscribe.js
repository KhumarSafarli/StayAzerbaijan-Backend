const submitButton = document.querySelector(".subscribe-btn .submitbutton");

submitButton.addEventListener("click", handleSubscribe);

function handleSubscribe(event) {
  event.preventDefault();

  const emailInput = document.querySelector(".email");
  const email = emailInput.value.trim();

  if (email === "") {
    showToast("E-mail ünvanınızı qeyd edin!");
  } else if (isValidEmail(email)) {
    showSuccessToast("Siz uğurla abunə oldunuz!");
  } else {
    showToast("E-mail ünvanı yanlışdır!");
  }
}

function isValidEmail(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email);
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

function showSuccessToast(message) {
  Toastify({
    text: message,
    duration: 3000,
    close: true,
    gravity: "top",
    position: "right",
    stopOnFocus: true,
    style: {
      background: "linear-gradient(to right, #2ecc71, #27ae60)",
    },
  }).showToast();
}
