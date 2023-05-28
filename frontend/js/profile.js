const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

const welcomeMessage = document.getElementById("welcome-message");

const container = document.getElementById("credential");
const title = document.getElementById("username");
const totalWatchTime = document.getElementById("totalWatchTime");
const totalWatchEpisodes = document.getElementById("totalWatchEpisodes");
const totalWatchedSeries = document.getElementById("totalWatchedSeries");
const totalCurrently = document.getElementById("totalCurrently");

var username_message = document.createElement("span");
username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);

const portUrl = "https://localhost:7053";
const userUrl = "/api/users/";
const url = portUrl + userUrl + id;
const watchedUrl = "/api/watched/";
const urlWatched = portUrl + watchedUrl + id;
const urlShows = portUrl + "/api/shows/";

fetch(url)
  .then((res) => res.json())
  .then((data) => {
    let user = `<h1>${data.username}</h1>
                <h1>${data.email}</h1>
                <span>
                  <span>
                    <h1>${data.gender}</h1>
                  </span>
                </span>
                <span>
                  <h1>${data.birthdate}</h1>
                </span>`;
    if (container != null) {
      const newUser = document.createElement("div");
      newUser.innerHTML = user;
      container.appendChild(newUser);
    }
    title.innerHTML = data.username;
  });

fetch(urlWatched) //EPISOADE VAZUTE
  .then((res) => res.json())
  .then((data) => {
    getWatchedEpisodes(data).then((watched) => {
      totalWatchTime.innerHTML = convertMinutesToFormat(watched[0]);
      totalWatchEpisodes.innerHTML = watched[1];
    });
    getSeries(data).then((arr) => {
      totalCurrently.innerHTML = arr[1];
      totalWatchedSeries.innerHTML = arr[0];
    });
  });

async function getWatchedEpisodes(data) {
  let totalTime = 0;
  let totalEpisodes = 0;

  for (const element of data) {
    const res = await fetch(
      urlShows + element.tvShowId + "/seasons/" + element.seasonId
    );
    const responseData = await res.json();
    totalTime += responseData.durationEpisode;
    totalEpisodes++;
  }
  let watched = [totalTime, totalEpisodes];
  return watched;
}

async function getSeries(data) {
  let countSeries = 0;
  let countWatching = 0;

  const uniqueKeys = new Set();

  data.forEach((obj) => {
    uniqueKeys.add(obj.tvShowId);
  });

  const uniqueForeignKeys = Array.from(uniqueKeys);

  for (const show of uniqueForeignKeys) {
    const res = await fetch(urlShows + show);
    const showData = await res.json();
    const total = await getTotalEpisodes(show);

    const resWatched = await fetch(urlWatched);
    const watchedData = await resWatched.json();
    const dataSorted = [...watchedData].sort((s1, s2) =>
      s1.tvShowId < s2.tvShowId ? 1 : s1.tvShowId > s2.tvShowId ? -1 : 0
    );

    let watchedEpisodes = 0;
    dataSorted.forEach((e) => {
      if (e.tvShowId === show) {
        watchedEpisodes++;
      }
    });

    let procent = (watchedEpisodes * 100) / total;

    if (procent < 100) {
      countWatching++;
    }

    if (procent == 100) {
      countSeries++;
    }
  }

  let arr = [countWatching, countSeries];
  return arr;
}

async function getTotalEpisodes(show) {
  var totalEpisodes = 0;
  await fetch(urlShows + show + "/seasons")
    .then((res) => res.json())
    .then((data) => {
      data.forEach((season) => {
        totalEpisodes += season.numberOfEpisodes;
      });
    });
  return totalEpisodes;
}

function convertMinutesToFormat(minutes) {
  const minutesPerHour = 60;
  const hoursPerDay = 24;
  const minutesPerDay = minutesPerHour * hoursPerDay;
  const minutesPerMonth = minutesPerDay * 30; // Assuming 30 days per month

  var totalMonths = Math.floor(minutes / minutesPerMonth);
  var totalDays = Math.floor((minutes % minutesPerMonth) / minutesPerDay);
  var totalHours = Math.floor((minutes % minutesPerDay) / minutesPerHour);

  if (totalMonths < 10) {
    totalMonths = String(totalMonths).padStart(2, "0");
  }

  if (totalDays < 10) {
    totalDays = String(totalDays).padStart(2, "0");
  }

  if (totalHours < 10) {
    totalHours = String(totalHours).padStart(2, "0");
  }

  return `${totalMonths} ${totalDays} ${totalHours} `;
}

function logout() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
