document.addEventListener("DOMContentLoaded", function () {
  const hotelCards = document.querySelectorAll(".trend-hotels .hotel-card");
  const leftButton = document.querySelector(".left");
  const rightButton = document.querySelector(".right");
  const totalHotels = hotelCards.length;
  const hotelsPerPage = 3;
  let currentIndex = 0;

  function showHotels() {
    hotelCards.forEach((card, index) => {
      if (index >= currentIndex && index < currentIndex + hotelsPerPage) {
        card.style.display = "block";
      } else {
        card.style.display = "none";
      }
    });
  }

  function updateButtons() {
    leftButton.disabled = currentIndex === 0;
    rightButton.disabled = currentIndex + hotelsPerPage >= totalHotels;

    if (leftButton.disabled) {
      leftButton.classList.add("disabled");
    } else {
      leftButton.classList.remove("disabled");
    }

    if (rightButton.disabled) {
      rightButton.classList.add("disabled");
    } else {
      rightButton.classList.remove("disabled");
    }
  }

  function showNextHotels() {
    currentIndex += hotelsPerPage;
    showHotels();
    updateButtons();
  }

  function showPreviousHotels() {
    currentIndex -= hotelsPerPage;
    showHotels();
    updateButtons();
  }

  leftButton.addEventListener("click", showPreviousHotels);
  rightButton.addEventListener("click", showNextHotels);

  function showAllHotelsInTabletMode() {
    if (window.innerWidth <= 1240) {
      hotelCards.forEach((card) => {
        card.style.display = "block";
      });
      leftButton.style.display = "none";
      rightButton.style.display = "none";
    } else {
      showHotels();
      updateButtons();
    }
  }
  showAllHotelsInTabletMode();
});
