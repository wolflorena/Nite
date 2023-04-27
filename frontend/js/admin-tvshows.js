const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows";
const url = portUrl + showsUrl;

const id = sessionStorage.getItem("id");

if (!id) {
  window.location = "login.html";
}

const getShowsTable = document.getElementById("table");

fetch(url)
  .then((res) => res.json())
  .then((data) => getShow(data));

const noData = document.getElementById("no-data");

function getShow(shows) {
  let count = 1;
  shows.forEach((show) => {
    let k = "Unknown";
    if (show.newSeason != null && show.newSeason != "") k = show.newSeason;
    if (show.status != "On going") k = show.status;

    let row = `<tr>
                    <th id="index">${count}</th>
                    <td id="name">${show.name}</td>
                    <td id="year">${show.year}</td>
                    <td id="audience">${show.audience}</td>
                    <td id="seasons">${show.seasons}</td>
                    <td id="genre">${show.genre}</td>
                    <td id="status">${show.status}</td>
                    <td id="description">${show.description}</td>
                    <td id="streaming">${show.streaming}</td>
                    <td id="likes">${show.likes}</td>
                    <td id="new-season">${k}</td>
                    <td>
                        <button id="delete-user" class="button-delete" onclick="deleteShow(${show.id})"> <i class="fa-solid fa-trash"></i></button>
                    </td>
                    <td>
                        <button id="edit-user" class="button-edit" onclick="editShow(${show.id},'${show.name}',${show.year},'${show.audience}',${show.seasons},'${show.genre}','${show.status}','${show.description}','${show.streaming}',${show.likes},'${show.newSeason}')"><i class="fa-solid fa-pen"></i></button>
                    </td>
                </tr>`;

    if (getShowsTable != null) {
      const getShowsTable = document.getElementById("table");
      const newRow = document.createElement("tr");
      newRow.innerHTML = row;
      getShowsTable.appendChild(newRow);
      count++;
    }
  });

  if (shows.length == 0 || getShowsTable.innerHTML === "") {
    noData.innerText = "There are no TV shows!";
  }
}

function deleteShow(showId) {
  const deleteUrl = url + "/" + `${showId}`;

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

function editShow(
  showId,
  name,
  year,
  audience,
  seasons,
  genre,
  status,
  description,
  streaming,
  likes,
  newseason
) {
  sessionStorage.setItem("showId", showId);
  sessionStorage.setItem("name", name);
  sessionStorage.setItem("year", year);
  sessionStorage.setItem("audience", audience);
  sessionStorage.setItem("seasons", seasons);
  sessionStorage.setItem("genre", genre);
  sessionStorage.setItem("status", status);
  sessionStorage.setItem("description", description);
  sessionStorage.setItem("streaming", streaming);
  sessionStorage.setItem("likes", likes);
  sessionStorage.setItem("newseason", newseason);

  window.location = "admin-edittvshow.html";
}

// BUTTONS

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
