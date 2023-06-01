const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows";
const url = portUrl + showsUrl;
const getShowsPopularContainer = document.getElementById("cards-popular");
const getShowsExploreContainer = document.getElementById("cards-explore");
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
  let countPopular = 1;
  let countExplore = 1;

  let popularShowsSort = [...shows].sort((s1, s2) =>
    s1.likes < s2.likes ? 1 : s1.likes > s2.likes ? -1 : 0
  );

  popularShowsSort.forEach((show) => {
    let find = "tvshow.html?" + show.id;
    let popular = `<a href="${find}">
                    <div class="card">
                        <img src="img/${show.poster}" alt="">
                        <h3>${show.name}</h3>
                    </div>
                </a>`;

    if (getShowsPopularContainer != null && countPopular <= 5) {
      const getShowsPopularContainer = document.getElementById("cards-popular");
      const newPopular = document.createElement("a");
      newPopular.innerHTML = popular;
      getShowsPopularContainer.appendChild(newPopular);
      countPopular++;
    }
  });

  shows.forEach((show) => {
    let find = "tvshow.html?" + show.id;

    let explore = `<a href="${find}">
                      <div class="card">
                          <img src="img/${show.poster}" alt="">
                          <h3>${show.name}</h3>
                      </div>
                  </a>`;

    if (getShowsExploreContainer != null && countExplore <= 5) {
      const getShowsExploreContainer = document.getElementById("cards-explore");
      const newExplore = document.createElement("a");
      newExplore.innerHTML = explore;
      getShowsExploreContainer.appendChild(newExplore);
      countExplore++;
    }
  });
}

function logout() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
