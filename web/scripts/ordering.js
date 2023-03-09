let orderItems = [];
eMode = false;
window.onload = function()
{
  document.querySelector("#AddItem").addEventListener("click",Add_Item)
  document.querySelector("#OrderSubmit").addEventListener("click",OrderCreate);
  document.querySelector("#txnType").addEventListener("change",switchType)
  Dashboard();
  FillTxnTypes()
  getStores();
}
/**
 * Code grabbed from
 * web ordering in order to grab a list of 
 * stores that can be used to send to a
 * specific store
 * 
 * 
 * 
 * 
 * 
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
let selection = document.querySelector("#storeDelivery");
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
  * 
  * 
  * 
  * 
  * 
  * 
  * 
  */
/**
 * This function clears the orderItems list
 * and sents eMode(emergency mode) depending on
 * what's found in the textbox.
 */
function switchType()
{
  choice = document.querySelector("#txnType").value
  if (choice === "Emergency")
  {
    eMode = true
  }
  else
  {
    eMode = false
  }
  orderItems = []
  document.querySelector("#orderDetails").innerHTML = ""
  
}


/**
 * This section fills
 * in the txn dropdown with for now the ability
 * to create a store order and an emergency order.
 */
function FillTxnTypes()
{
  dropDown = document.querySelector("#txnType")
  choice1 = document.createElement("option")
  choice1.text = "Store"
  dropDown.add(choice1);
  choice2 = document.createElement("option")
  choice2.text = "Emergency"
  dropDown.add(choice2);
  console.log(dropDown)
}



function Add_Item()
{
  //This function will iterate through the list of items and
  //Check for the minimum quantity.
  if (orderItems.length > 4 && eMode == true)
  {
    alert("Maximum items added.")
  }
  else
  {
  let tempList = [];
  Rows = document.querySelectorAll("tr input");
  console.log(Rows);
  for (let i = 0; i < Rows.length;i++)
  {
    if (Rows[i].value > 0)
    {
      let nodes = Rows[i].parentElement.parentElement.childNodes;
      itemIDNode = nodes[0].innerHTML
      siteIDNode = nodes[1].innerHTML
      quantityNode = nodes[2].innerHTML
      itemLocation = nodes[3].innerHTML
      reorderThreshold = nodes[4].innerHTML
      amountOrdered = nodes[5].value
      console.log(itemQuantity)     
      //Item list generation. 
      orderItems.push({"itemID": `${itemIDNode}`, "siteID": `${siteIDNode}`,"itemLocation": `${itemLocation}`,"reorderThreshold": `${reorderThreshold}`, "Quantity": `${quantityNode}`}); 
      orderItems.push({"itemID": `${itemIDNode}`, "siteID": `${siteIDNode}`,"itemLocation": `${itemLocation}`,"reorderThreshold": `${reorderThreshold}`, "Quantity": `${quantityNode}`}); 

    }

  }
  console.log(orderItems)
  orderSummary = document.querySelector("#orderDetails")
  html = ""
  if (tempList.length == 0)
  {
    alert("No item selected.");
  }
  else
  {
  for (let i = 0; i < tempList.length; i++)
  {
    line = tempList[i];
    html += trCreator(line)
  }
}
  orderSummary.innerHTML += html;
  clearQuantitySelect();
}
}
//
//
//Clears values
function clearQuantitySelect()
{
  let numeric = document.querySelectorAll("input[type=number]");
  for (let i = 0; i < numeric.length; i++)
  {
    numeric[i].value = 0;
  }
}
///
///
///


function Dashboard() {
    let url = "API/inventoryService.php"; // REST-style: URL refers to an entity or collection, not an action
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
      "<th>itemID</th><th>name</th><th>siteID</th><th>quantity</th>" +
      "<th>itemLocation</th><th>reorderThreshold</th>";
    tableItems.innerHTML += headerRow;
    for (let i = 0; i < 100; i++) {
      let tableItem = "";
      tableItem += "<tr>";
      tableItem += `<td>${items[i]['itemID']}</td>`;
      tableItem += `<td>${items[i]['itemName']}</td>`;
      tableItem += `<td>${items[i]['siteID']}</td>`;
      tableItem += `<td>${items[i]['quantity']}</td>`;
      tableItem += `<td>${items[i]['itemLocation']}</td>`;
      tableItem += `<td>${items[i]['reorderThreshold']}</td>`;
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
  ///
  /// The creation of the order.
  ///
  function OrderCreate() {
    let url = "API/OrderService.php"; // REST-style: URL refers to an entity or collection, not an action
    let xmlhttp = new XMLHttpRequest();
    let method = "PUT";
    let JSONObj = {"items": orderItems}
    if (orderItems.length == 0)
    {
      alert("Cannot create empty order.");
      return
    }
    xmlhttp.onreadystatechange = function () {
      if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
        let resp = xmlhttp.responseText;
        console.log(resp + "null");
        alert("Order has been created.")
        orderItems = [];
        document.querySelector("#orderDetails").innerHTML = "";
      }
    
    };
    xmlhttp.open(method, url, true); // method is either POST or PUT
    xmlhttp.send(JSON.stringify(JSONObj));
  }