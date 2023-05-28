const [, showId, seasonId] = window.location.href.split("?");

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const seasonsUrl = "/seasons/";
const episodesUrl = "/episodes";

const url = portUrl + showsUrl + showId + seasonsUrl + seasonId + episodesUrl;

const id = sessionStorage.getItem("id");

if (!id) {
  window.location = "login.html";
}

const getEpisodesTable = document.getElementById("table");

fetch(url)
  .then((res) => res.json())
  .then((data) => getEpisode(data));

const noData = document.getElementById("no-data");

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

function deleteEpisode(episodeId) {
  const deleteUrl = url + "/" + `${episodeId}`;

  swal({
    title: "Are you sure?",
    text: "Once deleted, you will not be able to recover this data!",
    icon: "warning",
    buttons: true,
    dangerMode: true,
  }).then((willDelete) => {
    if (willDelete) {
      fetch(deleteUrl, {
        method: "DELETE",
      })
        .then((res) => {
          if (!res.ok) {
            throw new Error("Delete failed");
          }
        })
        .then(() => location.reload())
        .catch((error) => console.error(error));
    }
  });
}

function editEpisode(episodeId, seasonId, showId, name) {
  sessionStorage.setItem("episodeId", episodeId);
  sessionStorage.setItem("seasonId", seasonId);
  sessionStorage.setItem("showId", showId);
  sessionStorage.setItem("name", name);

  window.location = "admin-editepisode.html";
}

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}

function addEpisode() {
  window.location = "admin-addepisode.html";
  sessionStorage.setItem("addShowId", showId);
  sessionStorage.setItem("addSeasonId", seasonId);
}
