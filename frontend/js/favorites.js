const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

const portUrl = "https://localhost:7053";
const favoritesUrl = "/api/favorites/";
const showUrl = portUrl + "/api/shows/";
const url = portUrl + favoritesUrl + id;
const getShows = document.getElementById("cards");

const welcomeMessage = document.getElementById("welcome-message");

var username_message = document.createElement("span");
username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);

fetch(url)
  .then((res) => res.json())
  .then((data) => {
    getShow(data);
  });

function getShow(shows) {
  shows.forEach((show) => {
    fetch(showUrl + show.tvShowId)
      .then((res) => res.json())
      .then((data) => {
        let find = "tvshow.html?" + data.id;
        let favorite = `<a href="${find}">
                        <div class="card">
                            <img src="img/${data.poster}" alt="">
                            <h3>${data.name}</h3>
                        </div>
                    </a>`;

        if (getShows != null) {
          const getShows = document.getElementById("cards");
          const newShow = document.createElement("a");
          newShow.innerHTML = favorite;
          getShows.appendChild(newShow);
        }
      });
  });
}

function logout() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
