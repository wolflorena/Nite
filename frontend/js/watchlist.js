const id = sessionStorage.getItem("idUser");
const username = sessionStorage.getItem("username");

if (!id) {
  window.location = "login.html";
}

const portUrl = "https://localhost:7053";
const showsUrl = "/api/shows/";
const watchedUrl = "/api/watched/";
const url = portUrl + watchedUrl + id;
const addedUrl = portUrl + "/api/added/" + id;

const getShowsCurrentlyContainer = document.getElementById("cards-watching");
const getShowsNotStarted = document.getElementById("cards-notStarted");
const welcomeMessage = document.getElementById("welcome-message");

var username_message = document.createElement("span");
username_message.innerHTML = " " + username;
welcomeMessage.appendChild(username_message);

// fetch(url)
//   .then((res) => res.json())
//   .then((data) => {
//     getShow(data);
//   });

// function getShow(shows) {
//   let countWatching = 1;

//   shows.forEach((show) => {

//     let find = "tvshow.html?" + show.id;
//     let currently = `<a href="#">
//                         <div class="card">
//                           <img src="img/card_arcane.png" alt="" />
//                           <div class="pie-container">
//                             <div class="pie" style="--p: 90">90%</div>
//                           </div>
//                           <h3>Arcane</h3>
//                         </div>
//                       </a>`;

//     if (getShowsCurrentlyContainer != null && countWatching <= 5) {
//       const getShowsCurrentlyContainer =
//         document.getElementById("cards-watching");
//       const newWatching = document.createElement("a");
//       newWatching.innerHTML = currently;
//       getShowsCurrentlyContainer.appendChild(newWatching);
//       countWatching++;
//     }
//   });
// }

fetch(addedUrl)
  .then((res) => res.json())
  .then((data) => {
    getNotStarted(data);
  });

function getNotStarted(shows) {
  let countNotStarted = 1;

  shows.forEach((show) => {
    fetch(portUrl + showsUrl + show.tvShowId)
      .then((res) => res.json())
      .then((data) => {
        let find = "tvshow.html?" + data.id;
        let notStarted = `<a href="${find}">
                        <div class="card">
                          <img src="img/${data.poster}" alt="" />
                          <h3>${data.name}</h3>
                        </div>
                      </a>`;

        if (getShowsNotStarted != null && countNotStarted <= 5) {
          const getShowsNotStarted =
            document.getElementById("cards-notStarted");
          const newNotStarted = document.createElement("a");
          newNotStarted.innerHTML = notStarted;
          getShowsNotStarted.appendChild(newNotStarted);
          countNotStarted++;
        }
      });
  });
}
function logout() {
  document.location.href = "login.html";
  sessionStorage.clear();
}
