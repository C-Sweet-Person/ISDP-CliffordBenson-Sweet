<?php
session_start();
require_once '../DB/inventoryAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "GET" && isset($_GET['site']))
{
        grabInventoryBySite();
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
function grabInventoryBySite()
{
        $result = "";
        try {
        $body = file_get_contents('php://input');
        $ic = new inventoryAccessor();
        $items = $ic->getAllInventoryBySite($_GET['site']);
        $result = json_encode($items,JSON_NUMERIC_CHECK); 
}       
catch (PDOException $e) {
        echo $e->getMessage();
    
}
echo json_encode($result, JSON_NUMERIC_CHECK);
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