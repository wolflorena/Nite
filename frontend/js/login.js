const imgs = [];

imgs[0] = "img/ahs.jpg";
imgs[1] = "img/breakingBad.jpg";
imgs[2] = "img/wednesday.jpg";
imgs[3] = "img/witcher.jpg";
imgs[4] = "img/vikings.jpg";
imgs[5] = "img/marvel.jpg";

window.onload = function () {
  const random = Math.floor(Math.random() * imgs.length);

  document.body.style.backgroundImage = `url(${imgs[random]})`;
};
