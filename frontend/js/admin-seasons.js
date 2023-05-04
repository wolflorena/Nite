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
    let row = `<tr>
                    <th id="index">${count}</th>
                    <td id="name">${season.name}</td>
                    <td id="numberofepisodes">${season.numberOfEpisodes}</td>
                    <td id="durationepisode">${season.durationEpisode}</td>
                    <td>
                        <button id="delete-season" class="button-delete" onclick="deleteSeason()"> <i class="fa-solid fa-trash"></i></button>
                    </td>
                    <td>
                        <button id="edit-season" class="button-edit" onclick="editSeason()"><i class="fa-solid fa-pen"></i></button>
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

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
