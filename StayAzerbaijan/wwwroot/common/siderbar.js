// sidebar.js

document.addEventListener("DOMContentLoaded", function () {
  const sidebarToggle = document.querySelector(".sidebar-toggle");
  const sidebar = document.querySelector(".sidebar");

  sidebarToggle.addEventListener("click", function () {
    sidebar.classList.toggle("show");
  });

  // Initialize price range slider
  // Code for initializing the slider goes here

  // Add event listener to hotel category checkboxes
  const categoryCheckboxes = document.querySelectorAll(
    '.category-checkbox input[type="checkbox"]'
  );
  categoryCheckboxes.forEach(function (checkbox) {
    checkbox.addEventListener("change", function () {
      // Code to filter search results based on selected categories goes here
    });
  });
});
