window.onload = function()
{
WHDashboard();
testStuff();
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
        getOrders(resp);
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

  function testStuff() {
    //Actual login
    let url = "API/OrderService.php?extra=type"; // REST-style: URL refers to an entity or collection, not an action
    let xmlhttp = new XMLHttpRequest();
    let method = "GET";
    xmlhttp.onreadystatechange = function () {
      if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
        let resp = xmlhttp.responseText;
        console.log(resp + "Lol");
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


function getOrders(resp)
{
  let table = document.querySelector("#tableItems")
  let logs = JSON.parse(resp);
  //This is for easieness.
  //
  //
  let htmltemp = "";
  htmltemp += "<tr>"
  htmltemp += "<th>ID</th>";
  htmltemp += "<th>siteIDTO</th>"
  htmltemp += "<th>siteIDFrom</th>"
  htmltemp += "<th>status</th>"
  htmltemp += "<th>shipDate</th>"
  htmltemp += "<th>txnType</th>"
  htmltemp += "<th>barCode</th>"
  htmltemp += "<th>createdDate</th>"
  htmltemp += "<th>DeliveryID</th>"
  htmltemp += "<th>emergencyDelivery</th>"
  htmltemp+= "</tr>"
  table.innerHTML += htmltemp;
  //
  //
  //End of organization section.

  for (let i = 0; i < logs.length; i++)
  {
    table.innerHTML += trCreation(logs[i]);
    console.log(logs[i])
  }
  console.log(table.innerHTML);
}

function trCreation(row)
{
html = "<tr>";
  html += `<td>${row['txnID']}</td>`
  html += `<td>${row['siteIDTo']}</td>`
  html += `<td>${row['siteIDFrom']}</td>`
  html += `<td>${row['status']}</td>`
  html += `<td>${row['shipDate']}</td>`
  html += `<td>${row['txnType']}</td>`
  html += `<td>${row['barCode']}</td>`
  html += `<td>${row['createdDate']}</td>`
  html += `<td>${row['DeliveryID']}</td>`
  html += `<td>${row['emergencyDelivery']}</td>`
html += "</tr>";
console.log(html)
return html;
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