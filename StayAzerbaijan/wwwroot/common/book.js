document.addEventListener("DOMContentLoaded", function () {
  const checkInInput = document.getElementById("check-in");
  const checkOutInput = document.getElementById("check-out");

  flatpickr(checkInInput, {
    minDate: "today",
    dateFormat: "Y-m-d",
    onChange: function (selectedDates, dateStr) {
      const minCheckOutDate = new Date(selectedDates[0]);
      minCheckOutDate.setDate(minCheckOutDate.getDate() + 1);

      flatpickr(checkOutInput, {
        minDate: minCheckOutDate,
        dateFormat: "Y-m-d",
      });

      const selectedCheckOutDate = flatpickr.parseDate(
        checkOutInput.value,
        "Y-m-d"
      );
      if (selectedCheckOutDate < minCheckOutDate) {
        checkOutInput.value = "";
      }
    },
  });

  flatpickr(checkOutInput, {
    dateFormat: "Y-m-d",
  });

  function toggleDropdown() {
    const dropdownContent = document.querySelector(".pax-dropdown-content");
    dropdownContent.style.display =
      dropdownContent.style.display === "block" ? "none" : "block";
  }

  // Populate options for number of adults, children, and rooms
  const guestsSelect = document.getElementById("guests");
  const childrenSelect = document.getElementById("children");
  const roomsSelect = document.getElementById("rooms");

  for (let i = 0; i <= 9; i++) {
    guestsSelect.options.add(new Option(i, i));
    childrenSelect.options.add(new Option(i, i));
    roomsSelect.options.add(new Option(i, i));
  }
});
