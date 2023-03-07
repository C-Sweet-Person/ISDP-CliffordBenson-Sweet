
/**
 * This function gets the store
 * locations that can be used with
 * the next function, fill in stores.
 */
window.onload = function()
{
    getStores();
    document.querySelector("#storeSelect").addEventListener("change",getItemsExisting)
}
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
    js = JSON.parse(resp);
    console.log(js[0])
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
function makeItemDisplay()
{


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