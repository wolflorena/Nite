const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

const welcomeMessage = document.getElementById("welcome-message");

var username_message = document.createElement("span");
username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);

function logout() {
  sessionStorage.clear();
  window.location = "login.html";
}
