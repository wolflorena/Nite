const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const seasonsUrl = "/seasons/";

const id = sessionStorage.getItem("id");

const showId = sessionStorage.getItem("showId");
const seasonId = sessionStorage.getItem("seasonId");
const name = sessionStorage.getItem("name");
const numberEpisodes = sessionStorage.getItem("numberEpisodes");
const durationEpisodes = sessionStorage.getItem("durationEpisodes");

if (!id) {
  window.location = "login.html";
}

const nameValue = document.getElementById("name-input");
const numberEpisodesValue = document.getElementById("number-episodes-input");
const durationEpisodesValue = document.getElementById(
  "duration-episodes-input"
);
const buttonSave = document.getElementById("button");

const url = portUrl + showsUrl + showId + seasonsUrl + seasonId;

nameValue.value = name;
numberEpisodesValue.value = numberEpisodes;
durationEpisodesValue.value = durationEpisodes;

buttonSave.addEventListener("click", (e) => {
  e.preventDefault();

  swal({
    title: "Are you sure?",
    text: "Once edited, you will not be able to recover this data!",
    icon: "warning",
    buttons: true,
    dangerMode: true,
  }).then((willEdit) => {
    if (willEdit) {
      fetch(url, {
        method: "PUT",
        headers: {
          "content-type": "application/json; charset=UTF-8",
        },
        body: JSON.stringify({
          TVShowId: showId,
          name: nameValue.value,
          numberOfEpisodes: numberEpisodesValue.value,
          durationEpisode: durationEpisodesValue.value,
        }),
      })
        .then((res) => {
          if (res.status === 204) {
            window.location = "admin-seasons.html?" + showId;
          } else {
            throw new Error("Put failed");
          }
        })
        .catch((error) => console.error(error));
    }
  });
});

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
