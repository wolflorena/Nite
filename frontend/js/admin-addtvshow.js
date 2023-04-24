const getShowsTable = document.getElementById("table");
const addShowsForm = document.getElementById("form");
console.log(getShowsTable);

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

addShowsForm.addEventListener("submit", (e) => {
  e.preventDefault();

  fetch(url, {
    method: "POST",
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
    }),
  })
    .then((res) => {
      if (!res.ok) {
        throw new Error("Post failed");
      }

      alert("The account has been successfully created!");
      addAccountsForm.reset();
      window.location = "admin-tvshows.html";
    })
    .then((data) => {
      const dataArray = [];
      dataArray.push(data);
      console.log(dataArray);
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
                      <td>
                          <button id="delete-user" class="button-delete" onclick="deleteShow(${show.id})"> <i class="fa-solid fa-trash"></i></button>
                      </td>
                      <td>
                          <button id="edit-user" class="button-edit" onclick="editShow(${show.id},'${show.name}',${show.year},'${show.audience}',${show.seasons},'${show.genre}','${show.status}','${show.description}')"><i class="fa-solid fa-pen"></i></button>
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
