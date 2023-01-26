window.onload = (event) => {
document.querySelector("#Forward").addEventListener("click", indexForward)
document.querySelector("#Previous").addEventListener("click", indexBackward)
document.querySelector("#currentIndex").innerHTML = 0;
  Dashboard();
};
currentIndex = 0;
let items;
function Dashboard() {
  //Actual login
  let url = "API/ItemService.php"; // REST-style: URL refers to an entity or collection, not an action
  let xmlhttp = new XMLHttpRequest();
  let method = "GET";
  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
      let resp = xmlhttp.responseText;
      console.log(resp);
      initialSetup(resp);
    }
  };
  xmlhttp.open(method, url, true); // method is either POST or PUT
  xmlhttp.send();
}
//   $itemID = $r['itemID'];
//                 $name = $r['name'];
//                 $description = $r['description'];
//                 $category = $r['category'];
//                 $weight = $r['weight'];
//                 $costPrice = $r['costPrice'];
//                 $retailPrice = $r['retailPrice'];
//                 $supplierID = $r['supplierID'];
//                 $active = $r['active'];
//                 $notes = $r['notes'];
//                 $caseSize = $r['caseSize'];
function initialSetup(resp)
{
items = JSON.parse(resp);
tableItemCreation();
}
function indexForward()
{
if (!(currentIndex+100 > items.length))
{
currentIndex += 100;
let cIndex = document.querySelector("#currentIndex");
cIndex.innerHTML = currentIndex;
tableItemCreation();
}
else
{
    let cIndex = document.querySelector("#currentIndex");
    cIndex.innerHTML = "End of list."; 
}
}
function indexBackward()
{
    if (!(currentIndex == 0))
    {
    currentIndex -= 100;
    let cIndex = document.querySelector("#currentIndex");
    cIndex.innerHTML = currentIndex;
    tableItemCreation();
    }
else
{
    let cIndex = document.querySelector("#currentIndex");
    cIndex.innerHTML = "Can't go back anymore.";
}
}
function tableItemCreation() {
  console.log(items[0]["itemID"]);
  let difference = 0;
  let tableItems = document.querySelector("#tableItems");
  tableItems.innerHTML = "";
  headerRow =
    "<th>itemID</th><th>name</th><th>description</th><th>category</th>" +
    "<th>weight</th><th>costPrice</th><th>retailPrice</th>" +
    "<th>supplierID</th><th>active</th><th>notes</th><th>caseSize</th>";
  tableItems.innerHTML += headerRow;
 if (currentIndex+100 > items.length)
 {
difference = currentIndex+100 - items.length;
console.log(difference);
 }
  for (let i = currentIndex; i < currentIndex+100-difference; i++) {
    let tableItem = "";
    tableItem += "<tr>";
    tableItem += `<td>${items[i]['itemID']}</td>`;
    tableItem += `<td>${items[i]['name']}</td>`;
    tableItem += `<td>${items[i]['description']}</td>`;
    tableItem += `<td>${items[i]['category']}</td>`;
    tableItem += `<td>${items[i]['weight']}</td>`;
    tableItem += `<td>${items[i]['costPrice']}</td>`;
    tableItem += `<td>${items[i]['retailPrice']}</td>`;
    tableItem += `<td>${items[i]['supplierID']}</td>`;
    tableItem += `<td>${items[i]['active']}</td>`;
    tableItem += `<td>${items[i]['notes']}</td>`;
    tableItem += `<td>${items[i]['caseSize']}</td>`;
    tableItem += '</tr>';
    tableItems.innerHTML += tableItem;

  }
}
