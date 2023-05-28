const getShowsTable = document.getElementById("table");
const addSeasonsForm = document.getElementById("form");

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const seasonsUrl = "/seasons";

const showId = sessionStorage.getItem("addShowId");
const url = portUrl + showsUrl + showId + seasonsUrl;

const id = sessionStorage.getItem("id");

if (!id) {
  window.location = "login.html";
}

const nameValue = document.getElementById("name-input");
const numberEpisodesValue = document.getElementById("number-episodes-input");
const durationEpisodesValue = document.getElementById(
  "duration-episodes-input"
);

addSeasonsForm.addEventListener("submit", (e) => {
  e.preventDefault();

  fetch(url, {
    method: "POST",
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
      if (!res.ok) {
        throw new Error("Post failed");
      }
      swal({
        title: "Success!",
        text: "The tv show has been successfully created!",
        icon: "success",
        button: "Ok",
      }).then(() => {
        addSeasonsForm.reset();
        window.location = "admin-seasons.html?" + showId;
      });
    })
    .then((data) => {
      const dataArray = [];
      dataArray.push(data);
      getSeason(dataArray);
    })
    .catch((error) => console.error(error));
});

function getSeason(seasons) {
  let count = 1;
  seasons.forEach((season) => {
    let episodesUrl = "admin-episodes.html?" + showId + "?" + season.id;
    let row = `<tr>
                      <th id="index">${count}</th>
                      <td id="name"><a href="${episodesUrl}">${season.name}</td>
                      <td id="number-episodes">${season.numberOfEpisodes}</td>
                      <td id="duration-episodes">${season.durationEpisode}</td>
                      <td>
                          <button id="delete-season" class="button-delete" onclick="deleteSeason(${season.id},${season.TVShowId})"> <i class="fa-solid fa-trash"></i></button>
                      </td>
                      <td>
                          <button id="edit-season" class="button-edit" onclick="editSeason(${season.id},${season.TVShowId},'${season.name}',${season.numberOfEpisodes},${season.durationEpisode})"><i class="fa-solid fa-pen"></i></button>
                      </td>
                  </tr>`;

    if (getSeasonsTable != null) {
      const getSeasonsTable = document.getElementById("table");
      const newRow = document.createElement("tr");
      newRow.innerHTML = row;
      getSeasonsTable.appendChild(newRow);
      count++;
    }
  });

  if (seasons.length == 0 || getSeasonsTable.innerHTML === "") {
    noData.innerText = "There are no seasons!";
  }
}

// BUTTONS

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
