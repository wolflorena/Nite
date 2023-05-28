const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const seasonsUrl = "/seasons/";
const episodesUrl = "/episodes/";

const id = sessionStorage.getItem("id");

const showId = sessionStorage.getItem("showId");
const seasonId = sessionStorage.getItem("seasonId");
const episodeId = sessionStorage.getItem("episodeId");
const name = sessionStorage.getItem("name");

if (!id) {
  window.location = "login.html";
}

const nameValue = document.getElementById("name-input");

const buttonSave = document.getElementById("button");

const url =
  portUrl + showsUrl + showId + seasonsUrl + seasonId + episodesUrl + episodeId;

nameValue.value = name;

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
          SeasonId: seasonId,
          TVShowId: showId,
          name: nameValue.value,
        }),
      })
        .then((res) => {
          if (res.status === 204) {
            window.location = "admin-episodes.html?" + showId + "?" + seasonId;
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
