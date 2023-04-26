const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows";

const id = sessionStorage.getItem("showId");
const name = sessionStorage.getItem("name");
const year = sessionStorage.getItem("year");
const audience = sessionStorage.getItem("audience");
const seasons = sessionStorage.getItem("seasons");
const genre = sessionStorage.getItem("genre");
const showStatus = sessionStorage.getItem("status");
const description = sessionStorage.getItem("description");
const streaming = sessionStorage.getItem("streaming");
const likes = sessionStorage.getItem("likes");
const newseason = sessionStorage.getItem("newseason");

if (!id) {
  window.location = "login.html";
}

const nameValue = document.getElementById("name-input");
const yearValue = document.getElementById("year-input");
const audienceValue = document.getElementById("audience-input");
const seasonsValue = document.getElementById("seasons-input");
const genreValue = document.getElementById("genre-input");
const statusValue = document.getElementById("status-input");
const descriptionValue = document.getElementById("description-input");
const streamingValue = document.getElementById("streaming-input");
const likesValue = document.getElementById("likes-input");
const newSeasonValue = document.getElementById("newseason-input");

const buttonSave = document.getElementById("button");

const url = portUrl + showsUrl + "/" + `${id}`;

nameValue.value = name;
yearValue.value = year;
audienceValue.value = audience;
seasonsValue.value = seasons;
genreValue.value = genre;
descriptionValue.value = description;
likesValue.value = likes;
newSeasonValue.value = newseason;

for (let i = 0; i < statusValue.options.length; i++) {
  if (statusValue.options[i].value === showStatus) {
    statusValue.options[i].selected = true;
    break;
  }
}

for (let i = 0; i < streamingValue.options.length; i++) {
  if (streamingValue.options[i].value === streaming) {
    streamingValue.options[i].selected = true;
    break;
  }
}

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
          name: nameValue.value,
          year: yearValue.value,
          audience: audienceValue.value,
          seasons: seasonsValue.value,
          genre: genreValue.value,
          status: statusValue.value,
          description: descriptionValue.value,
          streaming: streamingValue.value,
          likes: likesValue.value,
          newSeason: newSeasonValue.value,
        }),
      })
        .then((res) => {
          if (res.status === 204) {
            window.location = "admin-tvshows.html";
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
