const delay = 6000;
const loader = document.getElementById("preloader");
window.addEventListener("load", function () {
  setTimeout(function () {
    loader.classList.add("hide-preloader");
  }, delay);
});
