document.addEventListener("DOMContentLoaded", function () {
  const burgerMenu = document.getElementById("burger-menu");
  const navLinks = burgerMenu.querySelector(".nav-links");

  burgerMenu.addEventListener("click", function (event) {
    navLinks.classList.toggle("show-nav-links");

    event.stopPropagation();
  });

  document.addEventListener("click", function (event) {
    if (
      !burgerMenu.contains(event.target) &&
      event.target !== burgerMenu &&
      event.target !== navLinks
    ) {
      navLinks.classList.remove("show-nav-links");
    }
  });
});
