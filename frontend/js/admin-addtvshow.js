const getShowsTable = document.getElementById("table");
const addShowsForm = document.getElementById("form");

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows";

const url = portUrl + showsUrl;

const id = sessionStorage.getItem("id");

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
const posterFile = document.getElementById("poster");
const bannerFile = document.getElementById("banner");
const logoFile = document.getElementById("logo");

addShowsForm.addEventListener("submit", (e) => {
  e.preventDefault();

  const poster = posterFile.files[0];
  const banner = bannerFile.files[0];
  const logo = logoFile.files[0];

  let formData = new FormData();

  formData.append("name", nameValue.value);
  formData.append("year", yearValue.value);
  formData.append("audience", audienceValue.value);
  formData.append("seasons", seasonsValue.value);
  formData.append("genre", genreValue.value);
  formData.append("status", statusValue.value);
  formData.append("description", descriptionValue.value);
  formData.append("streaming", streamingValue.value);
  formData.append("likes", likesValue.value);
  formData.append("newseason", newSeasonValue.value);
  formData.append("posterFile", poster);
  formData.append("bannerFile", banner);
  formData.append("logoFile", logo);

  fetch(url, {
    method: "POST",
    body: formData,
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
        addShowsForm.reset();
        window.location = "admin-tvshows.html";
      });
    })
    .then((data) => {
      const dataArray = [];
      dataArray.push(data);
      getShow(dataArray);
    })
    .catch((error) => console.error(error));
});

function getShow(shows) {
  let count = 1;
  shows.forEach((show) => {
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
                      <td id="new-season">${show.newSeason}</td>
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

// BUTTONS

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
