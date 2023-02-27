window.onload = function()
{
WHDashboard();
}


function WHDashboard() {
    //Actual login
    let url = "API/OrderService.php"; // REST-style: URL refers to an entity or collection, not an action
    let xmlhttp = new XMLHttpRequest();
    let method = "GET";
    xmlhttp.onreadystatechange = function () {
      if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
        let resp = xmlhttp.responseText;
        console.log(resp);
        initialSetup(resp);
      }
      else
      {
        console.log(XMLHttpRequest.responseText);
        console.log("No data found.");
      }
    };
    xmlhttp.open(method, url, true); // method is either POST or PUT
    xmlhttp.send();
  }
function getOrders()
{

}
function showOrders()
{

}

function fulfilOrder()
{
    pass 
}

function recieveOrder()
{
//Grab the table 
}

function backend(method,list)
{

}