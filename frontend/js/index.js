function logout(){
    setTimeout(function(){document.location.href = "login.html";},250);
    sessionStorage.clear();
}