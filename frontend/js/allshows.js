const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

const welcomeMessage = document.getElementById("welcome-message");

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows";
const url = portUrl + showsUrl;

var username_message = document.createElement("span");
username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);

const getShows = document.getElementById("cards");

fetch(url)
  .then((res) => res.json())
  .then((data) => {
    getShow(data);
  });

function getShow(shows) {
  shows.forEach((show) => {
    let find = "tvshow.html?" + show.id;
    let upcoming = `<a href="${find}">
                    <div class="card">
                        <img src="img/${show.poster}" alt="" />
                        <h3>${show.name}</h3>
                    </div>
                   </a>`;

    if (getShows != null) {
      const getShows = document.getElementById("cards");
      const newUpcoming = document.createElement("a");
      newUpcoming.innerHTML = upcoming;
      getShows.appendChild(newUpcoming);
    }
  });
}

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
