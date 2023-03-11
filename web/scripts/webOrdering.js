
window.onload = function()
{
    getStores();
    document.querySelector("#storeSelect").addEventListener("change",getItemsExisting)
    document.querySelector("#searchButton").addEventListener("click",searchItems);
    document.querySelector("#orderSubmit").addEventListener("click",submitOrder);
    getItemsExistingDefault()
}
let orderItems = {};
let cartItems = [];
/**
 * This function gets the store
 * locations that can be used with
 * the next function, fill in stores.
 */
function getStores()
{
 let url = "API/siteService.php"; // REST-style: URL refers to an entity or collection, not an action
 let xmlhttp = new XMLHttpRequest();
 let method = "GET";
 xmlhttp.onreadystatechange = function () {
   if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
     let resp = xmlhttp.responseText;
     fillInStores(resp)
   }
   else
   {
     console.log("No data found.");
   }
 };
 xmlhttp.open(method, url, true); // method is either POST or PUT
 xmlhttp.send();
}
/**
 * This function grabs the info
 * from getStores and places it
 * in the dropdown box.
 */
function fillInStores(JSONfile)
 {
let file = JSON.parse(JSONfile)
let selection = document.querySelector("#storeSelect");
for (let i = 0; i < file.length; i++)
{
    if (file[i]["siteType"] == 'Retail' && file[i]['name'].toUpperCase().includes('RETAIL'))
    {
    choice = document.createElement("option");
    choice.text = file[i]['name'];
    choice.value = file[i]['siteID'];
    selection.add(choice);
    console.log(choice)
    }
}
 }

/**
 * Default getItemsExisting (Only called once)
 */
function getItemsExistingDefault()
{
let value = document.querySelector("#storeSelect").value;
console.log(value);
let url = "API/inventoryService.php" + `?site=4`; // REST-style: URL refers to an entity or collection, not an action
let xmlhttp = new XMLHttpRequest();
let method = "GET";
xmlhttp.onreadystatechange = function () {
  if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
    let resp = xmlhttp.responseText;
    console.log(resp)
    makeItemDisplay(resp)
  }
  else
  {
    console.log("No data found.");
  }
};
xmlhttp.open(method, url, true); // method is either POST or PUT
xmlhttp.send();
}
/**
 * This function will get
 * the items into a json to be
 * placed into a table.
 * (This function is called
 * whenever the dropdown boxes
 * changes)
 */
function getItemsExisting()
{
orderItems = [];
let value = document.querySelector("#storeSelect").value;
console.log(value);
let url = "API/inventoryService.php" + `?site=${value}`; // REST-style: URL refers to an entity or collection, not an action
let xmlhttp = new XMLHttpRequest();
let method = "GET";
xmlhttp.onreadystatechange = function () {
  if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
    let resp = xmlhttp.responseText;
    console.log(resp)
    makeItemDisplay(resp)
  }
  else
  {
    console.log("No data found.");
  }
};
xmlhttp.open(method, url, true); // method is either POST or PUT
xmlhttp.send();
}
/**
 * This function displays
 * the items into a table
 * to select items via quantity.
 */
function makeItemDisplay(data)
{
dataParsed = JSON.parse(data);
table = document.querySelector("#tableItems")
table.innerHTML = ""
HTMLData = "<tr><th>ItemID</th><th>ItemName</th><th>category</th><th>Quantity</th><th>Price</th><th>QTY</th></tr>";
for (let i = 0; i < dataParsed.length; i++)
{
  rowStart = "<tr>"
  nameNode = dataParsed[i]['itemName'];
  categoryNode = dataParsed[i]['category'];
  quantityNode = dataParsed[i]['quantity'];
  priceNode = dataParsed[i]['retailCost'];
  IDNode = dataParsed[i]['itemID'];
  rowData = `<td>${IDNode}</td><td>${nameNode}</td><td>${categoryNode}</td><td>${quantityNode}</td><td>$${priceNode}</td><td><input class="qty" type="number" min=0 max="${Number(quantityNode)}"></td>
  <td><button id="AddItem">Add to cart</button></td>`
  rowEnd = "</tr>"
  HTMLRow = rowStart + rowData + rowEnd;
  HTMLData += HTMLRow
}
table.innerHTML += HTMLData;
console.log(table)
Add = document.querySelectorAll("#AddItem");
for (let i = 0; i < Add.length; i++)
{
  Add[i].addEventListener("click", AddItem_Order)
}
}

