window.onload = (event) => {
   
    invDashboard();
    };

function invDashboard()
{
    let url = "API/inventoryService.php"; // REST-style: URL refers to an entity or collection, not an action
    let xmlhttp = new XMLHttpRequest();
    let method = "GET";
    xmlhttp.onreadystatechange = function () {
      if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
        let resp = xmlhttp.responseText;
        console.log(resp);
        getItems(resp);
      }
    
    };
    xmlhttp.open(method, url, true); // method is either POST or PUT
    xmlhttp.send(); 
}
////////
/////////
function getItems(resp)
{
  let table = document.querySelector("#tableItems")
  let logs = JSON.parse(resp);
  //This is for easieness.
  //
  //
  let htmltemp = "";
  htmltemp += "<tr>"
  htmltemp += "<th>ID</th>";
  htmltemp += "<th>Name</th>";
  htmltemp += "<th>siteID</th>"
  htmltemp += "<th>quantity</th>"
  htmltemp += "<th>itemLocation</th>"
  htmltemp += "<th>reorderThreshold</th>"
  htmltemp+= "</tr>"
  table.innerHTML += htmltemp;
  //
  //
  //End of organization section.

  for (let i = 0; i < 200; i++)
  {
    table.innerHTML += trCreation(logs[i]);
    console.log(logs[i])
  }
  console.log(table.innerHTML);
}
///////////
///////////  

function trCreation(row)
{
html = "<tr>";
  html += `<td>${row['itemID']}</td>`
  html += `<td>${row['itemName']}</td>`
  html += `<td>${row['siteID']}</td>`
  html += `<td>${row['quantity']}</td>`
  html += `<td>${row['itemLocation']}</td>`
  html += `<td>${row['reorderThreshold']}</td>`
html += "</tr>";
return html;
}