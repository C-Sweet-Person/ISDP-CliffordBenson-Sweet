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

}

function showHide()
{
    let password = document.querySelector("#password");
    let bool = password.type === "password" ? "text":"password";
    password.type = bool;
}