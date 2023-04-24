const imgs = [];

imgs[0] = "img/ahs.jpg";
imgs[1] = "img/breakingBad.jpg";
imgs[2] = "img/wednesday.jpg";
imgs[3] = "img/witcher.jpg";
imgs[4] = "img/vikings.jpg";
imgs[5] = "img/marvel.jpg";
imgs[6] = "img/you.jpg";
imgs[7] = "img/girlBefore.jpg";
imgs[8] = "img/kaleidoscope.jpg";

window.onload = function () {
  const random = Math.floor(Math.random() * imgs.length);

  document.body.style.backgroundImage = `url(${imgs[random]})`;
};

const url = "https://localhost:7053/api/login";

const form = document.getElementById("form");
const username = document.getElementById("username");
const password = document.getElementById("password");

const error = document.getElementById("error");

form.addEventListener("submit", (e) => {
  e.preventDefault();
  let messages = [];
  validateInputs(messages);

  if (messages.length > 0) {
    alert.innerText = messages.join("\n");
  }

  if (messages.length == 0) {
    sendCredentials(username, password);
  }
});

function sendCredentials(username, password) {
  const hashedPassword = CryptoJS.SHA256(password.value).toString(
    CryptoJS.enc.Hex
  );
  fetch(url, {
    method: "POST",
    headers: {
      "content-type": "application/json; charset=UTF-8",
    },
    body: JSON.stringify({
      username: username.value,
      password: hashedPassword,
    }),
  })
    .then((res) => {
      if (!res.ok) {
        alert("This account doesn't exist!");
        throw new Error("Login failed");
      }
      alert.innerText = "";
      return res.json();
    })
    .then((data) => {
      if (data.isAdmin == true) {
        sessionStorage.setItem("id", data.id);
        document.location.href = "admin-index.html";
      } else {
        sessionStorage.setItem("idUser", data.id);
        document.location.href = "index.html";
      }
    })
    .catch((error) => console.error(error));
}

function validateInputs(messages) {
  if (username.value === "" || username.value === null) {
    messages.push("Username is required!");
  }

  if (password.value === "" || password.value === null) {
    messages.push("Password is required!");
  }
}
