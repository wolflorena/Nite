const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

//const portUrl = "https://localhost:7053";
//const showsUrl = "/api/shows";
//const url = portUrl + showsUrl;
const getShowsPopularContainer = document.getElementById("cards-popular");
const getShowsExploreContainer = document.getElementById("cards-explore");
const welcomeMessage = document.getElementById("welcome-message");

var username_message = document.createElement("span");
username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);

function logout() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
