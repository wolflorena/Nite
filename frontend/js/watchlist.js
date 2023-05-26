const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const watchedUrl = "/api/watched/";
const url = portUrl + watchedUrl + id;
const addedUrl = portUrl + "/api/added/" + id;

const getShowsCurrentlyContainer = document.getElementById("cards-watching");
const getShowsNotStarted = document.getElementById("cards-notStarted");
const getShowsUpToDate = document.getElementById("cards-upToDate");
const getShowsFinished = document.getElementById("cards-finished");
const welcomeMessage = document.getElementById("welcome-message");

var username_message = document.createElement("span");
username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);

fetch(url) //EPISOADE VAZUTE
  .then((res) => res.json())
  .then((data) => {
    getShow(data);
  });

function getShow(shows) {
  const uniqueKeys = new Set();

  shows.forEach((obj) => {
    uniqueKeys.add(obj.tvShowId);
  });

  const uniqueForeignKeys = Array.from(uniqueKeys);

  let countWatching = 1;
  let countUpToDate = 1;
  let countFinished = 1;

  uniqueForeignKeys.forEach((show) => {
    fetch(portUrl + showsUrl + show) //SERIALE
      .then((res) => res.json())
      .then((d) => {
        let total;
        getTotalEpisodes(show).then((result) => {
          total = result;
          fetch(url) //EPISOADE VAZUTE
            .then((res) => res.json())
            .then((data) => {
              let dataSorted = [...data].sort((s1, s2) =>
                s1.tvShowId < s2.tvShowId
                  ? 1
                  : s1.tvShowId > s2.tvShowId
                  ? -1
                  : 0
              );
              let watchedEpisodes = 0;
              dataSorted.forEach((e) => {
                if (e.tvShowId === show) watchedEpisodes++;
              });
              let procent = (watchedEpisodes * 100) / total;
              let find = "tvshow.html?" + show;
              let currently = `<a href="${find}">
                            <div class="card">
                              <img src="img/${d.poster}" alt="" />
                              <div class="pie-container">
                                <div class="pie" style="--p: ${procent}">${Math.ceil(
                procent
              )}%</div>
                              </div>
                              <h3>${d.name}</h3>
                            </div>
                          </a>`;

              if (
                getShowsCurrentlyContainer != null &&
                countWatching <= 5 &&
                procent < 100
              ) {
                const getShowsCurrentlyContainer =
                  document.getElementById("cards-watching");
                const newWatching = document.createElement("a");
                newWatching.innerHTML = currently;
                getShowsCurrentlyContainer.appendChild(newWatching);
                countWatching++;
              }

              let upToDate = `<a href="${find}">
                            <div class="card">
                              <img src="img/${d.poster}" alt="" />
                              <h3>${d.name}</h3>
                            </div>
                          </a>`;

              if (
                getShowsUpToDate != null &&
                countUpToDate <= 5 &&
                d.status == "On going" &&
                procent == 100
              ) {
                const getShowsUpToDate =
                  document.getElementById("cards-upToDate");
                const newUpToDate = document.createElement("a");
                newUpToDate.innerHTML = upToDate;
                getShowsUpToDate.appendChild(newUpToDate);
                countUpToDate++;
              }

              let finished = `<a href="${find}">
                            <div class="card">
                              <img src="img/${d.poster}" alt="" />
                              <h3>${d.name}</h3>
                            </div>
                          </a>`;

              if (
                getShowsFinished != null &&
                countFinished <= 5 &&
                (d.status == "Ended" || d.status == "Canceled") &&
                procent == 100
              ) {
                const getShowsFinished =
                  document.getElementById("cards-finished");
                const newFinished = document.createElement("a");
                newFinished.innerHTML = finished;
                getShowsFinished.appendChild(newFinished);
                countFinished++;
              }
            });
        });
      });
  });
}

async function getTotalEpisodes(show) {
  var totalEpisodes = 0;
  await fetch(portUrl + showsUrl + show + "/seasons") //SEZOANE
    .then((res) => res.json())
    .then((data) => {
      data.forEach((season) => {
        totalEpisodes += season.numberOfEpisodes;
      });
    });
  return totalEpisodes;
}

fetch(addedUrl)
  .then((res) => res.json())
  .then((data) => {
    getNotStarted(data);
  });

function getNotStarted(shows) {
  let countNotStarted = 1;

  shows.forEach((show) => {
    fetch(portUrl + showsUrl + show.tvShowId)
      .then((res) => res.json())
      .then((data) => {
        let find = "tvshow.html?" + data.id;
        let notStarted = `<a href="${find}">
                        <div class="card">
                          <img src="img/${data.poster}" alt="" />
                          <h3>${data.name}</h3>
                        </div>
                      </a>`;

        if (getShowsNotStarted != null && countNotStarted <= 5) {
          const getShowsNotStarted =
            document.getElementById("cards-notStarted");
          const newNotStarted = document.createElement("a");
          newNotStarted.innerHTML = notStarted;
          getShowsNotStarted.appendChild(newNotStarted);
          countNotStarted++;
        }
      });
  });
}
function logout() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
