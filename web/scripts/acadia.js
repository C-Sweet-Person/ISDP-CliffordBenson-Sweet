
window.onload = function() {
getOrders()
}
/**This function gets the orders that
 * are ready to be picked up and gives
 * a JSON that is used to build the
 * order table
 */

function getLocations()
{

}
//Gets all the transactions although it's going to be switched to
//Only store and online order later on.
function getOrders()
{
    let url = "API/OrderService.php"; // REST-style: URL refers to an entity or collection, not an action
    let xmlhttp = new XMLHttpRequest();
    let method = "GET";
    xmlhttp.onreadystatechange = function () {
      if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
        let resp = xmlhttp.responseText;
        console.log(resp);
        createOrderTable(resp);
      }
    
    };
    xmlhttp.open(method, url, true); // method is either POST or PUT
    xmlhttp.send(); 
}
/**
 * This function creates an
 * order table by which an order
 * can be selected, which is what
 * a lot of the functions check for
 * (id .selected)
 */
function createOrderTable(data)
{
parsedData = data;
console.log(data)

}
/**
 * This function creates the code
 * that
 */