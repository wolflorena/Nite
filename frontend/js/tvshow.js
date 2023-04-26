let showId = window.location.href.split("?")[1];

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const url = portUrl + showsUrl + showId;
const getShowInfo = document.getElementById("info");

fetch(url)
  .then((res) => res.json())
  .then((data) => {
    getShow(data);
  });

function getShow(show) {
  let info = `<img src="img/${show.logo}" alt="">
            <div class="first-child" id="first-child">
                <ul class="general">
                    <li>${show.year}</li>
                    <li>${show.audience}</li>
                    <li>${show.seasons} Seasons</li>
                    <li>${show.status}</li>
                </ul>
                <img src="img/${show.streaming}.png" alt="">
                <button class="heart"><i class="fa-regular fa-heart fa-2xl"></i></button>
            </div>

            <div class="description" id="description">
                <p>${show.description}</p>
            </div>`;

  getShowInfo.innerHTML = info;

  const container = document.getElementById("main");
  container.style.backgroundImage = `linear-gradient(
    to bottom,
    rgba(0, 0, 0, 0.6),
    rgba(0, 0, 0, 0.8)
  ),url(img/${show.banner})`;
}

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
