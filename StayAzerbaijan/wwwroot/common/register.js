const passwordInput = document.getElementById("password");
const passwordValidationBox = document.getElementById(
  "password-validation-box"
);
const lowercaseRequirement = document.getElementById("lowercase");
const uppercaseRequirement = document.getElementById("capital-letter");
const numberRequirement = document.getElementById("number");
const lengthRequirement = document.getElementById("length");
const EMAIL_REGEX = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
const PASSWORD_REGEX =
  /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$/;
passwordInput.addEventListener("focus", () => {
  passwordValidationBox.style.display = "initial";
});

passwordInput.addEventListener("blur", () => {
  passwordValidationBox.style.display = "none";
});
passwordValidationBox.style.display = "none";

passwordInput.onkeyup = function () {
  const lowerCaseLetters = /[a-z]/;
  if (passwordInput.value.match(lowerCaseLetters)) {
    lowercaseRequirement.classList.remove("invalid");
    lowercaseRequirement.classList.add("valid");
  } else {
    lowercaseRequirement.classList.remove("valid");
    lowercaseRequirement.classList.add("invalid");
  }

  const upperCaseLetters = /[A-Z]/;
  if (passwordInput.value.match(upperCaseLetters)) {
    uppercaseRequirement.classList.remove("invalid");
    uppercaseRequirement.classList.add("valid");
  } else {
    uppercaseRequirement.classList.remove("valid");
    uppercaseRequirement.classList.add("invalid");
  }

  const numbers = /[0-9]/;
  if (passwordInput.value.match(numbers)) {
    numberRequirement.classList.remove("invalid");
    numberRequirement.classList.add("valid");
  } else {
    numberRequirement.classList.remove("valid");
    numberRequirement.classList.add("invalid");
  }
  if (passwordInput.value.length >= 8) {
    lengthRequirement.classList.remove("invalid");
    lengthRequirement.classList.add("valid");
  } else {
    lengthRequirement.classList.remove("valid");
    lengthRequirement.classList.add("invalid");
  }
};
function validateFormItems() {
  let isSuccess = true;
  const firstname = document.getElementById("firstname").value;
  const lastname = document.getElementById("lastname").value;
  const email = document.getElementById("email").value;
  const password = document.getElementById("password").value;
  const confirmPassword = document.getElementById("confirmPassword").value;

  if (!firstname.trim() || !lastname.trim()) {
    document.querySelector(".name .error-message").textContent =
      "Ad və soyad daxil edilməlidir!";
    isSuccess = false;
  } else {
    document.querySelector(".name .error-message").textContent = "";
  }

  if (!email.trim()) {
    document.querySelector(".email .error-message").textContent =
      "Email daxil edilməlidir";
    isSuccess = false;
  } else if (!EMAIL_REGEX.test(email)) {
    document.querySelector(".email .error-message").textContent =
      "Yanlış Email formatı";
    isSuccess = false;
  } else {
    document.querySelector(".email .error-message").textContent = "";
  }

  if (!password.trim()) {
    document.querySelector(".password .error-message").textContent =
      "Şifrə daxil edilməlidir";
    isSuccess = false;
  } else if (!PASSWORD_REGEX.test(password)) {
    document.querySelector(".password .error-message").textContent =
      "Yanlış Şifrə formatı";
    isSuccess = false;
  } else {
    document.querySelector(".password .error-message").textContent = "";
  }

  if (!confirmPassword.trim()) {
    document.querySelector(".confirm-password .error-message").textContent =
      "Şifrəni təsdiqləmək lazımdır";
    isSuccess = false;
  } else if (!PASSWORD_REGEX.test(confirmPassword)) {
    document.querySelector(".confirm-password .error-message").textContent =
      "Yanlış Şifrəni təsdiqləmə formatı";
    isSuccess = false;
  } else if (password !== confirmPassword) {
    document.querySelector(".confirm-password .error-message").textContent =
      "Şifrələr uyğun gəlmir";
    isSuccess = false;
  } else {
    document.querySelector(".confirm-password .error-message").textContent = "";
  }

  return isSuccess;
}
