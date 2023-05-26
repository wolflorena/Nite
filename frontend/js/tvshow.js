let showId = window.location.href.split("?")[1];
const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const seenEpsiodesUrl = portUrl + "/api/watched/" + id + "/" + showId + "/";
const url = portUrl + showsUrl + showId;
const urlFavorites = portUrl + "/api/favorites/" + id + "/" + showId;
const urlGetFav = portUrl + "/api/favorites/" + id;
const urlGetWatched = portUrl + "/api/watched/" + id;
const urlSeasons = url + "/seasons";

const getShowInfo = document.getElementById("info");
const welcomeMessage = document.getElementById("welcome-message");
const dropdown = document.getElementById("season");
const episodes = document.getElementById("episodesList");
var username_message = document.createElement("span");

username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);
var seasonId;

fetch(urlSeasons)
  .then((res) => res.json())
  .then((data) => {
    var test = data[0].id;

    data.forEach((element) => {
      let season = `<option value="${element.id}">${element.name}</option> `;

      if (dropdown != null) {
        const dropdown = document.getElementById("season");
        const newSeason = document.createElement("option");
        newSeason.innerHTML = season;
        dropdown.appendChild(newSeason);
      }
    });
    fetch(urlSeasons + "/" + test + "/episodes")
      .then((res) => res.json())
      .then((data) => {
        data.forEach((element) => {
          let episode = `<div class="episode">
                        <li>${element.name}</li>
                        <button class="check" onclick="episodeSeen(${element.id}, ${element.seasonId})">
                          <i id="${element.id}" class="fa-solid fa-circle-check fa-2xl" style="color:rgb(238, 238, 238)"></i>
                        </button>
                      </div> `;

          if (episodes != null) {
            const episodes = document.getElementById("episodesList");
            const newEpisode = document.createElement("div");
            newEpisode.innerHTML = episode;
            episodes.appendChild(newEpisode);
          }

          fetch(urlGetWatched)
            .then((res) => res.json())
            .then((data) => {
              var seenIcon = document.getElementById(element.id);

              data.forEach((e) => {
                if (element.id == e.episodeId) {
                  seenIcon.style.color = "rgb(255, 211, 105)";
                }
              });
            });
        });
      });
    dropdown.addEventListener("change", function () {
      data.forEach((element) => {
        if (element.name === dropdown.value) {
          seasonId = element.id;
        }
      });
      episodesList.innerHTML = "";
      fetch(urlSeasons + "/" + seasonId + "/episodes")
        .then((res) => res.json())
        .then((data) => {
          data.forEach((element) => {
            let episode = `<div class="episode">
                            <li>${element.name}</li>
                            <button class="check" onclick="episodeSeen(${element.id}, ${seasonId})">
                              <i id="${element.id}" class="fa-solid fa-circle-check fa-2xl" style="color:rgb(238, 238, 238)"></i>
                            </button>
                          </div> `;

            if (episodes != null) {
              const episodes = document.getElementById("episodesList");
              const newEpisode = document.createElement("div");
              newEpisode.innerHTML = episode;
              episodes.appendChild(newEpisode);
            }

            fetch(urlGetWatched)
              .then((res) => res.json())
              .then((data) => {
                var seenIcon = document.getElementById(element.id);

                data.forEach((e) => {
                  if (element.id == e.episodeId) {
                    seenIcon.style.color = "rgb(255, 211, 105)";
                  }
                });
              });
          });
        });
    });
  });

fetch(url)
  .then((res) => res.json())
  .then((data) => {
    getShow(data);
    fetch(urlGetFav)
      .then((res) => res.json())
      .then((data) => {
        var heartIconStorage = document.getElementById("heart-icon");

        data.forEach((element) => {
          if (element.tvShowId == showId) {
            heartIconStorage.classList.remove("fa-regular");
            heartIconStorage.classList.add("fa-solid");
          }
        });
      });
  });

function getShow(show) {
  let info = `<img src="img/${show.logo}" alt="" class="title">
            <div class="first-child" id="first-child">
                <ul class="general">
                    <li>${show.year}</li>
                    <li>${show.audience}</li>
                    <li>${show.seasons} Seasons</li>
                    <li>${show.status}</li>
                </ul>
                <img src="img/${show.streaming}.png" alt="">
                <button class="heart" onclick="toggleHeart();"><i id="heart-icon" class="fa-regular fa-heart fa-2x"></i></button>
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

function toggleHeart() {
  var heartIcon = document.getElementById("heart-icon");
  if (heartIcon.classList.contains("fa-regular")) {
    heartIcon.classList.remove("fa-regular");
    heartIcon.classList.add("fa-solid");

    fetch(urlFavorites, {
      method: "POST",
      headers: {
        "content-type": "application/json; charset=UTF-8",
      },
      body: JSON.stringify({
        TVShowId: showId,
        UserId: id,
      }),
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("Post failed");
        }
      })
      .catch((error) => console.error(error));
  } else if (heartIcon.classList.contains("fa-solid")) {
    heartIcon.classList.remove("fa-solid");
    heartIcon.classList.add("fa-regular");

    fetch(urlFavorites, {
      method: "DELETE",
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("Delete failed");
        }
      })

      .catch((error) => console.error(error));
  }
}

function episodeSeen(episodeID, seasonId) {
  var seenIcon = document.getElementById(episodeID);

  if (seenIcon.style.color === "rgb(238, 238, 238)") {
    // console.log("caca");
    seenIcon.style.color = "rgb(255, 211, 105)";

    fetch(seenEpsiodesUrl + seasonId + "/" + episodeID, {
      method: "POST",
      headers: {
        "content-type": "application/json; charset=UTF-8",
      },
      body: JSON.stringify({
        UserId: id,
        TVShowId: showId,
        SeasonId: seasonId,
        EpisodeId: episodeID,
      }),
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("Post failed");
        }
      })
      .catch((error) => console.error(error));
  } else if (seenIcon.style.color === "rgb(255, 211, 105)") {
    seenIcon.style.color = "rgb(238, 238, 238)";

    fetch(seenEpsiodesUrl + seasonId + "/" + episodeID, {
      method: "DELETE",
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("Delete failed");
        }
      })

      .catch((error) => console.error(error));
  }
}

const sliders = document.querySelector(".listOfEpisodes");
const downArrow = document.getElementById("down");
const upArrow = document.getElementById("up");
var scrollPerClick = 350;
var scrollAmount = 0;
var clicks = 0;

function sliderScrollUp() {
  sliders.scrollTo({
    top: (scrollAmount -= scrollPerClick),
    behavior: "smooth",
  });

  if (scrollAmount < 0) {
    scrollAmount = 0;
  }
}

function sliderScrollDown() {
  if (scrollAmount <= sliders.scrollHeight - sliders.clientHeight) {
    sliders.scrollTo({
      top: (scrollAmount += scrollPerClick),
      behavior: "smooth",
    });
  }
}

function logout() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
