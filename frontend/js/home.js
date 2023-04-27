const block = document.getElementById("right");

const imgs = [];

imgs[0] = "img/gameofthrones_home.png";
imgs[1] = "img/avatar_home.png";
imgs[2] = "img/bigbangtheory_home.png";
imgs[3] = "img/casadepapel_home.png";

window.onload = function () {
  const random = Math.floor(Math.random() * imgs.length);

  var img = document.createElement("img");
  img.src = imgs[random];
  block.appendChild(img);
};

function getstarted() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
