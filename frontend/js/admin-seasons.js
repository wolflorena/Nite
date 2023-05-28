let showId = window.location.href.split("?")[1];

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const seasonsUrl = "/seasons";

const url = portUrl + showsUrl + showId + seasonsUrl;

const id = sessionStorage.getItem("id");

if (!id) {
  window.location = "login.html";
}

const getSeasonsTable = document.getElementById("table");

fetch(url)
  .then((res) => res.json())
  .then((data) => getSeason(data));

const noData = document.getElementById("no-data");

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
                          <button id="delete-season" class="button-delete" onclick="deleteSeason(${season.id},${season.tvShowId})"> <i class="fa-solid fa-trash"></i></button>
                      </td>
                      <td>
                          <button id="edit-season" class="button-edit" onclick="editSeason(${season.id},${season.tvShowId},'${season.name}',${season.numberOfEpisodes},${season.durationEpisode})"><i class="fa-solid fa-pen"></i></button>
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

function deleteSeason(seasonId) {
  const deleteUrl = url + "/" + `${seasonId}`;

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

function editSeason(seasonId, showId, name, numberEpisodes, durationEpisodes) {
  sessionStorage.setItem("seasonId", seasonId);
  sessionStorage.setItem("showId", showId);
  sessionStorage.setItem("name", name);
  sessionStorage.setItem("numberEpisodes", numberEpisodes);
  sessionStorage.setItem("durationEpisodes", durationEpisodes);

  window.location = "admin-editseason.html";
}

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}

function addSeason() {
  window.location = "admin-addseason.html";
  sessionStorage.setItem("addShowId", showId);
}
