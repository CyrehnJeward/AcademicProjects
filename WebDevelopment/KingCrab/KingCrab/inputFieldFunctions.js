
function showPassword(variable) {
    var x = document.getElementById(variable);
    if (x.type === "password") {
      x.type = "text";
    } else {
      x.type = "password";
    }
  }

  function check_pass() {
    if (document.getElementById('psw').value ==
            document.getElementById('psw2').value) {
        document.getElementById('submit').hidden = false;
    } else {
        document.getElementById('submit').hidden = true;
    }
}

function sessionStorageCheckID(){
  if(sessionStorage.getItem("ID") === null){
    window.location.href = "Loginform.html";
 }
}

function setIDtoSessionStorage(){
  
  const queryString = window.location.search;
  const urlParams = new URLSearchParams(queryString);
  if(urlParams.has('ID')){

    var userID =  urlParams.get("ID");
    if(userID == null){
      window.location.href = "Loginform.html"
    }else{
      sessionStorage.setItem("ID",userID);
    }
  }else{
    if(sessionStorage.getItem("ID")!= null){
      
    }
  }
}

// function check_Balance(){
//   let balance = parseInt(document.getElementById("balance").textContent);
//   if(document.getElementById("amount").value > balance){
//     document.getElementById("submit").textContent = "AMOUNT EXCEEDS BALANCE";
//     document.getElementById('submit').disabled = true;
//   }else{
//     document.getElementById('submit').textContent ="Transfer";
//     document.getElementById('submit').disabled = false;
   

//   }
  
// }

function cancelToDashboard(){
  window.location.href = "CustomerLoginDashboard.html";

}

function check_EmailVerified() {
  if (document.getElementById('emailVerified').value === "Email verified"
          ) {
      document.getElementById('verifyEmail').hidden = false;
  } else {
      document.getElementById('verifyEmail').hidden = true;
  }
}

function cancelonClick(){
  window.location.href = "LoginForm.html";

}






