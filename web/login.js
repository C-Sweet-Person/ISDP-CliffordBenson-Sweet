window.onload = (event) => {
    document.querySelector("#loginBtn").addEventListener("click",login);
    document.querySelector("#passwordVisibility").addEventListener("click",showHide);
  };



function login()
{
    //Set variables.
    let username = document.querySelector("#username");
    let password = document.querySelector("#password");
    console.log(username.value,password.value);
    //Place into object
    let account = {"username":username.value,"password":password.value};
    console.log(account);
    //Actual login
    let url = "API/UserService.php"; // REST-style: URL refers to an entity or collection, not an action
    let xmlhttp = new XMLHttpRequest();
    let obj = {
        "username": username,
        "password": password
    };
    let method = "POST";
     xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
            let resp = xmlhttp.responseText;
                console.log(resp);
                if (resp === "1")
                {
                   alert("Dashboard page not done yet.");
                }
        }
    }
    xmlhttp.open(method, url, true); // method is either POST or PUT
    xmlhttp.send(JSON.stringify(obj));
  }


function showHide()
{
    let password = document.querySelector("#password");
    let bool = password.type === "password" ? "text":"password";
    password.type = bool;
}

//