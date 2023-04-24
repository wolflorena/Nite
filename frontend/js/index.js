const id = sessionStorage.getItem("idUser");

if (!id) {
  window.location = "login.html";
}

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows";
const url = portUrl + showsUrl;
const getShowsPopularContainer = document.getElementById("cards-popular");
const getShowsExploreContainer = document.getElementById("cards-explore");

fetch(url)
  .then((res) => res.json())
  .then((data) => {
    getShow(data);
  });

function getShow(shows) {
  let countPopular = 1;
  let countExplore = 1;

  let popularShowsSort = [...shows].sort((s1, s2) =>
    s1.year < s2.year ? 1 : s1.year > s2.year ? -1 : 0
  );

  popularShowsSort.forEach((show) => {
    let find = "tvshow.html?" + show.id;
    let popular = `<a href="${find}">
                    <div class="card">
                        <img src="/frontend/img/card_controlz.png" alt="">
                        <h3>${show.name}</h3>
                    </div>
                </a>`;

    if (getShowsPopularContainer != null && countPopular <= 8) {
      const getShowsPopularContainer = document.getElementById("cards-popular");
      const newPopular = document.createElement("a");
      newPopular.innerHTML = popular;
      getShowsPopularContainer.appendChild(newPopular);
      countPopular++;
    }
  });

  shows.forEach((show) => {
    let explore = `<a href="tvshow.html">
                      <div class="card">
                          <img src="/frontend/img/card_controlz.png" alt="">
                          <h3>${show.name}</h3>
                      </div>
                  </a>`;

    if (getShowsExploreContainer != null && countExplore <= 8) {
      const getShowsExploreContainer = document.getElementById("cards-explore");
      const newExplore = document.createElement("a");
      newExplore.innerHTML = explore;
      getShowsExploreContainer.appendChild(newExplore);
      countExplore++;
    }
  });
}

function logout() {
  setTimeout(function () {
    document.location.href = "login.html";
  }, 250);
  sessionStorage.clear();
}
