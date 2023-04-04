const portUrl = "https://localhost:7053";
const usersUrl = "/api/users";
const url = portUrl + usersUrl;

const id = sessionStorage.getItem("id");

if (!id) {
  window.location = "login.html";
}

const getUsersTable = document.getElementById("table");

fetch(url)
  .then((res) => res.json())
  .then((data) => getUser(data));

const noData = document.getElementById("no-data");

function getUser(users) {
  let count = 1;
  users.forEach((user) => {
    let row = `<tr>
                    <th id="index">${count}</th>
                    <td id="username">${user.username}</td>
                    <td id="email">${user.email}</td>
                    <td id="admin">${user.isAdmin}</td>
                    <td>
                        <button id="delete-user" class="button-delete" onclick="deleteUser(${user.id})"> <i class="fa-solid fa-trash"></i></button>
                    </td>
                    <td>
                        <button id="edit-user" class="button-edit" onclick="editUser()"><i class="fa-solid fa-pen"></i></button>
                    </td>
                </tr>`;

    if (getUsersTable != null) {
      const getUsersTable = document.getElementById("table");
      const newRow = document.createElement("tr");
      newRow.innerHTML = row;
      getUsersTable.appendChild(newRow);
      count++;
    }
  });

  if (users.length == 0 || getUsersTable.innerHTML === "") {
    noData.innerText = "There are no users!";
  }
}

// BUTTONS

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
