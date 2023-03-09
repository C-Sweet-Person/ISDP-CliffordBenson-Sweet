
window.onload = function()
{
    getStores();
    document.querySelector("#storeSelect").addEventListener("change",getItemsExisting)
    document.querySelector("#searchButton").addEventListener("click",searchItems);
    document.querySelector("#searchButton").addEventListener("click",searchItems);

    getItemsExisting()
}

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
 * This function will get
 * the items into a json to be
 * placed into a table.
 * (This function is called
 * whenever the dropdown boxes
 * changes)
 */
function getItemsExisting()
{
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
  rowData = `<td>${IDNode}</td><td>${nameNode}</td><td>${categoryNode}</td><td>${quantityNode}</td><td>$${priceNode}</td><td><input class="qty" type="number" min=0 value=0 max="${Number(quantityNode)}"></td>`
  rowEnd = "</tr>"
  HTMLRow = rowStart + rowData + rowEnd;
  HTMLData += HTMLRow
}
table.innerHTML += HTMLData;
console.log(table)
}

/**
 * This function checks to see if the add button was pressed
 * and adds an item based on if the input checkboxes values
 * have been changed.
 */
function AddItem_Order()
{


}

/**
 * This function will create an account creation box
 * 
 */
/**
 * This function creates the order and sends it to the warehouse
 * as an online order txnType as well. (Take in a list, return an alert.)
 * Note: Maybe add the ability to add a name for a customer, might be
 * too complicated though.
 */
function sendOrderInfo(items)
{



}

/**
 * This function creates a Modal web
 * form that goes on top of the main
 * page and will have a add account info
 * and close account info.
 */

function createModalAccountWindow()
{

}

/**
 * This function creates a search
 * button that is able to be clicked on and
 * will grab items that relate to the search query.
 * 
 */

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
        tableRows[i].classList.remove("hidden");
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
    tableRows[i].classList.add("hidden");
    console.log(tableRows[i].innerHTML)

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
       tableRows.classList.remove("hidden");
        
    }
}