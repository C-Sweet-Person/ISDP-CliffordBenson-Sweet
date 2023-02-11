let items;
window.onload = function()
{
  document.querySelector("#AddItem").addEventListener("click",Add_Item)
    Dashboard();
}

function Add_Item()
{
  //This function will iterate through the list of items and
  //Check for the minimum quantity.
  Rows = document.querySelectorAll("tr input");
  console.log(Rows);
  for (let i = 0; i < Rows.length;i++)
  {
    if (Rows[i].value > 0)
    {
      console.log(Rows[i].parentElement.parentElement)
    }
  }

}
function Dashboard() {
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

  function initialSetup(resp)
  {
  items = JSON.parse(resp);
  tableItemCreation();
  }



  function tableItemCreation() {
    console.log(items[0]["itemID"]);
    let difference = 0;
    let tableItems = document.querySelector("#orderPage");
    tableItems.innerHTML = "";
    headerRow =
      "<th>itemID</th><th>name</th><th>description</th><th>category</th>" +
      "<th>weight</th><th>costPrice</th><th>retailPrice</th>" +
      "<th>supplierID</th><th>active</th><th>notes</th><th>caseSize</th><th>Quantity</th>";
    tableItems.innerHTML += headerRow;
    for (let i = 0; i < 100; i++) {
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
      tableItem += '<td><input type="number" id="quantity" min="0" value="0"></input>'
      tableItem += '</tr>';
      tableItems.innerHTML += tableItem;
  
    }
    rows = document.querySelectorAll("tr");
    for (let i = 1; i < rows.length -1; i++)
    {
      rows[i].addEventListener("click", selectRow);
    }
  }
  
  function selectRow(evt)
  {
    rows = document.querySelectorAll(".selected");
    for (let i = 0; i < rows.length; i++)
    {
      rows[i].classList.remove("selected");
    }
    row = evt.currentTarget
    row.classList.add("selected");
  }