/**
 * This function checks to see if the add button was pressed
 * and adds an item based on if the input checkboxes values
 * have been changed.
 */
function AddItem_Order(evt)
{
  //Variables
  row = evt.target.parentElement.parentElement;
  rowLength = row.children.length
  quantity = row.querySelector(".qty");
  tableCart = document.querySelector("#shoppingCartItems")
  console.log(rowLength)
  quantity.max -= quantity.value
  let name = row.children[1].innerHTML;
  let id = row.children[0].innerHTML;
  let price = row.children[4].innerHTML;
  row.children[3].innerHTML = quantity.max;
  //End Variables
  if (quantity.max == 0)
  {
    row.classList.add("hidden");
  }
  /**
   * Alright, this is going to be a long function.
   * But actually a lot of testing will go on the backend so
   * we really don't need weight since that's gonna be checked
   * on the SQL side.
   */

  //1. Filling in the list.
  if (cartItems.includes(id))
  {
    shoppingCart = document.querySelectorAll(".cartItem");
    for (let i = 0; i < shoppingCart.length; i++)
    {
      if (shoppingCart[i].children[1].innerHTML == id)
      {
        initialAmount = Number(shoppingCart[i].children[2].innerHTML)
        newAmount = initialAmount + Number(quantity.value)
        shoppingCart[i].children[2].innerHTML = newAmount
      }
    }
  }
  else
  {
    htmlRow = `<tr class="cartItem"><td>${name}</td><td>${id}</td><td>${quantity.value}</td><td>${price}</td></tr>`
    tableCart.innerHTML += htmlRow;
    cartItems.push(id)
  }
  quantity.value = 0;
}

function searchItems()
{
    search = document.querySelector("#itemSearch");
    searchText = search.value;
    table = document.querySelector("#tableItems")
    tableRows = document.querySelectorAll("#tableItems tr");
    hideItems();
    for (let i = 1; i < tableRows.length; i++)
    {
        rowText = tableRows[i].children[1].innerHTML
        if (rowText.toUpperCase().includes(searchText.toUpperCase()))
        {
        if (tableRows[i].querySelector(".qty").max != 0){
        tableRows[i].classList.remove("hidden");
        }
        }
    }
    if (searchText = "")
    {
        showItems();
    }
}

/**
 * This function will hide every row for the search
 * function using the '.hidden' class
 */
function hideItems()
{
    table = document.querySelector("#tableItems")
    tableRows = document.querySelectorAll("#tableItems tr");
    for (let i = 1; i < tableRows.length; i++)
    {
      if (tableRows[i].querySelector(".qty").max != 0)
      {
    tableRows[i].classList.add("hidden");
      }
    }
}
/**
 * This function will hide every row for the search
 * function removing the '.hidden' class
 */
function showItems()
{
    table = document.querySelector("#tableItems")
    tableRows = document.querySelectorAll("#tableItems tr");
    for (let i = 1; i < tableRows.length; i++)
    {
      if (tableRows[i].querySelector(".qty").max != 0)
      {
       tableRows.classList.remove("hidden");
      }
    }
}
/**
 * This function will submit an order
 * and then redirect the user to a page
 * with account details.
 */

function submitOrder()
{
orderItems = {};
let shoppingItems = [];
if (document.querySelectorAll(".cartItem").length == 0)
{
  alert("Can't submit an order with nothing in it.");
}
else
{
  let items = document.querySelectorAll(".cartItem")
  for (let i = 0; i < items.length; i++)
  {
    let name = items[i].children[0].innerHTML;
    let id = items[i].children[1].innerHTML;
    let itemCount = items[i].children[2].innerHTML;
    let price = items[i].children[3].innerHTML;
    let item = {"name": name, "ID": id, "quantity": itemCount, "price": price.replace("$","")}
    shoppingItems.push(item);
  }
  date = {"Date": Date.now()}
  orderItems.items = shoppingItems;
  orderItems.date = date;
  sessionStorage.setItem("orderInfo", JSON.stringify(orderItems));
  window.location.href = "orderReview.php"
}
}