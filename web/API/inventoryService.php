<?php
session_start();
require_once '../DB/inventoryAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "GET" && isset($_GET['site']))
{
        grabInventoryBySiteWithPrice();
}
else if ($method === "GET" && isset($_GET['stock']))
{
        grabStock();
}
else if ($method === "GET")
{
        grabInventory();
}
/**
 * This function takes a site ID from the get and
 * simply gives a json containing inventory items ONLY
 * from that site.
 */
function grabInventoryBySiteWithPrice()
{
        $result = "";
        try {
        $body = file_get_contents('php://input');
        $ic = new inventoryAccessor();
        $items = $ic->getAllInventoryBySiteWithPrice($_GET['site']);
        $result = json_encode($items,JSON_NUMERIC_CHECK); 
}       
catch (PDOException $e) {
        echo $e->getMessage();
    
}
echo $result;
}
/**
 * Grabs all the pieces of inventory in 
 * the system.
 */
function grabInventory(){
    try {
        $body = file_get_contents('php://input');
        $ic = new inventoryAccessor();
        $items = $ic->getAllInventoryItems();
        $result = json_encode($items,JSON_NUMERIC_CHECK);
} 
catch (PDOException $e) {
        echo $e->getMessage();
    
}
//echo json_encode($ic->getInventoryItems("select * from item"), JSON_NUMERIC_CHECK);
echo json_encode($ic->getAllInventoryItems(), JSON_NUMERIC_CHECK);

}
/**
 * This function just
 * grabs the warehouse stock for the order
 * page, grabbing anything that has stock within the inventory.
 */
function grabStock(){
        try {
            $body = file_get_contents('php://input');
            $ic = new inventoryAccessor();
            $items = $ic->getInventoryStock();
            $result = json_encode($items,JSON_NUMERIC_CHECK);
    } 
    catch (PDOException $e) {
            echo $e->getMessage();
        
    }
    //echo json_encode($ic->getInventoryItems("select * from item"), JSON_NUMERIC_CHECK);
    echo $result;
    
    }