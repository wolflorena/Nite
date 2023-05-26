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
  let upcomingShowSort = [...shows].sort((s1, s2) =>
    s1.daysUntilNewSeason > s2.daysUntilNewSeason
      ? 1
      : s1.daysUntilNewSeason < s2.daysUntilNewSeason
      ? -1
      : 0
  );

  upcomingShowSort.forEach((show) => {
    let find = "tvshow.html?" + show.id;
    let upcoming = `<a href="${find}">
                    <div class="card">
                        <img src="img/${show.poster}" alt="" />
                        <div class="card-text-center">
                          <h3>${show.daysUntilNewSeason} days</h3>
                        </div>
                        <h3>${show.name}</h3>
                        <h5>Season ${show.seasons + 1} ○ ${show.newSeason}</h5>
                    </div>
                   </a>`;

    if (
      getShows != null &&
      show.daysUntilNewSeason > 0 &&
      show.daysUntilNewSeason < 101
    ) {
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
