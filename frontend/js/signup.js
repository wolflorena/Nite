const imgs = [];

imgs[0] = "/img/ahs.jpg";
// imgs[1] = "/img/breakingBad.jpg";
imgs[2] = "/img/wednesday.jpg";
imgs[3] = "/img/witcher.jpg";
imgs[4] = "/img/vikings.jpg";
imgs[5] = "/img/marvel.jpg";

window.onload = function () {
  const random = Math.floor(Math.random() * imgs.length);

  document.body.style.backgroundImage = `url(${imgs[random]})`;
};

const username = document.getElementById("username");
const email = document.getElementById("email");
const password = document.getElementById("password");
const passwordConfirm = document.getElementById("passwordConfirm");
const form = document.getElementById("form");
const url = "https://localhost:7053/api/users";
const alert = document.getElementById("alert");

form.addEventListener("submit", (e) => {
  e.preventDefault();
  let messages = [];
  validateInputs(messages);

  if (messages.length > 0) {
    alert.innerText = messages.join("\n");
  }

  if (messages.length == 0) {
    const hashedPassword = CryptoJS.SHA256(password.value).toString(
      CryptoJS.enc.Hex
    );
    swal({
      title: "Are you sure you want to complete the registration?",
      icon: "warning",
      buttons: true,
      dangerMode: true,
    }).then((willCreate) => {
      if (willCreate) {
        fetch(url, {
          method: "POST",
          headers: { "content-type": "application/json;charset=UTF-8" },
          body: JSON.stringify({
            username: username.value,
            email: email.value,
            password: hashedPassword,
          }),
        })
          .then((res) => {
            if (!res.ok) {
              throw new Error("POST failed");
            }

            form.reset();
            alert.innerText = "";
            window.location = "login.html";
          })
          .catch((error) => console.error(error));
      }
    });
  }
});

function validateInputs(messages) {
  if (username.value == null || username.value == "") {
    messages.push("Username required");
  }

  if (email.value == null || email.value == "") {
    messages.push("Email required");
  }

  if (password.value == null || password.value == "") {
    messages.push("Password required");
  } else {
    if (password.value.length < 8) {
      messages.push("Password must have at least 8 characters and 1 digit.");
    }

    if (passwordConfirm.value == null || passwordConfirm.value == "") {
      messages.push("You need to confirm your password.");
    }

    if (password.value != passwordConfirm.value) {
      messages.push("Your password doesn't match.");
    }
  }
}
