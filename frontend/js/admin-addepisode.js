const getShowsTable = document.getElementById("table");
const addEpisodesForm = document.getElementById("form");

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const seasonsUrl = "/seasons/";
const episodesUrl = "/episodes";

const showId = sessionStorage.getItem("addShowId");
const seasonId = sessionStorage.getItem("addSeasonId");

const url = portUrl + showsUrl + showId + seasonsUrl + seasonId + episodesUrl;

const id = sessionStorage.getItem("id");

if (!id) {
  window.location = "login.html";
}

const nameValue = document.getElementById("name-input");

addEpisodesForm.addEventListener("submit", (e) => {
  e.preventDefault();

  fetch(url, {
    method: "POST",
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
      if (!res.ok) {
        throw new Error("Post failed");
      }
      swal({
        title: "Success!",
        text: "The episode has been successfully created!",
        icon: "success",
        button: "Ok",
      }).then(() => {
        addSeasonsForm.reset();
        window.location = "admin-episodes.html?" + showId + "?" + seasonId;
      });
    })
    .then((data) => {
      const dataArray = [];
      dataArray.push(data);
      getEpisode(dataArray);
    })
    .catch((error) => console.error(error));
});

function getEpisode(episodes) {
  let count = 1;
  episodes.forEach((episode) => {
    let row = `<tr>
                        <th id="index">${count}</th>
                        <td id="name">${episode.name}</td>
                        <td>
                            <button id="delete-episode" class="button-delete" onclick="deleteEpisode(${episode.id})"> <i class="fa-solid fa-trash"></i></button>
                        </td>
                        <td>
                            <button id="edit-episode" class="button-edit" onclick="editEpisode(${episode.id},${episode.tvShowId},${episode.seasonId},'${episode.name}')"><i class="fa-solid fa-pen"></i></button>
                        </td>
                    </tr>`;

    if (getEpisodesTable != null) {
      const getEpisodesTable = document.getElementById("table");
      const newRow = document.createElement("tr");
      newRow.innerHTML = row;
      getEpisodesTable.appendChild(newRow);
      count++;
    }
  });

  if (episodes.length == 0 || getEpisodesTable.innerHTML === "") {
    noData.innerText = "There are no episodes!";
  }
}

// BUTTONS

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
