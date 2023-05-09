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
                    <td id="gender">${user.gender}</td>
                    <td id="birthdate">${user.birthdate}</td>
                    <td id="admin">${user.isAdmin}</td>
                    <td>
                        <button id="delete-user" class="button-delete" onclick="deleteUser(${user.id})"> <i class="fa-solid fa-trash"></i></button>
                    </td>
                    <td>
                        <button id="edit-user" class="button-edit" onclick="editUser(${user.id},'${user.username}','${user.email}', '${user.gender}', '${user.birthdate}', ${user.isAdmin},'${user.password}')"><i class="fa-solid fa-pen"></i></button>
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

function deleteUser(userId) {
  const deleteUrl = url + "/" + `${userId}`;

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

function editUser(userId, username, email, gender, birthdate, admin, password) {
  sessionStorage.setItem("userId", userId);
  sessionStorage.setItem("username", username);
  sessionStorage.setItem("email", email);
  sessionStorage.setItem("gender", gender);
  sessionStorage.setItem("birthdate", birthdate);
  sessionStorage.setItem("admin", admin);
  sessionStorage.setItem("password", password);

  window.location = "admin-edituser.html";
}

// BUTTONS

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
