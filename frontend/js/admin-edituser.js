const portUrl = "https://localhost:7053";
const usersUrl = "/api/users";

const id = sessionStorage.getItem("userId");
const username = sessionStorage.getItem("username");
const email = sessionStorage.getItem("email");
const admin = sessionStorage.getItem("admin");
const password = sessionStorage.getItem("password");

if (!id) {
  window.location = "login.html";
}

const usernameValue = document.getElementById("username-input");
const emailValue = document.getElementById("email-input");
const adminValue = document.getElementById("admin-input");

const buttonSave = document.getElementById("button");

const url = portUrl + usersUrl + "/" + `${id}`;

usernameValue.value = username;
emailValue.value = email;

for (let i = 0; i < adminValue.options.length; i++) {
  if (adminValue.options[i].value === admin) {
    adminValue.options[i].selected = true;
    break;
  }
}

buttonSave.addEventListener("click", (e) => {
  e.preventDefault();

  console.log(usernameValue.value);
  console.log(emailValue.value);
  console.log(adminValue.value);
  console.log(password);

  swal({
    title: "Are you sure?",
    text: "Once edited, you will not be able to recover this data!",
    icon: "warning",
    buttons: true,
    dangerMode: true,
  }).then((willEdit) => {
    if (willEdit) {
      fetch(url, {
        method: "PUT",
        headers: {
          "content-type": "application/json; charset=UTF-8",
        },
        body: JSON.stringify({
          username: usernameValue.value,
          email: emailValue.value,
          isAdmin: adminValue.value,
          password: password,
        }),
      })
        .then((res) => {
          if (res.status === 204) {
            window.location = "admin-index.html";
          } else {
            throw new Error("Put failed");
          }
        })
        .catch((error) => console.error(error));
    }
  });
});

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
