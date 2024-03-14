const iUsername = document.getElementById("txtUsername");
const iPassword = document.getElementById("txtPassword");
const btnLogin = document.getElementById("btnLogin");

// var GetLocImage = document.getElementById("PImage").files[0].name; //lagay mo sa id ung id name ng input image

const editName = document.getElementById("nameHeader");
const editAddress = document.getElementById("headerAddress");
const editNumber = document.getElementById("headerNumber");
const editEmail = document.getElementById("headerEmail");




//#region  Verifying Credentials


function loginSubmit(){
    var userName = txtUsername.value;
    var passWord = txtPassword.value;
    if(userName == null && passWord == null){
        alert("Please enter a value");
    }
    else{
        checkLoginCreds(userName, passWord);
    }
   
}

function checkLoginCreds(user, pass){
    var lsdUser = "";
    var lsdPass = "";

    for(let x = 0; x < localStorage.length; x++){
        var key = localStorage.key(x);
        if(key === "lsd" + user){
            lsdUser = localStorage.key(x);
            lsdPass = localStorage.getItem(lsdUser);
            break;
        }
    }

    if(lsdUser === "lsd" + user && lsdPass === pass)
        {
            //document.getElementById("message").innerHTML = "Login complete!";
            sessionLogin(lsdUser, lsdPass);
            window.location.href = "editHome.html";

        }
        else
        {
            document.getElementById("message").innerHTML = "username and/or password is wrong";
        }
}
//#endregion

//SessionCredentials
function sessionLogin(user, pass){
    sessionStorage.setItem(user, pass);
}

for(let x = 0; x < localStorage.length; x++)
    {
        //#region 
        const key = localStorage.key(x);
        var temp = key;

        //insert image
        if(temp == "headerImage:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
           
            var ImageScript = '<img src="'+ value +'" class="picture">';
            // alert(ImageScript);
            document.getElementById("InsertPic").innerHTML = ImageScript;
        }

        

        else if(temp == "headerName:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            editName.innerHTML = value;
         
        }
        else if(temp == "headerAddress:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            //editAddress.innerHTML = value;
            document.getElementById("HEADERaddress").innerHTML = '<i class="fa fa-thumb-tack fa-1x"></i>'+value;
        }
        else if(temp == "headerNumber:")
        {   
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("HEADERmobile").innerHTML = '<i class="fa fa-mobile fa-1x"></i></i>' + value;
        }
        else if(temp == "headerEmail:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("HEADERemail").innerHTML = '<i class="fa fa-envelope-o fa-1x"></i>'+value;
        }
        else if(temp == "headerJobName:"){
            const value = localStorage.getItem(key);
            document.getElementById("nameJobTitle").innerHTML = value;
        }

        //#endregion
        
        //#region CategorySection
        else if(temp == "ASectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section01").innerHTML = value;
        }

        else if(temp == "BSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section02").innerHTML = value;
        }
        else if(temp == "CSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section03").innerHTML = value;
        }
        else if(temp == "DSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section04").innerHTML = value;
        }
        else if(temp == "ESectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section05").innerHTML = value;
        }
        else if(temp == "FSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section06").innerHTML = value;
        }
        else if(temp == "GSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section07").innerHTML = value;
        }
        else if(temp == "HSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            document.getElementById("Section08").innerHTML = value;
        }

        //#end region

        //#region Content
        else if(temp == "ASectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content01").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content01").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content01").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        else if(temp == "BSectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content02").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content02").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content02").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        else if(temp == "CSectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content03").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content03").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content03").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        else if(temp == "DSectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content04").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content04").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content04").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        else if(temp == "ESectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content05").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content05").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content05").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        else if(temp == "FSectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content06").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content06").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content06").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        else if(temp == "GSectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content07").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content07").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content07").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        else if(temp == "HSectionValue:"){
            var pOrder = JSON.parse(localStorage.getItem(temp));
            for(o in pOrder)
            {
                var a = o.substring(0,1);
                if(a == 'P'){
                    document.getElementById("Content08").innerHTML += pOrder[o] + "<br/>";
                }
                else if(a == 'L')
                {
                    document.getElementById("Content08").innerHTML += " ● " + pOrder[o] + "<br/>";
                }
                else if(a == 'E'){
                    document.getElementById("Content08").innerHTML += pOrder[o] + "<br/>";
                }
            }
        }
        //#end region
    }

    